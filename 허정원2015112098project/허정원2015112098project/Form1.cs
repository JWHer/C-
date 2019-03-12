using HTTPComm;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace 허정원2015112098project
{
    /*
         prog name : Computer Usage Analysis
         1. n분 후 시스템 종료를 수행한다.
         2. 일간/주간/월간 컴퓨터 사용량을 저장(서버에 기록후 로컬 데이터)
         3. 컴퓨터 시작시 자동 시작. 종료 시 서버에 자동 기록
    */
    public partial class Form1 : Form
    {
        //path
        string DataPath;
        string TimePath;
        string defalutPath;

        //options
        bool pwrMode;
        bool nirMode;
        bool clsMode;

        //flags
        bool close;
        bool error;
        bool justClose = true;

        //data field
        string id;
        /*데이터 양식
        {
           0 "2015112098",//ID
           1 "6",//window8 shift4 ctrl2 alt1 none0 default(ctrl&shift)
           2 "83",//(int)S
           3 "0",//close2 power1 none0 default(minimized&sleep)
           4 "TIME DATA"
        };
        */
        string[] optionData;
        /* 시간 데이터 양식
            YYYY MM dd HH mm ss ? \r\n (?:실행w절전s종료d닫기c)
        */
        string[] timeData;
        //usageField
        float beforeLine = 0;
        float totalUse;
        //key Field
        int combKey = 2 + 4;//window8 shift4 ctrl2 alt1 none0
        int key = 'S';
        //calendarField
        int fontSize = 10;
        int blockSize = 50;
        DateTime viewTime;
        DateTime[,] dateTimes = new DateTime[6, 7];

        Form2 frm2;

        //핫키등록, 제거
        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(int hwnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(int hwnd, int id);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //레지스트리 확인
            string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            string currentPath;
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(runKey);
            if (key.GetValue("CUAnalysis") == null)
            {
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(runKey, true);
                key.SetValue("CUAnalysis", Application.ExecutablePath);
                MessageBox.Show("시작프로그램에 등록됬습니다.");
            }

            currentPath = key.GetValue("CUAnalysis").ToString();
            string[] s = currentPath.Split('\\');
            currentPath = "";
            for (int i = 0; i < s.Length - 1; i++) currentPath += s[i] + "\\";
            DataPath = currentPath + "user.dat";
            TimePath = currentPath + "data.dat";
            defalutPath = currentPath;

            ///*** 데이터 읽기***///
            FileInfo dataInfo = new FileInfo(DataPath);
            if (!dataInfo.Exists)
            {
                MessageBox.Show("이 장치에서 처음 시작합니다.");
                Form3 frm3 = new Form3();
                frm3.StartPosition = FormStartPosition.CenterScreen;
                frm3.Text += "등록";
                frm3.ShowDialog();

                id = frm3.getId;
                if (id == "error") error = true;
                using (StreamWriter outputFile = new StreamWriter(DataPath))
                    outputFile.WriteLine(id + "\r\n" + this.combKey + "\r\n" + this.key + "\r\n0");
            }

            try
            {
                optionData = File.ReadAllLines(DataPath);
                id = optionData[0];
                this.combKey = int.Parse(optionData[1]);
                this.key = int.Parse(optionData[2]);

                if (int.Parse(optionData[3]) / 2 == 1)
                {
                    clsMode = true;
                    닫기ToolStripMenuItem.Text += "√";
                }
                else 축소ToolStripMenuItem.Text += "√";
                close = clsMode;

                if (int.Parse(optionData[3])/4 == 1)
                {
                    nirMode = true;
                    종료ToolStripMenuItem.Text ="최대절전";
                    절전ToolStripMenuItem.Text ="화면끄기";
                }

                if (int.Parse(optionData[3]) % 2 == 1)
                {
                    pwrMode = true;
                    종료ToolStripMenuItem.Text += "√";
                }
                else 절전ToolStripMenuItem.Text += "√";

                RegisterHotKey((int)this.Handle, 0, this.combKey, this.key);
            }
            catch
            {
                if(MessageBox.Show("DATA파일 손상!\r\n프로그램을 다시 시작하십시오.",
                    "경고", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    timeData = new string[1];
                    dataInfo.Delete();
                    close = true;
                    error = true;
                    this.Close();
                }
                error = true;
            }

            FileInfo timeInfo = new FileInfo(TimePath);
            if (timeInfo.Exists) timeData = File.ReadAllLines(TimePath);

            //백그라운드폼 생성
            frm2 = new Form2(id, this.combKey, this.key);
            frm2.Owner = this;
            frm2.pwrOptionEvent += new Form2.Option_EventHandler(pwrOptChange);
            frm2.clsOptionEvent += new Form2.Option_EventHandler(clsOptChange);
            frm2.nirOptionEvent += new Form2.Option_EventHandler(nirOptChange);
            frm2.srtChangeEvent += new Form2.ShortCut_EventHandler(shortCutChange);
            frm2.idChangeEvent += new Form2.Id_EventHandler(idChange);
            frm2.StartPosition = FormStartPosition.CenterParent;
            //frm2.ShowDialog();
            
            //시간 체크
            TimeCheck(sender, e);
            
            pwrTooltipChange();
            setTooltip.SetToolTip(setPanel, "설정");
            errTooltip.SetToolTip(errLabel, "오류가 있습니다");

            //달력초기화
            viewTime = DateTime.Now;
            InitCalender(viewTime);
            calenderPanel.Invalidate();
            monthLabel.Text = viewTime.ToString("y");
            timeLabel.Text = DateTime.Now.ToString("T");
            dateLabel.Text = DateTime.Now.ToString("D");
            timer1.Enabled = true;
            calenderPanel.MouseUp += new MouseEventHandler(calenderPanel_Click);
            //usage
            usagePanel.Invalidate();
            int yLoc = ((DateTime.Now.Hour * 3600) + (DateTime.Now.Minute * 60) + (DateTime.Now.Second)) * 360 / 86400;
            nowLabel.Location = new Point(0, yLoc - 5);

            notifyIcon.Visible = true;
        }

        //재시작 시간 체크
        private void TimeCheck(object sender, EventArgs e)
        {
            int result = 0;
            try
            {
                HTTPWebComm comm = new HTTPWebComm();
                comm.SetURL("http://210.94.194.82:52131/log.asp?id=" + id + "&cmd=read&action=shutdown");
                comm.SetMessage("");
                comm.Request();

                result = int.Parse(Regex.Replace(comm.Response(), @"\D", ""));

                frm2.setLogTextbox("시작\r\n");

                comm.SetURL("http://210.94.194.82:52131/log.asp?id=" + id + "&cmd=write&action=wakeup");
                comm.Request();

                comm.SetURL("http://210.94.194.82:52131/log.asp?id=" + id + "&cmd=read&action=wakeup");
                comm.Request();

                result -= int.Parse(Regex.Replace(comm.Response(), @"\D", ""));
                result = -result;
            }
            catch (System.Net.WebException)
            {
                frm2.setLogTextbox("서버에 접속하지 못하였습니다.\r\n");
                MessageBox.Show("서버에 접속하지 못하였습니다.");
                return;
            }
            catch (Exception err)
            {
                frm2.setLogTextbox("알수없는 에려\r\n" + err.ToString() + "\r\n");
                MessageBox.Show("알수없는 에려\r\n" + err.ToString());
                return;
            }
            finally
            {
                if (timeData != null)
                    Array.Resize(ref timeData, timeData.Length + 1);
                else
                    timeData = new string[1];
                timeData[timeData.Length - 1] = DateTime.Now.ToString("yyyy MM dd HH mm ss") + " w";
            }

            frm2.setLogTextbox("환영합니다 " + id + "님\r\n");
            if (result < 300)
            {
                frm2.setLogTextbox( "다시 시작한지 " + result + "초 만입니다.\r\n");
                MessageBox.Show("환영합니다.\r\n다시 시작한지 " + result + "초 만입니다.");
                return;
            }
            else if (result / 60 < 60)
            {
                frm2.setLogTextbox("다시 시작한지 " + result / 60 + "분 " + result % 60 + "초 만입니다.\r\n");
                MessageBox.Show("환영합니다.\r\n다시 시작한지 " + result / 60 + "분 만입니다.");
                return;
            }
            else if(result> 259200)//1달이상
            {
                frm2.setLogTextbox("다시 시작한지 1달 이상이거나 처음 시작합니다.\r\n");
                MessageBox.Show("환영합니다.");
                return;
            }
            frm2.setLogTextbox("다시 시작한지 " + result / 3600 + "시간 " + result % 3600 / 60 + "분 " + result % 360 % 60 + "초 만입니다.\r\n");
            MessageBox.Show("환영합니다.\r\n다시 시작한지 " + result / 3600 + "시간 만입니다.");
        }

        //예약종료
        private void powerTimer_Tick(object sender, EventArgs e)
        {
            powerTimer.Enabled = false;
            if (!nirMode)
            {
                if (pwrMode)
                {
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 0");
                }
                else
                {
                    System.Diagnostics.Process.Start("rundll32", "powrprof.dll SetSuspendState");
                }
            }
            else
            {
                try
                {
                    if (pwrMode)
                    {
                        System.Diagnostics.Process.Start(defalutPath+"\\nircmd.exe", "hibernate");
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(defalutPath + "\\nircmd.exe", "monitor off");
                    }
                }
                catch
                {
                    System.Diagnostics.Process.Start("http://www.nirsoft.net/utils/nircmd.html");
                    MessageBox.Show("NirCmd를 다운받으십시오");
                }
            }
        }

        //***키보드 후크&&종료 후크***//
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x312)//HOTKEY = 0x0312
            {
                if (m.WParam == (IntPtr)0x0) // 그 키의 ID가 0이면
                {
                    pwrPanel_Click(null, null);
                }
            }
            if (m.Msg == 0x11)//Windows ENDSESSION
            {
                frm2.setLogTextbox("종료\r\n");
                justClose = false;
                Array.Resize(ref timeData, timeData.Length + 1);
                timeData[timeData.Length - 1] = DateTime.Now.ToString("yyyy MM dd HH mm ss") + " d";
                Thread t = new Thread(()=>serverThread("shutdown"));
                t.Start();
            }
            if (m.Msg == 0x218 && m.WParam.ToInt32() == 0x4)//POWERBROADCAST sleep (hibernate도 lparam까지 정확히 같다, 구분 불가)
            {
                frm2.setLogTextbox("절전\r\n");
                Array.Resize(ref timeData, timeData.Length + 1);
                timeData[timeData.Length - 1] = DateTime.Now.ToString("yyyy MM dd HH mm ss") + " s";
                Thread t = new Thread(() => serverThread("hibernate"));
                t.Start();
            }
            if (m.Msg == 0x218 && m.WParam.ToInt32() == 0x12)//POWERBROADCAST wakeup
            {
                frm2.setLogTextbox("시작\r\n");
                Array.Resize(ref timeData, timeData.Length + 1);
                timeData[timeData.Length - 1] = DateTime.Now.ToString("yyyy MM dd HH mm ss") + " w";
                Thread t = new Thread(() => serverThread("wakeup"));
                t.Start();
                usagePanel.Invalidate();
            }
            base.WndProc(ref m);
        }

        //thread
        private void serverThread(string message)
        {
            try
            {
                HTTPWebComm comm = new HTTPWebComm();
                comm.SetURL("http://210.94.194.82:52131/log.asp?id=" + id + "&cmd=write&action="+message);
                comm.SetMessage("");
                comm.Request();
            }
            catch
            {
                frm2.setLogTextbox("서버 전송 오류(" + message + ")\r\n");
            }
        }

        //calender
        private void InitCalender(DateTime dateValue)//달력 데이터를 초기화시키는 부분
        {
            //오늘이 포함된 주의 일요일을 구함
            int startDay = dateValue.Day - (int)dateValue.DayOfWeek;
            //달의 첫 일요일 날자를 구함(-5~1)
            if (startDay > 1) { startDay -= ((startDay - 1) / 7 + 1) * 7; }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    dateTimes[i, j] = dateValue.AddDays(-dateValue.Day + (startDay++));
                }
            }
        }

        private void calenderPanel_Paint(object sender, PaintEventArgs e)//달력을 그리는 부분
        {
            monthLabel.Text = viewTime.ToString("y");
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(Brushes.LightGray), 0, 0, calenderPanel.Right, 0);
            Brush b = Brushes.White;

            for (int i = 0; i < 7; i++)
            {
                g.DrawString(intToDate(i),
                       new Font("Verdana", fontSize - 2), b,
                       new PointF(16 + i * blockSize, 60));
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (dateTimes[i, j].ToString("d") == viewTime.ToString("d"))//선택한 날
                    {
                        g.FillRectangle(Brushes.DodgerBlue,
                               new Rectangle(j * blockSize, (i + 1) * (blockSize - 10) + 48, blockSize, blockSize - 10));
                        g.FillRectangle(new SolidBrush(this.BackColor),
                               new Rectangle(j * blockSize + 2, (i + 1) * (blockSize - 10) + 50, blockSize - 4, blockSize - 14));
                    }

                    if (dateTimes[i, j].ToString("d") == DateTime.Now.ToString("d"))//오늘
                    {
                        g.FillRectangle(Brushes.DodgerBlue,
                               new Rectangle(j * blockSize + 4, (i + 1) * (blockSize - 10) + 52, blockSize - 8, blockSize - 18));
                    }

                    b = Brushes.White;
                    if (dateTimes[i, j].Month != viewTime.Month)//다른달
                        b = Brushes.Gray;
                    string sDay = "";
                    if (dateTimes[i, j].Day < 10) sDay = " ";
                    sDay += dateTimes[i, j].Day;

                    //글자 넣기
                    if (dateTimes[i, j].ToString("d") == DateTime.Now.ToString("d"))
                        g.DrawString(sDay,
                       new Font("Verdana", fontSize, FontStyle.Bold), Brushes.White,
                       new PointF(j * blockSize + 14, (i + 1) * (blockSize - 10) + 60));
                    else
                        g.DrawString(sDay,
                           new Font("Verdana", fontSize), b,
                           new PointF(j * blockSize + 14, (i + 1) * (blockSize - 10) + 60));
                }
            }
        }

        private string intToDate(int i)
        {
            string str;
            switch (i%7)
            {
                case 0:
                    str = "일";
                    break;
                case 1:
                    str = "월";
                    break;
                case 2:
                    str = "화";
                    break;
                case 3:
                    str = "수";
                    break;
                case 4:
                    str = "목";
                    break;
                case 5:
                    str = "금";
                    break;
                case 6:
                    str = "토";
                    break;
                default:
                    str = "";
                    break;
            }
            return str;
        }

        //내부 시계
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("T");
            if (DateTime.Now.Second % 60 == 0) //1분마다 갱신
            {
                InitCalender(viewTime);
                calenderPanel.Invalidate();
                usagePanel.Invalidate();
            }
            if (error) errLabel.Visible = true;
        }

        private void leftLabel_MouseEnter(object sender, EventArgs e)
        {
            leftLabel.ForeColor = Color.White;
        }

        private void leftLabel_MouseLeave(object sender, EventArgs e)
        {
            leftLabel.ForeColor = Color.LightGray;
        }

        private void rightLabel_MouseEnter(object sender, EventArgs e)
        {
            rightLabel.ForeColor = Color.White;
        }

        private void rightLabel_MouseLeave(object sender, EventArgs e)
        {
            rightLabel.ForeColor = Color.LightGray;
        }

        private void leftLabel_Click(object sender, EventArgs e)
        {
            viewTime = viewTime.AddMonths(-1);
            InitCalender(viewTime);
            calenderPanel.Invalidate();

            usagePanel.Invalidate();
            if (viewTime.ToString("d") != DateTime.Now.ToString("d")) nowLabel.Visible = false;
            else nowLabel.Visible = true;
        }

        private void rightLabel_Click(object sender, EventArgs e)
        {
            viewTime = viewTime.AddMonths(1);
            InitCalender(viewTime);
            calenderPanel.Invalidate();

            usagePanel.Invalidate();
            if (viewTime.ToString("d") != DateTime.Now.ToString("d")) nowLabel.Visible = false;
            else nowLabel.Visible = true;
        }

        private void calenderPanel_Click(object sender, MouseEventArgs e)
        {
            int j = e.X / blockSize;
            int i = (e.Y - 88) / (blockSize - 10);
            if (j >= 7 || i >= 6 || e.Y < 88) return;

            viewTime = dateTimes[i, j];
            InitCalender(viewTime);
            calenderPanel.Invalidate();
            usagePanel.Invalidate();
            if (viewTime.ToString("d") != DateTime.Now.ToString("d")) nowLabel.Visible = false;
            else nowLabel.Visible = true;
        }

        //usage analysis
        private void viewTimeChange()
        {
            beforeLine = 0;
            totalUse = 0;
            
            //지금보다 미래의 데이터는 존재하지 않음
            if (viewTime.Year > DateTime.Now.Year && viewTime.DayOfYear>DateTime.Now.DayOfYear) return;
            if (error) return;

            string[] timeStrings;
            char before = 'n';
            bool last = false;
            float width = 5;//선 너비
            int stringStart = 0;//시간 글자 시작
            int blockSize = 12;//시간 글자 간격

            Graphics g = usagePanel.CreateGraphics();

            for (int i = 0; i < timeData.Length; i++)
            {
                timeStrings = timeData[i].Split(' ');
                if (timeStrings.Length != 7) { MessageBox.Show("DATA손상!"); error = true; return; }

                DateTime data = new DateTime(int.Parse(timeStrings[0]), int.Parse(timeStrings[1]), int.Parse(timeStrings[2]));
                if (viewTime < data && !last) last = true;//데이터가 보는시간보다 커질때 && 마지막이 아닐 때
                if (viewTime.ToString("d") != data.ToString("d") && !last) continue;//데이터가 보는시간이 아닐때 && 마지막이 아닐때

                //이전 종료 데이터 추출, 처음이면 하지 않음
                if (i != 0) before = timeData[i - 1].Split(' ')[6].ToCharArray()[0];
                //현재 위치, 마지막이면 360(끝)
                float bar = (float)(int.Parse(timeStrings[3]) * 3600 + int.Parse(timeStrings[4]) * 60 + int.Parse(timeStrings[5])) * 360 / 86400;
                if (last) bar = 360;
                //써줄 글자 작성, 마지막이면 시간정보 추가
                string str = timeStrings[3] + ":" + timeStrings[4];
                if (last) str = timeStrings[1] + "월" + timeStrings[2] + "일 " + timeStrings[3] + ":" + timeStrings[4];

                Pen p = new Pen(Brushes.Gray, width);

                if (timeStrings[6] == "w")
                {
                    switch (before)
                    {
                        case 's':
                        case 'd':
                        case 'm':
                            p = new Pen(Brushes.OrangeRed, width);
                            break;
                        //case 'c':
                        //case 'n':
                        //case 'w':
                        default:
                            p = new Pen(Brushes.Gray, width);
                            break;
                    }

                    str += " 시작";
                }
                else
                {
                    switch (before)
                    {
                        case 'w':
                            p = new Pen(Brushes.DodgerBlue, width);
                            totalUse += bar - beforeLine;
                            break;
                        case 'm':
                            p = new Pen(Brushes.OrangeRed, width);
                            break;
                        //case 's':
                        //case 'd':
                        //case 'c':
                        //case 'n':
                        default:
                            p = new Pen(Brushes.Gray, width);
                            break;
                    }

                    if (timeStrings[6] == "c")
                        str += " 닫기";
                    else if (timeStrings[6] == "d")
                        str += " 종료";
                    else if (timeStrings[6] == "s")
                        str += " 절전";
                    else if (timeStrings[6] == "m")
                        str += " 화면끄기";
                }
                //상태 표시
                g.DrawLine(p, 45, beforeLine, 45, bar);
                //적절한 위치에 선과 글자 생성
                if (stringStart < bar) stringStart += (int)(bar - stringStart) / 2;
                g.DrawLine(new Pen(SystemBrushes.ControlLightLight), 45, bar, 60, stringStart + 5);
                g.DrawString(str, this.Font, SystemBrushes.ControlLightLight, 60, stringStart);

                stringStart += blockSize;
                beforeLine = bar;
                if (last) break;
            }

            //현재시간이면 상태를 계속 진행시킴
            if (viewTime.ToString("d") == DateTime.Now.ToString("d"))
            {
                float yLoc = ((DateTime.Now.Hour * 3600) + (DateTime.Now.Minute * 60) + (DateTime.Now.Second)) * 360 / 86400;
                g.DrawLine(new Pen(Brushes.DodgerBlue, width), 45, beforeLine, 45, yLoc + 2);
                totalUse += yLoc - beforeLine + 1;
                nowLabel.Location = new Point(0, (int)(yLoc - 5));
            }
        }

        private void usagePanel_Paint(object sender, PaintEventArgs e)
        {
            viewTimeChange();

            //사용량에 따라 글자색을 바꾸어준다
            SolidBrush b;
            if (totalUse * 100 / 360 < 12.5)
                b = (SolidBrush)SystemBrushes.ControlDarkDark;
            else if (totalUse * 100 / 360 < 25)
                b = (SolidBrush)SystemBrushes.ControlDark;
            else if (totalUse * 100 / 360 < 50)
                b = (SolidBrush)SystemBrushes.ControlLight;
            else
                b = (SolidBrush)SystemBrushes.ControlLightLight;
            usePLabel.ForeColor = b.Color;
            usePLabel.Text =string.Format("{0:#0.##}",totalUse * 100 / 360) + "%";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(SystemBrushes.ControlLight), 0, 0, 150, 0);
        }

        //이하 이벤트 및 부가기능
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!error)
            {
                int option = 0;
                if (nirMode) option += 4;
                if (pwrMode) option += 1;
                if (clsMode) option += 2;
                //데이터 저장
                using (StreamWriter outputFile = new StreamWriter(DataPath))
                    outputFile.WriteLine(id + "\r\n" + combKey + "\r\n" + key + "\r\n" + option);
                //시간데이터 저장
                using (StreamWriter outputFile = new StreamWriter(TimePath))
                    for (int i = 0; i < timeData.Length; i++)
                        outputFile.WriteLine(timeData[i]);
            }
            else
            {
                new FileInfo(DataPath).Delete();
                new FileInfo(TimePath).Delete();
            }
            
            UnregisterHotKey((int)this.Handle, 0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!close)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                if (justClose)
                {
                    Array.Resize(ref timeData, timeData.Length + 1);
                    timeData[timeData.Length - 1] = DateTime.Now.ToString("yyyy MM dd HH mm ss") + " c";
                }
            }
        }

        private void pwrOptChange(bool mode)
        {
            pwrMode = mode;
            pwrTooltipChange();

            if (nirMode)
            {
                종료ToolStripMenuItem.Text = "최대절전";
                절전ToolStripMenuItem.Text = "화면끄기";

            }
            else
            {
                종료ToolStripMenuItem.Text = "종료";
                절전ToolStripMenuItem.Text = "절전";
            }
            if (pwrMode) { 종료ToolStripMenuItem.Text += "√"; }
            else 절전ToolStripMenuItem.Text += "√";
        }

        private void clsOptChange(bool mode)
        {
            clsMode = mode;
            close = clsMode;
            닫기ToolStripMenuItem.Text = "닫기";
            축소ToolStripMenuItem.Text = "축소";
            if (clsMode) { 닫기ToolStripMenuItem.Text += "√"; }
            else 축소ToolStripMenuItem.Text += "√";
        }

        private void nirOptChange(bool mode)
        {
            nirMode = mode;
            if (nirMode)
            {
                종료ToolStripMenuItem.Text = "최대절전";
                절전ToolStripMenuItem.Text = "화면끄기";

            }
            else
            {
                종료ToolStripMenuItem.Text = "종료";
                절전ToolStripMenuItem.Text = "절전";
            }
            if (pwrMode) { 종료ToolStripMenuItem.Text += "√"; }
            else 절전ToolStripMenuItem.Text += "√";
            pwrTooltipChange();
        }

        private void shortCutChange(int combKey, int key)
        {
            this.combKey = combKey;
            this.key = key;
            UnregisterHotKey((int)this.Handle, 0);
            RegisterHotKey((int)this.Handle, 0, combKey, key);
            pwrTooltipChange();
        }

        private void idChange(string id)
        {
            this.id = id;
        }

        //단순히 pwrTooltip을 바꾸어준다
        private void pwrTooltipChange()
        {
            string tooltip = frm2.IntToKey(this.combKey) + (char)this.key + "를 눌러 ";
            if (nirMode)
            {
                if (pwrMode) tooltip += "최대절전";
                else tooltip += "화면끄기";
            }
            else
            {
                if (pwrMode) tooltip += "종료";
                else tooltip += "절전";
            }
            pwrTooltip.SetToolTip(pwrPanel, tooltip);
        }
        
        //툴스트립
        private void exitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void reSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void restToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pwrPanel_Click(sender, e);
        }

        private void 절전ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pwrOptChange(false);
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pwrOptChange(true);
        }

        private void 축소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsOptChange(false);
        }

        private void 닫기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsOptChange(true);
        }

        private void 정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog();
        }

        //설정버튼
        private void setPanel_Click(object sender, EventArgs e)
        {
            frm2.setclsMode = this.clsMode;
            frm2.setpwrMode = this.pwrMode;
            frm2.setnirMode = this.nirMode;
            frm2.ShowDialog();
        }

        private void setPanel_MouseEnter(object sender, EventArgs e)
        {
            setPanel.BackgroundImage = Properties.Resources.set_active;
        }

        private void setPanel_MouseLeave(object sender, EventArgs e)
        {
            setPanel.BackgroundImage = Properties.Resources.set_passive;
        }

        //휴식 버튼
        private void pwrPanel_Click(object sender, EventArgs e)
        {
            if (powerTimer.Enabled == true)
            {
                DialogResult result;
                result = MessageBox.Show("예약된 종료가 있습니다.\r\n취소합니까?", "경고", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;
            }
            if (minuteNumeric.Value == 0)
            {
                powerTimer_Tick(sender, e);
                return;
            }
            powerTimer.Interval = (int)minuteNumeric.Value * 60 * 1000;
            powerTimer.Enabled = true;
        }

        private void pwrPanel_MouseEnter(object sender, EventArgs e)
        {
            pwrPanel.BackgroundImage = Properties.Resources.power_active;
        }

        private void pwrPanel_MouseLeave(object sender, EventArgs e)
        {
            pwrPanel.BackgroundImage = Properties.Resources.power_pasive;
        }
        
    }
}

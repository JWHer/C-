using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 허정원2015112098project
{
    public partial class Form6 : Form
    {
        int fontSize = 10;
        int blockSize = 50;
        DateTime viewTime;
        DateTime[,] dateTimes = new DateTime[6, 7];

        public Form6()
        {
            InitializeComponent();

            viewTime = DateTime.Now;
            InitCalender(viewTime);
            calenderPanel.Invalidate();
            monthLabel.Text = viewTime.ToString("y");

            leftLabel.Font = new Font(leftLabel.Font, FontStyle.Bold);
            rightLabel.Font = new Font(rightLabel.Font, FontStyle.Bold);
            timeLabel.Text = DateTime.Now.ToString("T");
            dateLabel.Text = DateTime.Now.ToString("D");
            timer1.Enabled = true;
        }

        private void InitCalender(DateTime dateValue)
        {
            //오늘이 포함된 주의 일요일을 구함
            int startDay = dateValue.Day - (int)dateValue.DayOfWeek;
            //달의 첫 일요일 날자를 구함(-5~1)
            if (startDay > 1) { startDay -= ((startDay - 1) / 7 + 1) * 7; }
            for(int i=0; i<6; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    dateTimes[i, j] = dateValue.AddDays(-dateValue.Day + (startDay++));
                }
            }
        }
        
        private void calenderPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(Brushes.LightGray), 0, 0, calenderPanel.Right, 0);
            Brush b = Brushes.White;

            for(int i=0; i<7; i++)
            {
                g.DrawString(dateString(i),
                       new Font("Verdana", fontSize-2), b,
                       new PointF(14 + i * blockSize, 60));
            }
            
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (dateTimes[i, j].DayOfYear == DateTime.Now.DayOfYear)
                    {
                        g.FillRectangle(Brushes.DodgerBlue,
                               new Rectangle(j * blockSize+2, (i+1) * (blockSize - 10) + 52, blockSize-8, blockSize-18));
                    }
                    
                    b = Brushes.White;
                    if (dateTimes[i, j].Month != viewTime.Month)//다른달
                        b = Brushes.Gray;
                    string sDay="";
                    if (dateTimes[i, j].Day < 10) sDay = " ";
                    sDay += dateTimes[i, j].Day;

                    //글자 넣기
                    g.DrawString(sDay,
                       new Font("Verdana", fontSize), b,
                       new PointF(j * blockSize + 12, (i+1) * (blockSize - 10)+60));
                }
            }
        }

        private string dateString(int i)
        {
            string str;
            switch (i)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("T");
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
            monthLabel.Text = viewTime.ToString("y");
        }

        private void rightLabel_Click(object sender, EventArgs e)
        {
            viewTime = viewTime.AddMonths(1);
            InitCalender(viewTime);
            calenderPanel.Invalidate();
            monthLabel.Text = viewTime.ToString("y");
        }
    }
}

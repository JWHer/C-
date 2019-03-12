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
    public partial class Form2 : Form
    {
        public delegate void Option_EventHandler(bool mode);
        public delegate void ShortCut_EventHandler(int combKey, int key);
        public delegate void Id_EventHandler(string id);
        public event Option_EventHandler pwrOptionEvent;
        public event Option_EventHandler clsOptionEvent;
        public event Option_EventHandler nirOptionEvent;
        public event ShortCut_EventHandler srtChangeEvent;
        public event Id_EventHandler idChangeEvent;

        string id;
        int combKey, key;
        bool pwrMode;
        bool clsMode;
        bool nirMode;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string id, int combKey, int key)
        {
            InitializeComponent();
            this.id = id;
            this.combKey = combKey;
            this.key = key;

            toolTip1.SetToolTip(shortcutButton, IntToKey(this.combKey) + (char)this.key);
            toolTip3.SetToolTip(clsOptionButton, "닫기시 프로그램 축소/닫기");
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (nirMode)
            {
                toolTip2.SetToolTip(pwrOptionButton, "휴식시 화면끄기/최대절전");
                toolTip4.SetToolTip(nircmdButton, "사용중");
                if (pwrMode) pwrOptionButton.Text = "최대절전";
                else pwrOptionButton.Text = "화면끄기";

            }
            else
            {
                toolTip2.SetToolTip(pwrOptionButton, "휴식시 컴퓨터 절전/종료");
                toolTip4.SetToolTip(nircmdButton, "미사용");
                if (pwrMode) pwrOptionButton.Text = "종료";
                else pwrOptionButton.Text = "절전";
            }
            if (clsMode) clsOptionButton.Text = "닫기";
            else clsOptionButton.Text = "축소";
            logTextbox.SelectionStart = logTextbox.Text.Length;
            logTextbox.ScrollToCaret();
        }

        public bool setpwrMode
        {
            get
            {
                return pwrMode;
            }
            set
            {
                pwrMode = value;
            }
        }
        public bool setclsMode
        {
            get
            {
                return clsMode;
            }
            set
            {
                clsMode = value;
            }
        }
        public bool setnirMode
        {
            get
            {
                return nirMode;
            }
            set
            {
                nirMode = value;
            }
        }

        public void setLogTextbox(string s)
        {
            logTextbox.Text += s;
            logTextbox.SelectionStart = logTextbox.Text.Length;
            logTextbox.ScrollToCaret();
        }
        public string getLogTextbox()
        {
            return logTextbox.Text;
        }

        private void pwrOptionButton_Click(object sender, EventArgs e)
        {
            if (nirMode)
            {
                if (pwrMode)
                {
                    pwrOptionButton.Text = "화면끄기";
                    pwrMode = false;
                }
                else
                {
                    pwrOptionButton.Text = "최대절전";
                    pwrMode = true;
                }
            }
            else
            {
                if (pwrMode)
                {
                    pwrOptionButton.Text = "절전";
                    pwrMode = false;
                }
                else
                {
                    pwrOptionButton.Text = "종료";
                    pwrMode = true;
                }
            }
            pwrOptionEvent(pwrMode);
        }

        private void clsOptionButton_Click(object sender, EventArgs e)
        {
            if (clsMode)
            {
                clsOptionButton.Text = "축소";
                clsMode = false;
            }
            else
            {
                clsOptionButton.Text = "닫기";
                clsMode = true;
            }
            clsOptionEvent(clsMode);
        }

        private void nircmdButton_Click(object sender, EventArgs e)
        {
            if (nirMode)
            {
                toolTip2.SetToolTip(pwrOptionButton, "휴식시 컴퓨터 절전/종료");
                if (pwrMode)
                {
                    pwrOptionButton.Text = "종료";
                }
                else
                {
                    pwrOptionButton.Text = "절전";
                }
                toolTip4.SetToolTip(nircmdButton, "미사용");
                nirMode = false;
            }
            else
            {
                toolTip2.SetToolTip(pwrOptionButton, "휴식시 화면끄기/최대절전");
                if (pwrMode)
                {
                    pwrOptionButton.Text = "최대절전";
                }
                else
                {
                    pwrOptionButton.Text = "화면끄기";
                }
                MessageBox.Show("이 기능을 위해서는 NirCmd가 필요합니다.");
                toolTip4.SetToolTip(nircmdButton, "사용중");
                nirMode = true;
            }
            nirOptionEvent(nirMode);
        }

        private void shortcutButton_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.srtCutChangeEvent += new Form4.Form4_EventHandler(shortCutChange);
            frm4.ShowDialog();
        }

        private void shortCutChange(int combKey, int key)
        {
            this.combKey = combKey;
            this.key = key;
            toolTip1.SetToolTip(shortcutButton, IntToKey(this.combKey) + (char)this.key);
            srtChangeEvent(combKey, key);
        }
        
        private void advanceButton_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(id);
            frm3.ShowDialog();
            if (id != frm3.getId) {
                id = frm3.getId;
                setLogTextbox("아이디가 " + id + "로 변경되었습니다.\r\n");
                idChangeEvent(id);
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog();
        }

        public string IntToKey(int combKey)
        {
            string key="";
            
            if ((combKey & 2) == 2) key += "Ctrt ";
            if ((combKey & 1) == 1) key += "Alt ";
            if ((combKey & 4) == 4) key += "Shift ";
            if ((combKey & 8) == 8) key += "Window ";

            return key;
        }
    }
}

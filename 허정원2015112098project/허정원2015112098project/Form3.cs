using HTTPComm;
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
    public partial class Form3 : Form
    {
        string id="error";
        bool close;

        public Form3()
        {
            InitializeComponent();
            regButton.Visible = false;
        }

        public Form3(string id)
        {
            InitializeComponent();
            this.id = id;
            textBox1.Text = this.id;
            label1.Visible = false;
            ChangeButton.Text = "ID Change";
            textBox1.Location = new Point(12, 12);
            this.Text = "고급";
            close = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("ID를 입력하세요!");
                return;
            }
            string data = textBox1.Text;
            try
            {
                HTTPWebComm comm = new HTTPWebComm();
                comm.SetURL("http://210.94.194.82:52131/log.asp?id=" + data + "&cmd=read&action=wakeup");
                comm.SetMessage("");
                comm.Request();
                comm.Response();
            }
            catch
            {
                MessageBox.Show("존재하지 않는 id입니다.\r\nid등록에 실패했습니다.");
                return;
            }
            id = data;
            MessageBox.Show("id를 바꾸었습니다.");
            close = true;
            this.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return) ChangeButton_Click(sender, e);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("ID를 입력하세요!");
                return;
            }
            string data = textBox1.Text;
            try
            {
                HTTPWebComm comm = new HTTPWebComm();
                comm.SetURL("http://210.94.194.82:52131/registerUser.asp?id=" + data);
                comm.SetMessage("");
                comm.Request();
                comm.Response();
            }
            catch
            {
                MessageBox.Show("id등록에 실패했습니다.");
                return;
            }
            MessageBox.Show("id등록에 성공했습니다.");
            textBox1.Text = data;
        }

        public string getId
        {
            get{ return this.id; }
            set { id = value; }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!close)
            {
                DialogResult result;
                result = MessageBox.Show("ID를 등록하지 않으면 이용에 제한이 있을 수 있습니다.", "경고", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(runKey, true);
            if (key.GetValue("CUAnalysis") != null)
            {
                key.DeleteValue("CUAnalysis");
                MessageBox.Show("시작프로그램에서 삭제했습니다.");
            }
            else
            {
                MessageBox.Show("시작프로그램에 존재하지 않습니다.");
            }
            regButton.Enabled = false;
        }
    }
}

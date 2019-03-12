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
    public partial class Form4 : Form
    {
        public delegate void Form4_EventHandler(int combKey, int key);
        public event Form4_EventHandler srtCutChangeEvent;
        int proceed = 0;
        int firstKey, secondKey, thirdKey;

        public Form4()
        {
            InitializeComponent();
            this.KeyUp += new KeyEventHandler(Keyboard_Input);
            okButton.Enabled = firstCBox.Visible = secondCBox.Visible = thirdCBox.Visible = false;
            inducingTip.SetToolTip(inducingLabel, "윈도우, 쉬프트, 컨트롤, 알트를 사용하십시오");
        }

        private void Keyboard_Input(object sender, KeyEventArgs e)
        {
            if (proceed == 3) return;
            showKeyLabel.Text = e.KeyCode.ToString();
            if (proceed == 0 && KeyToInt(e.KeyCode) != 0)
            {
                proceed++;
                firstKey = KeyToInt(e.KeyCode);
                keyLabel.Text += e.KeyCode.ToString() + " + ";
                inducingLabel.Text = "두번째 조합키 : ";
                showKeyLabel.Text = "";
            }
            else if (proceed == 1 && KeyToInt(e.KeyCode) != 0 && firstKey != KeyToInt(e.KeyCode))
            {
                proceed++;
                secondKey = KeyToInt(e.KeyCode);
                keyLabel.Text += e.KeyCode.ToString() + " + ";
                inducingLabel.Text = "세번째 조합키 : ";
                showKeyLabel.Text = "";
                inducingTip.SetToolTip(inducingLabel, "알파벳을 사용하십시오");
            }
            else if (proceed == 2 && e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                proceed++;
                thirdKey = (int)e.KeyCode;
                keyLabel.Text += e.KeyCode.ToString();
                inducingLabel.Text = showKeyLabel.Text = "";
                showKeyLabel.Text = "";
                okButton.Enabled = true;
            }
            else
            {
                if(proceed<2) inducingTip.Show("윈도우, 쉬프트, 컨트롤, 알트를 사용하십시오", inducingLabel, 1000);
                if(proceed==2) inducingTip.Show("알파벳을 사용하십시오", inducingLabel, 1000);
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            okButton.Enabled = createButton.Visible = false;
            proceed = 3;
            firstKey = secondKey = thirdKey = -1;
            inducingLabel.Text = showKeyLabel.Text = keyLabel.Text = "";
            firstCBox.Items.Add("None");
            firstCBox.Items.Add("Alt");
            firstCBox.Items.Add("Ctrl");
            firstCBox.Items.Add("Shift");
            firstCBox.Items.Add("Window");
            secondCBox.Items.Add("None");
            secondCBox.Items.Add("Alt");
            secondCBox.Items.Add("Ctrl");
            secondCBox.Items.Add("Shift");
            secondCBox.Items.Add("Window");
            for (int i = 'A'; i <= 'Z'; i++)
            {
                thirdCBox.Items.Add((char)i);
            }
            firstCBox.Visible = secondCBox.Visible = thirdCBox.Visible = true;
        }

        private void firstCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firstCBox.SelectedIndex == 0) firstKey = 0;
            else firstKey = 1 << firstCBox.SelectedIndex - 1;
            if (firstKey == secondKey && firstKey != 0) { firstCBox.SelectedItem = null; firstKey = -1; }
            //MessageBox.Show(firstKey.ToString());
            if (firstKey > -1 && secondKey > -1 && thirdKey > -1) okButton.Enabled = true;
            else okButton.Enabled = false;
        }

        private void secondCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (secondCBox.SelectedIndex == 0) secondKey = 0;
            else secondKey = 1 << secondCBox.SelectedIndex - 1;
            if (firstKey == secondKey && secondKey != 0) { secondCBox.SelectedItem = null; secondKey = -1; }
            //MessageBox.Show(secondKey.ToString());
            if (firstKey > -1 && secondKey > -1 && thirdKey > -1) okButton.Enabled = true;
            else okButton.Enabled = false;
        }

        private void thirdCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            thirdKey = thirdCBox.SelectedIndex + 65;
            //MessageBox.Show((char)thirdKey + "");
            if (firstKey > -1 && secondKey > -1 && thirdKey > -1) okButton.Enabled = true;
            else okButton.Enabled = false;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            srtCutChangeEvent(firstKey + secondKey, thirdKey);
            this.Close();
        }

        private int KeyToInt(Keys k)
        {
            int key;
            switch (k)
            {
                case Keys.Alt:
                case Keys.Menu:
                    key = 1;
                    break;
                case Keys.Control:
                case Keys.ControlKey:
                    key = 2;
                    break;
                case Keys.Shift:
                case Keys.ShiftKey:
                    key = 4;
                    break;
                case Keys.LWin:
                case Keys.RWin:
                    key = 8;
                    break;
                default:
                    key = 0;
                    break;
            }
            return key;
        }

        private void ShortCutForm_Load(object sender, EventArgs e)
        {

        }
    }
}

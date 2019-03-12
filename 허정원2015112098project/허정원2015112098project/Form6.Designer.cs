namespace 허정원2015112098project
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.calenderPanel = new System.Windows.Forms.Panel();
            this.rightLabel = new System.Windows.Forms.Label();
            this.leftLabel = new System.Windows.Forms.Label();
            this.monthLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dateLabel = new System.Windows.Forms.Label();
            this.calenderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // calenderPanel
            // 
            this.calenderPanel.Controls.Add(this.rightLabel);
            this.calenderPanel.Controls.Add(this.leftLabel);
            this.calenderPanel.Controls.Add(this.monthLabel);
            this.calenderPanel.Location = new System.Drawing.Point(5, 90);
            this.calenderPanel.Name = "calenderPanel";
            this.calenderPanel.Size = new System.Drawing.Size(350, 335);
            this.calenderPanel.TabIndex = 0;
            this.calenderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.calenderPanel_Paint);
            // 
            // rightLabel
            // 
            this.rightLabel.AutoSize = true;
            this.rightLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rightLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rightLabel.Location = new System.Drawing.Point(321, 10);
            this.rightLabel.Name = "rightLabel";
            this.rightLabel.Size = new System.Drawing.Size(21, 19);
            this.rightLabel.TabIndex = 5;
            this.rightLabel.Text = ">";
            this.rightLabel.Click += new System.EventHandler(this.rightLabel_Click);
            this.rightLabel.MouseEnter += new System.EventHandler(this.rightLabel_MouseEnter);
            this.rightLabel.MouseLeave += new System.EventHandler(this.rightLabel_MouseLeave);
            // 
            // leftLabel
            // 
            this.leftLabel.AutoSize = true;
            this.leftLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.leftLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.leftLabel.Location = new System.Drawing.Point(294, 10);
            this.leftLabel.Name = "leftLabel";
            this.leftLabel.Size = new System.Drawing.Size(21, 19);
            this.leftLabel.TabIndex = 4;
            this.leftLabel.Text = "<";
            this.leftLabel.Click += new System.EventHandler(this.leftLabel_Click);
            this.leftLabel.MouseEnter += new System.EventHandler(this.leftLabel_MouseEnter);
            this.leftLabel.MouseLeave += new System.EventHandler(this.leftLabel_MouseLeave);
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.monthLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.monthLabel.Location = new System.Drawing.Point(7, 9);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(50, 20);
            this.monthLabel.TabIndex = 3;
            this.monthLabel.Text = "label1";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timeLabel.Location = new System.Drawing.Point(7, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(131, 54);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.dateLabel.Location = new System.Drawing.Point(12, 63);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(50, 20);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "label1";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(359, 436);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.calenderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form6";
            this.Opacity = 0.95D;
            this.Text = "월별사용";
            this.calenderPanel.ResumeLayout(false);
            this.calenderPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel calenderPanel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label rightLabel;
        private System.Windows.Forms.Label leftLabel;
    }
}
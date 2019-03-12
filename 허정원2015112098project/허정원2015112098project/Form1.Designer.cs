namespace 허정원2015112098project
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.minuteNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.powerTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pwrTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.dateLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.calenderPanel = new System.Windows.Forms.Panel();
            this.rightLabel = new System.Windows.Forms.Label();
            this.leftLabel = new System.Windows.Forms.Label();
            this.monthLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.setPanel = new System.Windows.Forms.Panel();
            this.usagePanel = new System.Windows.Forms.Panel();
            this.nowLabel = new System.Windows.Forms.Label();
            this.usePLabel = new System.Windows.Forms.Label();
            this.pwrPanel = new System.Windows.Forms.Panel();
            this.setTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.errTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.errLabel = new System.Windows.Forms.Label();
            this.mainMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.휴식시ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.절전ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.닫기시ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.축소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.닫기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.minuteNumeric)).BeginInit();
            this.notifyMenuStrip.SuspendLayout();
            this.calenderPanel.SuspendLayout();
            this.usagePanel.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(363, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "컴퓨터 사용지수";
            // 
            // minuteNumeric
            // 
            this.minuteNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.minuteNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.minuteNumeric.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.minuteNumeric.Location = new System.Drawing.Point(688, 344);
            this.minuteNumeric.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.minuteNumeric.Name = "minuteNumeric";
            this.minuteNumeric.Size = new System.Drawing.Size(48, 21);
            this.minuteNumeric.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(740, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "분 후";
            // 
            // powerTimer
            // 
            this.powerTimer.Tick += new System.EventHandler(this.powerTimer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "CUAnalysis";
            // 
            // notifyMenuStrip
            // 
            this.notifyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restToolStripMenuItem,
            this.reSizeToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitProgramToolStripMenuItem});
            this.notifyMenuStrip.Name = "contextMenuStrip1";
            this.notifyMenuStrip.Size = new System.Drawing.Size(140, 76);
            // 
            // restToolStripMenuItem
            // 
            this.restToolStripMenuItem.Name = "restToolStripMenuItem";
            this.restToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.restToolStripMenuItem.Text = "Rest";
            this.restToolStripMenuItem.Click += new System.EventHandler(this.restToolStripMenuItem_Click);
            // 
            // reSizeToolStripMenuItem
            // 
            this.reSizeToolStripMenuItem.Name = "reSizeToolStripMenuItem";
            this.reSizeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.reSizeToolStripMenuItem.Text = "ReSize";
            this.reSizeToolStripMenuItem.Click += new System.EventHandler(this.reSizeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // exitProgramToolStripMenuItem
            // 
            this.exitProgramToolStripMenuItem.Name = "exitProgramToolStripMenuItem";
            this.exitProgramToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.exitProgramToolStripMenuItem.Text = "ExitProgram";
            this.exitProgramToolStripMenuItem.Click += new System.EventHandler(this.exitProgramToolStripMenuItem_Click);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.dateLabel.Location = new System.Drawing.Point(17, 63);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(50, 20);
            this.dateLabel.TabIndex = 7;
            this.dateLabel.Text = "label1";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timeLabel.Location = new System.Drawing.Point(12, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(131, 54);
            this.timeLabel.TabIndex = 6;
            this.timeLabel.Text = "label1";
            // 
            // calenderPanel
            // 
            this.calenderPanel.Controls.Add(this.rightLabel);
            this.calenderPanel.Controls.Add(this.leftLabel);
            this.calenderPanel.Controls.Add(this.monthLabel);
            this.calenderPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.calenderPanel.Location = new System.Drawing.Point(10, 90);
            this.calenderPanel.Name = "calenderPanel";
            this.calenderPanel.Size = new System.Drawing.Size(350, 335);
            this.calenderPanel.TabIndex = 5;
            this.calenderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.calenderPanel_Paint);
            // 
            // rightLabel
            // 
            this.rightLabel.AutoSize = true;
            this.rightLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rightLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rightLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rightLabel.Location = new System.Drawing.Point(321, 10);
            this.rightLabel.Name = "rightLabel";
            this.rightLabel.Size = new System.Drawing.Size(22, 19);
            this.rightLabel.TabIndex = 5;
            this.rightLabel.Text = ">";
            this.rightLabel.Click += new System.EventHandler(this.rightLabel_Click);
            this.rightLabel.MouseEnter += new System.EventHandler(this.rightLabel_MouseEnter);
            this.rightLabel.MouseLeave += new System.EventHandler(this.rightLabel_MouseLeave);
            // 
            // leftLabel
            // 
            this.leftLabel.AutoSize = true;
            this.leftLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leftLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.leftLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.leftLabel.Location = new System.Drawing.Point(294, 10);
            this.leftLabel.Name = "leftLabel";
            this.leftLabel.Size = new System.Drawing.Size(22, 19);
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
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // setPanel
            // 
            this.setPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.setPanel.BackgroundImage = global::허정원2015112098project.Properties.Resources.set_passive;
            this.setPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.setPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setPanel.Location = new System.Drawing.Point(742, 397);
            this.setPanel.Name = "setPanel";
            this.setPanel.Size = new System.Drawing.Size(30, 30);
            this.setPanel.TabIndex = 8;
            this.setPanel.Click += new System.EventHandler(this.setPanel_Click);
            this.setPanel.MouseEnter += new System.EventHandler(this.setPanel_MouseEnter);
            this.setPanel.MouseLeave += new System.EventHandler(this.setPanel_MouseLeave);
            // 
            // usagePanel
            // 
            this.usagePanel.Controls.Add(this.nowLabel);
            this.usagePanel.Location = new System.Drawing.Point(366, 65);
            this.usagePanel.Name = "usagePanel";
            this.usagePanel.Size = new System.Drawing.Size(200, 360);
            this.usagePanel.TabIndex = 9;
            this.usagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.usagePanel_Paint);
            // 
            // nowLabel
            // 
            this.nowLabel.AutoSize = true;
            this.nowLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nowLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nowLabel.Location = new System.Drawing.Point(0, 0);
            this.nowLabel.Name = "nowLabel";
            this.nowLabel.Size = new System.Drawing.Size(43, 15);
            this.nowLabel.TabIndex = 10;
            this.nowLabel.Text = "지금─";
            // 
            // usePLabel
            // 
            this.usePLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.usePLabel.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.usePLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.usePLabel.Location = new System.Drawing.Point(572, 373);
            this.usePLabel.Name = "usePLabel";
            this.usePLabel.Size = new System.Drawing.Size(164, 54);
            this.usePLabel.TabIndex = 10;
            this.usePLabel.Text = "label1";
            this.usePLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pwrPanel
            // 
            this.pwrPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pwrPanel.BackgroundImage = global::허정원2015112098project.Properties.Resources.power_pasive;
            this.pwrPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pwrPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pwrPanel.Location = new System.Drawing.Point(742, 361);
            this.pwrPanel.Name = "pwrPanel";
            this.pwrPanel.Size = new System.Drawing.Size(30, 30);
            this.pwrPanel.TabIndex = 11;
            this.pwrPanel.Click += new System.EventHandler(this.pwrPanel_Click);
            this.pwrPanel.MouseEnter += new System.EventHandler(this.pwrPanel_MouseEnter);
            this.pwrPanel.MouseLeave += new System.EventHandler(this.pwrPanel_MouseLeave);
            // 
            // errLabel
            // 
            this.errLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errLabel.AutoSize = true;
            this.errLabel.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.errLabel.Location = new System.Drawing.Point(750, 9);
            this.errLabel.Name = "errLabel";
            this.errLabel.Size = new System.Drawing.Size(22, 32);
            this.errLabel.TabIndex = 12;
            this.errLabel.Text = "!";
            this.errLabel.Visible = false;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.휴식시ToolStripMenuItem,
            this.닫기시ToolStripMenuItem,
            this.toolStripSeparator2,
            this.정보ToolStripMenuItem});
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(111, 76);
            // 
            // 휴식시ToolStripMenuItem
            // 
            this.휴식시ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.절전ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.휴식시ToolStripMenuItem.Name = "휴식시ToolStripMenuItem";
            this.휴식시ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.휴식시ToolStripMenuItem.Text = "휴식시";
            // 
            // 절전ToolStripMenuItem
            // 
            this.절전ToolStripMenuItem.Name = "절전ToolStripMenuItem";
            this.절전ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.절전ToolStripMenuItem.Text = "절전";
            this.절전ToolStripMenuItem.Click += new System.EventHandler(this.절전ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 닫기시ToolStripMenuItem
            // 
            this.닫기시ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.축소ToolStripMenuItem,
            this.닫기ToolStripMenuItem});
            this.닫기시ToolStripMenuItem.Name = "닫기시ToolStripMenuItem";
            this.닫기시ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.닫기시ToolStripMenuItem.Text = "닫기시&";
            // 
            // 축소ToolStripMenuItem
            // 
            this.축소ToolStripMenuItem.Name = "축소ToolStripMenuItem";
            this.축소ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.축소ToolStripMenuItem.Text = "축소";
            this.축소ToolStripMenuItem.Click += new System.EventHandler(this.축소ToolStripMenuItem_Click);
            // 
            // 닫기ToolStripMenuItem
            // 
            this.닫기ToolStripMenuItem.Name = "닫기ToolStripMenuItem";
            this.닫기ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.닫기ToolStripMenuItem.Text = "닫기";
            this.닫기ToolStripMenuItem.Click += new System.EventHandler(this.닫기ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(107, 6);
            // 
            // 정보ToolStripMenuItem
            // 
            this.정보ToolStripMenuItem.Name = "정보ToolStripMenuItem";
            this.정보ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.정보ToolStripMenuItem.Text = "정보...";
            this.정보ToolStripMenuItem.Click += new System.EventHandler(this.정보ToolStripMenuItem_Click);
            // 
            // linePanel
            // 
            this.linePanel.Location = new System.Drawing.Point(369, 57);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(150, 5);
            this.linePanel.TabIndex = 13;
            this.linePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(784, 436);
            this.ContextMenuStrip = this.mainMenuStrip;
            this.Controls.Add(this.linePanel);
            this.Controls.Add(this.errLabel);
            this.Controls.Add(this.pwrPanel);
            this.Controls.Add(this.usePLabel);
            this.Controls.Add(this.usagePanel);
            this.Controls.Add(this.setPanel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.calenderPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.minuteNumeric);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.Text = "전원관리";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minuteNumeric)).EndInit();
            this.notifyMenuStrip.ResumeLayout(false);
            this.calenderPanel.ResumeLayout(false);
            this.calenderPanel.PerformLayout();
            this.usagePanel.ResumeLayout(false);
            this.usagePanel.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown minuteNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer powerTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem reSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitProgramToolStripMenuItem;
        private System.Windows.Forms.ToolTip pwrTooltip;
        private System.Windows.Forms.ToolStripMenuItem restToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Panel calenderPanel;
        private System.Windows.Forms.Label rightLabel;
        private System.Windows.Forms.Label leftLabel;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel setPanel;
        private System.Windows.Forms.Panel usagePanel;
        private System.Windows.Forms.Label nowLabel;
        private System.Windows.Forms.Label usePLabel;
        private System.Windows.Forms.Panel pwrPanel;
        private System.Windows.Forms.ToolTip setTooltip;
        private System.Windows.Forms.ToolTip errTooltip;
        private System.Windows.Forms.Label errLabel;
        private System.Windows.Forms.ContextMenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 휴식시ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 절전ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 닫기시ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 축소ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 닫기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 정보ToolStripMenuItem;
        private System.Windows.Forms.Panel linePanel;
    }
}


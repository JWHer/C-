namespace 허정원2015112098project
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.logTextbox = new System.Windows.Forms.TextBox();
            this.shortcutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pwrOptionButton = new System.Windows.Forms.Button();
            this.clsOptionButton = new System.Windows.Forms.Button();
            this.advanceButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.nircmdButton = new System.Windows.Forms.Button();
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.logTextbox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 200);
            this.panel1.TabIndex = 0;
            // 
            // logTextbox
            // 
            this.logTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logTextbox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.logTextbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logTextbox.Location = new System.Drawing.Point(3, 12);
            this.logTextbox.Multiline = true;
            this.logTextbox.Name = "logTextbox";
            this.logTextbox.ReadOnly = true;
            this.logTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextbox.Size = new System.Drawing.Size(294, 185);
            this.logTextbox.TabIndex = 0;
            // 
            // shortcutButton
            // 
            this.shortcutButton.Location = new System.Drawing.Point(318, 12);
            this.shortcutButton.Name = "shortcutButton";
            this.shortcutButton.Size = new System.Drawing.Size(75, 23);
            this.shortcutButton.TabIndex = 1;
            this.shortcutButton.Text = "단축키변경";
            this.shortcutButton.UseVisualStyleBackColor = true;
            this.shortcutButton.Click += new System.EventHandler(this.shortcutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Log";
            // 
            // pwrOptionButton
            // 
            this.pwrOptionButton.Location = new System.Drawing.Point(318, 41);
            this.pwrOptionButton.Name = "pwrOptionButton";
            this.pwrOptionButton.Size = new System.Drawing.Size(75, 23);
            this.pwrOptionButton.TabIndex = 3;
            this.pwrOptionButton.Text = "절전/종료";
            this.pwrOptionButton.UseVisualStyleBackColor = true;
            this.pwrOptionButton.Click += new System.EventHandler(this.pwrOptionButton_Click);
            // 
            // clsOptionButton
            // 
            this.clsOptionButton.Location = new System.Drawing.Point(318, 70);
            this.clsOptionButton.Name = "clsOptionButton";
            this.clsOptionButton.Size = new System.Drawing.Size(75, 23);
            this.clsOptionButton.TabIndex = 4;
            this.clsOptionButton.Text = "축소/닫기";
            this.clsOptionButton.UseVisualStyleBackColor = true;
            this.clsOptionButton.Click += new System.EventHandler(this.clsOptionButton_Click);
            // 
            // advanceButton
            // 
            this.advanceButton.Location = new System.Drawing.Point(318, 99);
            this.advanceButton.Name = "advanceButton";
            this.advanceButton.Size = new System.Drawing.Size(75, 23);
            this.advanceButton.TabIndex = 5;
            this.advanceButton.Text = "고급";
            this.advanceButton.UseVisualStyleBackColor = true;
            this.advanceButton.Click += new System.EventHandler(this.advanceButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.Location = new System.Drawing.Point(318, 189);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(75, 23);
            this.infoButton.TabIndex = 1;
            this.infoButton.Text = "정보...";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // nircmdButton
            // 
            this.nircmdButton.Location = new System.Drawing.Point(318, 128);
            this.nircmdButton.Name = "nircmdButton";
            this.nircmdButton.Size = new System.Drawing.Size(75, 23);
            this.nircmdButton.TabIndex = 6;
            this.nircmdButton.Text = "nircmd";
            this.nircmdButton.UseVisualStyleBackColor = true;
            this.nircmdButton.Click += new System.EventHandler(this.nircmdButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(404, 221);
            this.Controls.Add(this.nircmdButton);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.advanceButton);
            this.Controls.Add(this.clsOptionButton);
            this.Controls.Add(this.pwrOptionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shortcutButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Opacity = 0.95D;
            this.Text = "설정";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox logTextbox;
        private System.Windows.Forms.Button shortcutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pwrOptionButton;
        private System.Windows.Forms.Button clsOptionButton;
        private System.Windows.Forms.Button advanceButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.Button nircmdButton;
        private System.Windows.Forms.ToolTip toolTip4;
    }
}
namespace 허정원2015112098project
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.keyLabel = new System.Windows.Forms.Label();
            this.inducingLabel = new System.Windows.Forms.Label();
            this.showKeyLabel = new System.Windows.Forms.Label();
            this.inducingTip = new System.Windows.Forms.ToolTip(this.components);
            this.okButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.firstCBox = new System.Windows.Forms.ComboBox();
            this.secondCBox = new System.Windows.Forms.ComboBox();
            this.thirdCBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.keyLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.keyLabel.Location = new System.Drawing.Point(12, 21);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(0, 13);
            this.keyLabel.TabIndex = 0;
            // 
            // inducingLabel
            // 
            this.inducingLabel.AutoSize = true;
            this.inducingLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.inducingLabel.Location = new System.Drawing.Point(12, 9);
            this.inducingLabel.Name = "inducingLabel";
            this.inducingLabel.Size = new System.Drawing.Size(89, 12);
            this.inducingLabel.TabIndex = 1;
            this.inducingLabel.Text = "첫번째 조합키 :";
            // 
            // showKeyLabel
            // 
            this.showKeyLabel.AutoSize = true;
            this.showKeyLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.showKeyLabel.Location = new System.Drawing.Point(107, 9);
            this.showKeyLabel.Name = "showKeyLabel";
            this.showKeyLabel.Size = new System.Drawing.Size(0, 12);
            this.showKeyLabel.TabIndex = 2;
            // 
            // inducingTip
            // 
            this.inducingTip.AutomaticDelay = 0;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(28, 50);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.TabStop = false;
            this.okButton.Text = "확인";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(109, 50);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 4;
            this.createButton.TabStop = false;
            this.createButton.Text = "수동설정";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // firstCBox
            // 
            this.firstCBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.firstCBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.firstCBox.FormattingEnabled = true;
            this.firstCBox.Location = new System.Drawing.Point(12, 24);
            this.firstCBox.Name = "firstCBox";
            this.firstCBox.Size = new System.Drawing.Size(60, 20);
            this.firstCBox.TabIndex = 5;
            this.firstCBox.SelectedIndexChanged += new System.EventHandler(this.firstCBox_SelectedIndexChanged);
            // 
            // secondCBox
            // 
            this.secondCBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.secondCBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.secondCBox.FormattingEnabled = true;
            this.secondCBox.Location = new System.Drawing.Point(78, 24);
            this.secondCBox.Name = "secondCBox";
            this.secondCBox.Size = new System.Drawing.Size(60, 20);
            this.secondCBox.TabIndex = 6;
            this.secondCBox.SelectedIndexChanged += new System.EventHandler(this.secondCBox_SelectedIndexChanged);
            // 
            // thirdCBox
            // 
            this.thirdCBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.thirdCBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.thirdCBox.FormattingEnabled = true;
            this.thirdCBox.Location = new System.Drawing.Point(144, 24);
            this.thirdCBox.Name = "thirdCBox";
            this.thirdCBox.Size = new System.Drawing.Size(60, 20);
            this.thirdCBox.TabIndex = 7;
            this.thirdCBox.SelectedIndexChanged += new System.EventHandler(this.thirdCBox_SelectedIndexChanged);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(214, 81);
            this.Controls.Add(this.thirdCBox);
            this.Controls.Add(this.secondCBox);
            this.Controls.Add(this.firstCBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.showKeyLabel);
            this.Controls.Add(this.inducingLabel);
            this.Controls.Add(this.keyLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "단축키";
            this.Load += new System.EventHandler(this.ShortCutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Label inducingLabel;
        private System.Windows.Forms.Label showKeyLabel;
        private System.Windows.Forms.ToolTip inducingTip;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ComboBox firstCBox;
        private System.Windows.Forms.ComboBox secondCBox;
        private System.Windows.Forms.ComboBox thirdCBox;
    }
}
namespace ArcadisMain
{
    partial class About_Form
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.AboutTextBox = new System.Windows.Forms.TextBox();
            this.TutorialsButton = new System.Windows.Forms.Button();
            this.ReferenceButton = new System.Windows.Forms.Button();
            this.UserButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VersionsTextBox = new System.Windows.Forms.TextBox();
            this.InfoTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(645, 537);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "&Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AboutTextBox
            // 
            this.AboutTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AboutTextBox.Location = new System.Drawing.Point(97, 106);
            this.AboutTextBox.Multiline = true;
            this.AboutTextBox.Name = "AboutTextBox";
            this.AboutTextBox.ReadOnly = true;
            this.AboutTextBox.Size = new System.Drawing.Size(557, 266);
            this.AboutTextBox.TabIndex = 2;
            this.AboutTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TutorialsButton
            // 
            this.TutorialsButton.Location = new System.Drawing.Point(620, 423);
            this.TutorialsButton.Name = "TutorialsButton";
            this.TutorialsButton.Size = new System.Drawing.Size(122, 23);
            this.TutorialsButton.TabIndex = 3;
            this.TutorialsButton.Text = "&Tutorials";
            this.TutorialsButton.UseVisualStyleBackColor = true;
            // 
            // ReferenceButton
            // 
            this.ReferenceButton.Location = new System.Drawing.Point(620, 452);
            this.ReferenceButton.Name = "ReferenceButton";
            this.ReferenceButton.Size = new System.Drawing.Size(122, 23);
            this.ReferenceButton.TabIndex = 4;
            this.ReferenceButton.Text = "&Reference Document";
            this.ReferenceButton.UseVisualStyleBackColor = true;
            // 
            // UserButton
            // 
            this.UserButton.Location = new System.Drawing.Point(620, 394);
            this.UserButton.Name = "UserButton";
            this.UserButton.Size = new System.Drawing.Size(122, 23);
            this.UserButton.TabIndex = 5;
            this.UserButton.Text = "&User Guide";
            this.UserButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.VersionsTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 388);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 194);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assembly Versions Loaded";
            // 
            // VersionsTextBox
            // 
            this.VersionsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VersionsTextBox.Location = new System.Drawing.Point(31, 29);
            this.VersionsTextBox.Multiline = true;
            this.VersionsTextBox.Name = "VersionsTextBox";
            this.VersionsTextBox.ReadOnly = true;
            this.VersionsTextBox.Size = new System.Drawing.Size(255, 159);
            this.VersionsTextBox.TabIndex = 0;
            // 
            // InfoTextBox
            // 
            this.InfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoTextBox.Location = new System.Drawing.Point(26, 29);
            this.InfoTextBox.Multiline = true;
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.ReadOnly = true;
            this.InfoTextBox.Size = new System.Drawing.Size(243, 132);
            this.InfoTextBox.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.InfoTextBox);
            this.groupBox2.Location = new System.Drawing.Point(327, 388);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 194);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System and Revit Settings";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ArcadisMain.Properties.Resources.Arcadis;
            this.pictureBox1.Location = new System.Drawing.Point(264, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // About_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 609);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UserButton);
            this.Controls.Add(this.ReferenceButton);
            this.Controls.Add(this.TutorialsButton);
            this.Controls.Add(this.AboutTextBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About_Form";
            this.Text = "About Arcadis Tools";
            this.Load += new System.EventHandler(this.About_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox AboutTextBox;
        private System.Windows.Forms.Button TutorialsButton;
        private System.Windows.Forms.Button ReferenceButton;
        private System.Windows.Forms.Button UserButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox VersionsTextBox;
        private System.Windows.Forms.TextBox InfoTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
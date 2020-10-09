namespace ArcadisMain
{
    partial class Settings_Form
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
            this.BrowseFamilyButton = new System.Windows.Forms.Button();
            this.FamilyPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LogFilesTextBox = new System.Windows.Forms.TextBox();
            this.BrowseLogButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.RepoTextBox = new System.Windows.Forms.TextBox();
            this.RepoBrowseButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BrowseFamilyButton
            // 
            this.BrowseFamilyButton.Location = new System.Drawing.Point(19, 39);
            this.BrowseFamilyButton.Name = "BrowseFamilyButton";
            this.BrowseFamilyButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseFamilyButton.TabIndex = 0;
            this.BrowseFamilyButton.Text = "Browse >>";
            this.BrowseFamilyButton.UseVisualStyleBackColor = true;
            this.BrowseFamilyButton.Click += new System.EventHandler(this.BrowseFamilyButton_Click);
            // 
            // FamilyPathTextBox
            // 
            this.FamilyPathTextBox.Location = new System.Drawing.Point(101, 40);
            this.FamilyPathTextBox.Name = "FamilyPathTextBox";
            this.FamilyPathTextBox.Size = new System.Drawing.Size(455, 20);
            this.FamilyPathTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project Families:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Log Files:";
            // 
            // LogFilesTextBox
            // 
            this.LogFilesTextBox.Location = new System.Drawing.Point(101, 100);
            this.LogFilesTextBox.Name = "LogFilesTextBox";
            this.LogFilesTextBox.Size = new System.Drawing.Size(455, 20);
            this.LogFilesTextBox.TabIndex = 9;
            // 
            // BrowseLogButton
            // 
            this.BrowseLogButton.Location = new System.Drawing.Point(19, 99);
            this.BrowseLogButton.Name = "BrowseLogButton";
            this.BrowseLogButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseLogButton.TabIndex = 8;
            this.BrowseLogButton.Text = "Browse >>";
            this.BrowseLogButton.UseVisualStyleBackColor = true;
            this.BrowseLogButton.Click += new System.EventHandler(this.BrowseLogButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(250, 231);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 12;
            this.CloseButton.Text = "&Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // RepoTextBox
            // 
            this.RepoTextBox.Location = new System.Drawing.Point(101, 156);
            this.RepoTextBox.Name = "RepoTextBox";
            this.RepoTextBox.Size = new System.Drawing.Size(455, 20);
            this.RepoTextBox.TabIndex = 28;
            // 
            // RepoBrowseButton
            // 
            this.RepoBrowseButton.Location = new System.Drawing.Point(20, 154);
            this.RepoBrowseButton.Name = "RepoBrowseButton";
            this.RepoBrowseButton.Size = new System.Drawing.Size(66, 23);
            this.RepoBrowseButton.TabIndex = 27;
            this.RepoBrowseButton.Text = "Browse >>";
            this.RepoBrowseButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tools Repository";
            // 
            // Settings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 266);
            this.ControlBox = false;
            this.Controls.Add(this.RepoTextBox);
            this.Controls.Add(this.RepoBrowseButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LogFilesTextBox);
            this.Controls.Add(this.BrowseLogButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FamilyPathTextBox);
            this.Controls.Add(this.BrowseFamilyButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings_Form";
            this.Text = "Settings for User Preferences ";
            this.Load += new System.EventHandler(this.Settings_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BrowseFamilyButton;
        private System.Windows.Forms.TextBox FamilyPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LogFilesTextBox;
        private System.Windows.Forms.Button BrowseLogButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox RepoTextBox;
        private System.Windows.Forms.Button RepoBrowseButton;
        private System.Windows.Forms.Label label3;
    }
}
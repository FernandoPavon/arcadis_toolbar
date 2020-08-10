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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.AboutTextBox = new System.Windows.Forms.TextBox();
            this.TutorialsButton = new System.Windows.Forms.Button();
            this.ReferenceButton = new System.Windows.Forms.Button();
            this.UserButton = new System.Windows.Forms.Button();
            this.RevitVersionLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DynamicToolsLabel = new System.Windows.Forms.Label();
            this.MetricsTrackerLabel = new System.Windows.Forms.Label();
            this.ImportPanelLabel = new System.Windows.Forms.Label();
            this.ExportPanelLabel = new System.Windows.Forms.Label();
            this.ArcadisToolbarIILabel = new System.Windows.Forms.Label();
            this.ArcadisToolbarILabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(640, 493);
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
            this.TutorialsButton.Location = new System.Drawing.Point(45, 406);
            this.TutorialsButton.Name = "TutorialsButton";
            this.TutorialsButton.Size = new System.Drawing.Size(122, 23);
            this.TutorialsButton.TabIndex = 3;
            this.TutorialsButton.Text = "&Tutorials";
            this.TutorialsButton.UseVisualStyleBackColor = true;
            // 
            // ReferenceButton
            // 
            this.ReferenceButton.Location = new System.Drawing.Point(45, 435);
            this.ReferenceButton.Name = "ReferenceButton";
            this.ReferenceButton.Size = new System.Drawing.Size(122, 23);
            this.ReferenceButton.TabIndex = 4;
            this.ReferenceButton.Text = "&Reference Document";
            this.ReferenceButton.UseVisualStyleBackColor = true;
            // 
            // UserButton
            // 
            this.UserButton.Location = new System.Drawing.Point(45, 377);
            this.UserButton.Name = "UserButton";
            this.UserButton.Size = new System.Drawing.Size(122, 23);
            this.UserButton.TabIndex = 5;
            this.UserButton.Text = "&User Guide";
            this.UserButton.UseVisualStyleBackColor = true;
            // 
            // RevitVersionLabel
            // 
            this.RevitVersionLabel.AutoSize = true;
            this.RevitVersionLabel.Location = new System.Drawing.Point(6, 26);
            this.RevitVersionLabel.Name = "RevitVersionLabel";
            this.RevitVersionLabel.Size = new System.Drawing.Size(70, 13);
            this.RevitVersionLabel.TabIndex = 6;
            this.RevitVersionLabel.Text = "Revit Version";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DynamicToolsLabel);
            this.groupBox1.Controls.Add(this.MetricsTrackerLabel);
            this.groupBox1.Controls.Add(this.ImportPanelLabel);
            this.groupBox1.Controls.Add(this.ExportPanelLabel);
            this.groupBox1.Controls.Add(this.ArcadisToolbarIILabel);
            this.groupBox1.Controls.Add(this.ArcadisToolbarILabel);
            this.groupBox1.Controls.Add(this.RevitVersionLabel);
            this.groupBox1.Location = new System.Drawing.Point(211, 363);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 157);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Versions Loaded";
            // 
            // DynamicToolsLabel
            // 
            this.DynamicToolsLabel.AutoSize = true;
            this.DynamicToolsLabel.Location = new System.Drawing.Point(7, 130);
            this.DynamicToolsLabel.Name = "DynamicToolsLabel";
            this.DynamicToolsLabel.Size = new System.Drawing.Size(77, 13);
            this.DynamicToolsLabel.TabIndex = 12;
            this.DynamicToolsLabel.Text = "Dynamic Tools";
            // 
            // MetricsTrackerLabel
            // 
            this.MetricsTrackerLabel.AutoSize = true;
            this.MetricsTrackerLabel.Location = new System.Drawing.Point(7, 113);
            this.MetricsTrackerLabel.Name = "MetricsTrackerLabel";
            this.MetricsTrackerLabel.Size = new System.Drawing.Size(81, 13);
            this.MetricsTrackerLabel.TabIndex = 11;
            this.MetricsTrackerLabel.Text = "Metrics Tracker";
            // 
            // ImportPanelLabel
            // 
            this.ImportPanelLabel.AutoSize = true;
            this.ImportPanelLabel.Location = new System.Drawing.Point(7, 96);
            this.ImportPanelLabel.Name = "ImportPanelLabel";
            this.ImportPanelLabel.Size = new System.Drawing.Size(66, 13);
            this.ImportPanelLabel.TabIndex = 10;
            this.ImportPanelLabel.Text = "Import Panel";
            // 
            // ExportPanelLabel
            // 
            this.ExportPanelLabel.AutoSize = true;
            this.ExportPanelLabel.Location = new System.Drawing.Point(7, 79);
            this.ExportPanelLabel.Name = "ExportPanelLabel";
            this.ExportPanelLabel.Size = new System.Drawing.Size(67, 13);
            this.ExportPanelLabel.TabIndex = 9;
            this.ExportPanelLabel.Text = "Export Panel";
            // 
            // ArcadisToolbarIILabel
            // 
            this.ArcadisToolbarIILabel.AutoSize = true;
            this.ArcadisToolbarIILabel.Location = new System.Drawing.Point(7, 62);
            this.ArcadisToolbarIILabel.Name = "ArcadisToolbarIILabel";
            this.ArcadisToolbarIILabel.Size = new System.Drawing.Size(87, 13);
            this.ArcadisToolbarIILabel.TabIndex = 8;
            this.ArcadisToolbarIILabel.Text = "ArcadisToolbar II";
            // 
            // ArcadisToolbarILabel
            // 
            this.ArcadisToolbarILabel.AutoSize = true;
            this.ArcadisToolbarILabel.Location = new System.Drawing.Point(7, 43);
            this.ArcadisToolbarILabel.Name = "ArcadisToolbarILabel";
            this.ArcadisToolbarILabel.Size = new System.Drawing.Size(84, 13);
            this.ArcadisToolbarILabel.TabIndex = 7;
            this.ArcadisToolbarILabel.Text = "ArcadisToolbar I";
            // 
            // About_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 532);
            this.ControlBox = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label RevitVersionLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ArcadisToolbarILabel;
        private System.Windows.Forms.Label ArcadisToolbarIILabel;
        private System.Windows.Forms.Label DynamicToolsLabel;
        private System.Windows.Forms.Label MetricsTrackerLabel;
        private System.Windows.Forms.Label ImportPanelLabel;
        private System.Windows.Forms.Label ExportPanelLabel;
    }
}
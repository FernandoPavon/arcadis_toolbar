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
            this.DynCheckBox = new System.Windows.Forms.CheckBox();
            this.ImportDataCheckBox = new System.Windows.Forms.CheckBox();
            this.ExportDataCheckBox = new System.Windows.Forms.CheckBox();
            this.CableCheckBox = new System.Windows.Forms.CheckBox();
            this.ElectricalCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ArchitecturalCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.BrowseFamilyButton = new System.Windows.Forms.Button();
            this.FamilyPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LogFilesTextBox = new System.Windows.Forms.TextBox();
            this.BrowseLogButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ToolbarTreeView = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupSubs = new System.Windows.Forms.GroupBox();
            this.BridgesCheckBox = new System.Windows.Forms.CheckBox();
            this.StructuralCheckBox = new System.Windows.Forms.CheckBox();
            this.InfoTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupSubs.SuspendLayout();
            this.SuspendLayout();
            // 
            // DynCheckBox
            // 
            this.DynCheckBox.AutoSize = true;
            this.DynCheckBox.Location = new System.Drawing.Point(28, 139);
            this.DynCheckBox.Name = "DynCheckBox";
            this.DynCheckBox.Size = new System.Drawing.Size(96, 17);
            this.DynCheckBox.TabIndex = 6;
            this.DynCheckBox.Text = "Dynamic Tools";
            this.DynCheckBox.UseVisualStyleBackColor = true;
            this.DynCheckBox.CheckedChanged += new System.EventHandler(this.DynCheckBox_CheckedChanged);
            // 
            // ImportDataCheckBox
            // 
            this.ImportDataCheckBox.AutoSize = true;
            this.ImportDataCheckBox.Location = new System.Drawing.Point(28, 93);
            this.ImportDataCheckBox.Name = "ImportDataCheckBox";
            this.ImportDataCheckBox.Size = new System.Drawing.Size(81, 17);
            this.ImportDataCheckBox.TabIndex = 4;
            this.ImportDataCheckBox.Text = "Import Data";
            this.ImportDataCheckBox.UseVisualStyleBackColor = true;
            this.ImportDataCheckBox.CheckedChanged += new System.EventHandler(this.ImportDataCheckBox_CheckedChanged);
            // 
            // ExportDataCheckBox
            // 
            this.ExportDataCheckBox.AutoSize = true;
            this.ExportDataCheckBox.Location = new System.Drawing.Point(28, 116);
            this.ExportDataCheckBox.Name = "ExportDataCheckBox";
            this.ExportDataCheckBox.Size = new System.Drawing.Size(82, 17);
            this.ExportDataCheckBox.TabIndex = 3;
            this.ExportDataCheckBox.Text = "Export Data";
            this.ExportDataCheckBox.UseVisualStyleBackColor = true;
            this.ExportDataCheckBox.CheckedChanged += new System.EventHandler(this.ExportDataCheckBox_CheckedChanged);
            // 
            // CableCheckBox
            // 
            this.CableCheckBox.AutoSize = true;
            this.CableCheckBox.Location = new System.Drawing.Point(28, 24);
            this.CableCheckBox.Name = "CableCheckBox";
            this.CableCheckBox.Size = new System.Drawing.Size(82, 17);
            this.CableCheckBox.TabIndex = 3;
            this.CableCheckBox.Text = "Cable Tools";
            this.CableCheckBox.UseVisualStyleBackColor = true;
            this.CableCheckBox.CheckedChanged += new System.EventHandler(this.CableCheckBox_CheckedChanged);
            // 
            // ElectricalCheckBox
            // 
            this.ElectricalCheckBox.AutoSize = true;
            this.ElectricalCheckBox.Location = new System.Drawing.Point(28, 47);
            this.ElectricalCheckBox.Name = "ElectricalCheckBox";
            this.ElectricalCheckBox.Size = new System.Drawing.Size(98, 17);
            this.ElectricalCheckBox.TabIndex = 2;
            this.ElectricalCheckBox.Text = "Electrical Tools";
            this.ElectricalCheckBox.UseVisualStyleBackColor = true;
            this.ElectricalCheckBox.CheckedChanged += new System.EventHandler(this.ElectricalCheckBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DynCheckBox);
            this.groupBox2.Controls.Add(this.ElectricalCheckBox);
            this.groupBox2.Controls.Add(this.CableCheckBox);
            this.groupBox2.Controls.Add(this.ExportDataCheckBox);
            this.groupBox2.Controls.Add(this.ImportDataCheckBox);
            this.groupBox2.Controls.Add(this.ArchitecturalCheckbox);
            this.groupBox2.Location = new System.Drawing.Point(12, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 173);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tools to Load";
            // 
            // ArchitecturalCheckbox
            // 
            this.ArchitecturalCheckbox.AutoSize = true;
            this.ArchitecturalCheckbox.Checked = true;
            this.ArchitecturalCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ArchitecturalCheckbox.Enabled = false;
            this.ArchitecturalCheckbox.Location = new System.Drawing.Point(28, 70);
            this.ArchitecturalCheckbox.Name = "ArchitecturalCheckbox";
            this.ArchitecturalCheckbox.Size = new System.Drawing.Size(114, 17);
            this.ArchitecturalCheckbox.TabIndex = 0;
            this.ArchitecturalCheckbox.Text = "Architectural Tools";
            this.ArchitecturalCheckbox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton9);
            this.groupBox4.Controls.Add(this.radioButton8);
            this.groupBox4.Controls.Add(this.radioButton7);
            this.groupBox4.Location = new System.Drawing.Point(12, 150);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 100);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Geography";
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(28, 68);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(82, 17);
            this.radioButton9.TabIndex = 2;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "Netherlands";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(28, 44);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(100, 17);
            this.radioButton8.TabIndex = 1;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "United Kingdom";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(28, 20);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(65, 17);
            this.radioButton7.TabIndex = 0;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Australia";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // BrowseFamilyButton
            // 
            this.BrowseFamilyButton.Location = new System.Drawing.Point(14, 589);
            this.BrowseFamilyButton.Name = "BrowseFamilyButton";
            this.BrowseFamilyButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseFamilyButton.TabIndex = 0;
            this.BrowseFamilyButton.Text = "Browse >>";
            this.BrowseFamilyButton.UseVisualStyleBackColor = true;
            this.BrowseFamilyButton.Click += new System.EventHandler(this.BrowseFamilyButton_Click);
            // 
            // FamilyPathTextBox
            // 
            this.FamilyPathTextBox.Location = new System.Drawing.Point(96, 590);
            this.FamilyPathTextBox.Name = "FamilyPathTextBox";
            this.FamilyPathTextBox.Size = new System.Drawing.Size(549, 20);
            this.FamilyPathTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 570);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project Families:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 630);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Log Files:";
            // 
            // LogFilesTextBox
            // 
            this.LogFilesTextBox.Location = new System.Drawing.Point(96, 650);
            this.LogFilesTextBox.Name = "LogFilesTextBox";
            this.LogFilesTextBox.Size = new System.Drawing.Size(549, 20);
            this.LogFilesTextBox.TabIndex = 9;
            // 
            // BrowseLogButton
            // 
            this.BrowseLogButton.Location = new System.Drawing.Point(14, 649);
            this.BrowseLogButton.Name = "BrowseLogButton";
            this.BrowseLogButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseLogButton.TabIndex = 8;
            this.BrowseLogButton.Text = "Browse >>";
            this.BrowseLogButton.UseVisualStyleBackColor = true;
            this.BrowseLogButton.Click += new System.EventHandler(this.BrowseLogButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(570, 700);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 12;
            this.CloseButton.Text = "&Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ToolbarTreeView
            // 
            this.ToolbarTreeView.CheckBoxes = true;
            this.ToolbarTreeView.Location = new System.Drawing.Point(261, 42);
            this.ToolbarTreeView.Name = "ToolbarTreeView";
            this.ToolbarTreeView.Size = new System.Drawing.Size(384, 506);
            this.ToolbarTreeView.TabIndex = 13;
            this.ToolbarTreeView.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.ToolbarTreeView_BeforeCheck);
            this.ToolbarTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.ToolbarTreeView_AfterCheck);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Toolbar Visibility";
            // 
            // groupSubs
            // 
            this.groupSubs.Controls.Add(this.BridgesCheckBox);
            this.groupSubs.Controls.Add(this.StructuralCheckBox);
            this.groupSubs.Location = new System.Drawing.Point(12, 454);
            this.groupSubs.Name = "groupSubs";
            this.groupSubs.Size = new System.Drawing.Size(225, 94);
            this.groupSubs.TabIndex = 16;
            this.groupSubs.TabStop = false;
            this.groupSubs.Text = "Asset Type Subscrptions";
            // 
            // BridgesCheckBox
            // 
            this.BridgesCheckBox.AutoSize = true;
            this.BridgesCheckBox.Enabled = false;
            this.BridgesCheckBox.Location = new System.Drawing.Point(28, 50);
            this.BridgesCheckBox.Name = "BridgesCheckBox";
            this.BridgesCheckBox.Size = new System.Drawing.Size(121, 17);
            this.BridgesCheckBox.TabIndex = 4;
            this.BridgesCheckBox.Text = "Bridge Design Tools";
            this.BridgesCheckBox.UseVisualStyleBackColor = true;
            // 
            // StructuralCheckBox
            // 
            this.StructuralCheckBox.AutoSize = true;
            this.StructuralCheckBox.Enabled = false;
            this.StructuralCheckBox.Location = new System.Drawing.Point(28, 27);
            this.StructuralCheckBox.Name = "StructuralCheckBox";
            this.StructuralCheckBox.Size = new System.Drawing.Size(100, 17);
            this.StructuralCheckBox.TabIndex = 1;
            this.StructuralCheckBox.Text = "Structural Tools";
            this.StructuralCheckBox.UseVisualStyleBackColor = true;
            // 
            // InfoTextBox
            // 
            this.InfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoTextBox.Location = new System.Drawing.Point(12, 24);
            this.InfoTextBox.Multiline = true;
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.ReadOnly = true;
            this.InfoTextBox.Size = new System.Drawing.Size(243, 122);
            this.InfoTextBox.TabIndex = 18;
            // 
            // Settings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 750);
            this.ControlBox = false;
            this.Controls.Add(this.InfoTextBox);
            this.Controls.Add(this.groupSubs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ToolbarTreeView);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LogFilesTextBox);
            this.Controls.Add(this.BrowseLogButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FamilyPathTextBox);
            this.Controls.Add(this.BrowseFamilyButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings_Form";
            this.Text = "User Preferences ";
            this.Load += new System.EventHandler(this.Settings_Form_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupSubs.ResumeLayout(false);
            this.groupSubs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.Button BrowseFamilyButton;
        private System.Windows.Forms.TextBox FamilyPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LogFilesTextBox;
        private System.Windows.Forms.Button BrowseLogButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TreeView ToolbarTreeView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupSubs;
        private System.Windows.Forms.CheckBox CableCheckBox;
        private System.Windows.Forms.CheckBox ElectricalCheckBox;
        private System.Windows.Forms.CheckBox StructuralCheckBox;
        private System.Windows.Forms.CheckBox ArchitecturalCheckbox;
        private System.Windows.Forms.CheckBox BridgesCheckBox;
        private System.Windows.Forms.CheckBox ImportDataCheckBox;
        private System.Windows.Forms.CheckBox ExportDataCheckBox;
        private System.Windows.Forms.TextBox InfoTextBox;
        private System.Windows.Forms.CheckBox DynCheckBox;
    }
}
namespace ArcadisMain
{
    partial class Ribbon_Form
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
            this.groupSubs = new System.Windows.Forms.GroupBox();
            this.BridgesCheckBox = new System.Windows.Forms.CheckBox();
            this.StructuralCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ToolbarTreeView = new System.Windows.Forms.TreeView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DynCheckBox = new System.Windows.Forms.CheckBox();
            this.ElectricalCheckBox = new System.Windows.Forms.CheckBox();
            this.CableCheckBox = new System.Windows.Forms.CheckBox();
            this.ExportDataCheckBox = new System.Windows.Forms.CheckBox();
            this.ImportDataCheckBox = new System.Windows.Forms.CheckBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.groupSubs.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSubs
            // 
            this.groupSubs.Controls.Add(this.BridgesCheckBox);
            this.groupSubs.Controls.Add(this.StructuralCheckBox);
            this.groupSubs.Location = new System.Drawing.Point(323, 314);
            this.groupSubs.Name = "groupSubs";
            this.groupSubs.Size = new System.Drawing.Size(225, 106);
            this.groupSubs.TabIndex = 21;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Toolbar Loaded Tools";
            // 
            // ToolbarTreeView
            // 
            this.ToolbarTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ToolbarTreeView.Location = new System.Drawing.Point(15, 41);
            this.ToolbarTreeView.Name = "ToolbarTreeView";
            this.ToolbarTreeView.Size = new System.Drawing.Size(290, 436);
            this.ToolbarTreeView.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton9);
            this.groupBox4.Controls.Add(this.radioButton8);
            this.groupBox4.Controls.Add(this.radioButton7);
            this.groupBox4.Location = new System.Drawing.Point(323, 41);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 110);
            this.groupBox4.TabIndex = 18;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DynCheckBox);
            this.groupBox2.Controls.Add(this.ElectricalCheckBox);
            this.groupBox2.Controls.Add(this.CableCheckBox);
            this.groupBox2.Controls.Add(this.ExportDataCheckBox);
            this.groupBox2.Controls.Add(this.ImportDataCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(323, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 151);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tools Available to Load";
            // 
            // DynCheckBox
            // 
            this.DynCheckBox.AutoSize = true;
            this.DynCheckBox.Location = new System.Drawing.Point(28, 116);
            this.DynCheckBox.Name = "DynCheckBox";
            this.DynCheckBox.Size = new System.Drawing.Size(96, 17);
            this.DynCheckBox.TabIndex = 6;
            this.DynCheckBox.Text = "Dynamic Tools";
            this.DynCheckBox.UseVisualStyleBackColor = true;
            this.DynCheckBox.CheckedChanged += new System.EventHandler(this.DynCheckBox_CheckedChanged);
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
            // ExportDataCheckBox
            // 
            this.ExportDataCheckBox.AutoSize = true;
            this.ExportDataCheckBox.Location = new System.Drawing.Point(28, 93);
            this.ExportDataCheckBox.Name = "ExportDataCheckBox";
            this.ExportDataCheckBox.Size = new System.Drawing.Size(82, 17);
            this.ExportDataCheckBox.TabIndex = 3;
            this.ExportDataCheckBox.Text = "Export Data";
            this.ExportDataCheckBox.UseVisualStyleBackColor = true;
            this.ExportDataCheckBox.CheckedChanged += new System.EventHandler(this.ExportDataCheckBox_CheckedChanged);
            // 
            // ImportDataCheckBox
            // 
            this.ImportDataCheckBox.AutoSize = true;
            this.ImportDataCheckBox.Location = new System.Drawing.Point(28, 70);
            this.ImportDataCheckBox.Name = "ImportDataCheckBox";
            this.ImportDataCheckBox.Size = new System.Drawing.Size(81, 17);
            this.ImportDataCheckBox.TabIndex = 4;
            this.ImportDataCheckBox.Text = "Import Data";
            this.ImportDataCheckBox.UseVisualStyleBackColor = true;
            this.ImportDataCheckBox.CheckedChanged += new System.EventHandler(this.ImportDataCheckBox_CheckedChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(406, 454);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 22;
            this.CloseButton.Text = "&Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Ribbon_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 503);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.groupSubs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ToolbarTreeView);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "Ribbon_Form";
            this.Text = "Ribbon Tools Manager";
            this.Load += new System.EventHandler(this.Ribbon_Form_Load);
            this.groupSubs.ResumeLayout(false);
            this.groupSubs.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSubs;
        private System.Windows.Forms.CheckBox BridgesCheckBox;
        private System.Windows.Forms.CheckBox StructuralCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView ToolbarTreeView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox DynCheckBox;
        private System.Windows.Forms.CheckBox ElectricalCheckBox;
        private System.Windows.Forms.CheckBox CableCheckBox;
        private System.Windows.Forms.CheckBox ExportDataCheckBox;
        private System.Windows.Forms.CheckBox ImportDataCheckBox;
        private System.Windows.Forms.Button CloseButton;
    }
}
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
            this.label3 = new System.Windows.Forms.Label();
            this.ToolbarTreeView = new System.Windows.Forms.TreeView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ToolsFolderTextBox = new System.Windows.Forms.TextBox();
            this.ToolsBrowseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolsListView = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCurrentVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.RepoBrowseButton = new System.Windows.Forms.Button();
            this.RepoTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.colRepoVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DefaultButton = new System.Windows.Forms.Button();
            this.DefaultRepoPathButton = new System.Windows.Forms.Button();
            this.LoadToolsButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.RevitVersionLabel = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(580, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Toolbar Loaded Tools";
            // 
            // ToolbarTreeView
            // 
            this.ToolbarTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolbarTreeView.Location = new System.Drawing.Point(583, 43);
            this.ToolbarTreeView.Name = "ToolbarTreeView";
            this.ToolbarTreeView.Size = new System.Drawing.Size(250, 440);
            this.ToolbarTreeView.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton9);
            this.groupBox4.Controls.Add(this.radioButton8);
            this.groupBox4.Controls.Add(this.radioButton7);
            this.groupBox4.Location = new System.Drawing.Point(583, 549);
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
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(667, 514);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 22;
            this.CloseButton.Text = "&Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ToolsFolderTextBox
            // 
            this.ToolsFolderTextBox.Location = new System.Drawing.Point(104, 62);
            this.ToolsFolderTextBox.Name = "ToolsFolderTextBox";
            this.ToolsFolderTextBox.Size = new System.Drawing.Size(374, 20);
            this.ToolsFolderTextBox.TabIndex = 25;
            // 
            // ToolsBrowseButton
            // 
            this.ToolsBrowseButton.Location = new System.Drawing.Point(23, 60);
            this.ToolsBrowseButton.Name = "ToolsBrowseButton";
            this.ToolsBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.ToolsBrowseButton.TabIndex = 24;
            this.ToolsBrowseButton.Text = "Browse >>";
            this.ToolsBrowseButton.UseVisualStyleBackColor = true;
            this.ToolsBrowseButton.Click += new System.EventHandler(this.ToolsBrowseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tools Folder";
            // 
            // ToolsListView
            // 
            this.ToolsListView.BackColor = System.Drawing.SystemColors.Info;
            this.ToolsListView.CheckBoxes = true;
            this.ToolsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colCurrentVersion,
            this.colRepoVersion});
            this.ToolsListView.HideSelection = false;
            this.ToolsListView.Location = new System.Drawing.Point(23, 193);
            this.ToolsListView.Name = "ToolsListView";
            this.ToolsListView.Size = new System.Drawing.Size(537, 290);
            this.ToolsListView.TabIndex = 26;
            this.ToolsListView.UseCompatibleStateImageBehavior = false;
            this.ToolsListView.View = System.Windows.Forms.View.Details;
            this.ToolsListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ToolsListView_ItemChecked);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 140;
            // 
            // colCurrentVersion
            // 
            this.colCurrentVersion.Text = "Current Version";
            this.colCurrentVersion.Width = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Select tools to load:";
            // 
            // RepoBrowseButton
            // 
            this.RepoBrowseButton.Location = new System.Drawing.Point(23, 110);
            this.RepoBrowseButton.Name = "RepoBrowseButton";
            this.RepoBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.RepoBrowseButton.TabIndex = 28;
            this.RepoBrowseButton.Text = "Browse >>";
            this.RepoBrowseButton.UseVisualStyleBackColor = true;
            this.RepoBrowseButton.Click += new System.EventHandler(this.RepoBrowseButton_Click);
            // 
            // RepoTextBox
            // 
            this.RepoTextBox.Location = new System.Drawing.Point(104, 112);
            this.RepoTextBox.Name = "RepoTextBox";
            this.RepoTextBox.Size = new System.Drawing.Size(374, 20);
            this.RepoTextBox.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Repository";
            // 
            // UpdateCheckBox
            // 
            this.UpdateCheckBox.AutoSize = true;
            this.UpdateCheckBox.Location = new System.Drawing.Point(154, 171);
            this.UpdateCheckBox.Name = "UpdateCheckBox";
            this.UpdateCheckBox.Size = new System.Drawing.Size(156, 17);
            this.UpdateCheckBox.TabIndex = 31;
            this.UpdateCheckBox.Text = "Update tools before loading";
            this.UpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // colRepoVersion
            // 
            this.colRepoVersion.Text = "Repository Version";
            this.colRepoVersion.Width = 120;
            // 
            // DefaultButton
            // 
            this.DefaultButton.Location = new System.Drawing.Point(484, 59);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(75, 23);
            this.DefaultButton.TabIndex = 32;
            this.DefaultButton.Text = "Default Path";
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // DefaultRepoPathButton
            // 
            this.DefaultRepoPathButton.Location = new System.Drawing.Point(485, 109);
            this.DefaultRepoPathButton.Name = "DefaultRepoPathButton";
            this.DefaultRepoPathButton.Size = new System.Drawing.Size(75, 23);
            this.DefaultRepoPathButton.TabIndex = 33;
            this.DefaultRepoPathButton.Text = "Default Path";
            this.DefaultRepoPathButton.UseVisualStyleBackColor = true;
            this.DefaultRepoPathButton.Click += new System.EventHandler(this.DefaultRepoPathButton_Click);
            // 
            // LoadToolsButton
            // 
            this.LoadToolsButton.Location = new System.Drawing.Point(456, 514);
            this.LoadToolsButton.Name = "LoadToolsButton";
            this.LoadToolsButton.Size = new System.Drawing.Size(103, 23);
            this.LoadToolsButton.TabIndex = 34;
            this.LoadToolsButton.Text = "Load Tools";
            this.LoadToolsButton.UseVisualStyleBackColor = true;
            this.LoadToolsButton.Click += new System.EventHandler(this.LoadToolsButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(349, 514);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(102, 23);
            this.DeleteButton.TabIndex = 35;
            this.DeleteButton.Text = "Remove Tools";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // RevitVersionLabel
            // 
            this.RevitVersionLabel.AutoSize = true;
            this.RevitVersionLabel.Location = new System.Drawing.Point(20, 9);
            this.RevitVersionLabel.Name = "RevitVersionLabel";
            this.RevitVersionLabel.Size = new System.Drawing.Size(73, 13);
            this.RevitVersionLabel.TabIndex = 36;
            this.RevitVersionLabel.Text = "Revit Version:";
            // 
            // Ribbon_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 549);
            this.ControlBox = false;
            this.Controls.Add(this.RevitVersionLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.LoadToolsButton);
            this.Controls.Add(this.DefaultRepoPathButton);
            this.Controls.Add(this.DefaultButton);
            this.Controls.Add(this.UpdateCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RepoTextBox);
            this.Controls.Add(this.RepoBrowseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ToolsListView);
            this.Controls.Add(this.ToolsFolderTextBox);
            this.Controls.Add(this.ToolsBrowseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ToolbarTreeView);
            this.Controls.Add(this.groupBox4);
            this.Name = "Ribbon_Form";
            this.Text = "Ribbon Tools Manager";
            this.Load += new System.EventHandler(this.Ribbon_Form_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView ToolbarTreeView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox ToolsFolderTextBox;
        private System.Windows.Forms.Button ToolsBrowseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView ToolsListView;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colCurrentVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RepoBrowseButton;
        private System.Windows.Forms.TextBox RepoTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox UpdateCheckBox;
        private System.Windows.Forms.ColumnHeader colRepoVersion;
        private System.Windows.Forms.Button DefaultButton;
        private System.Windows.Forms.Button DefaultRepoPathButton;
        private System.Windows.Forms.Button LoadToolsButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label RevitVersionLabel;
    }
}
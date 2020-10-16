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
            this.ToolsFolderTextBox = new System.Windows.Forms.TextBox();
            this.ToolsBrowseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolsListView = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCurrentVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRepoVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.RepoBrowseButton = new System.Windows.Forms.Button();
            this.RepoTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DefaultButton = new System.Windows.Forms.Button();
            this.DefaultRepoPathButton = new System.Windows.Forms.Button();
            this.LoadToolsButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.RevitVersionLabel = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.UnloadToolsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(605, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Toolbar Loaded Tools";
            // 
            // ToolbarTreeView
            // 
            this.ToolbarTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolbarTreeView.Location = new System.Drawing.Point(608, 36);
            this.ToolbarTreeView.Name = "ToolbarTreeView";
            this.ToolbarTreeView.Size = new System.Drawing.Size(250, 483);
            this.ToolbarTreeView.TabIndex = 19;
            // 
            // ToolsFolderTextBox
            // 
            this.ToolsFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolsFolderTextBox.Location = new System.Drawing.Point(102, 113);
            this.ToolsFolderTextBox.Name = "ToolsFolderTextBox";
            this.ToolsFolderTextBox.Size = new System.Drawing.Size(398, 20);
            this.ToolsFolderTextBox.TabIndex = 25;
            // 
            // ToolsBrowseButton
            // 
            this.ToolsBrowseButton.Location = new System.Drawing.Point(21, 111);
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
            this.label1.Location = new System.Drawing.Point(97, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tools Folder";
            // 
            // ToolsListView
            // 
            this.ToolsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolsListView.BackColor = System.Drawing.SystemColors.Info;
            this.ToolsListView.CheckBoxes = true;
            this.ToolsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colCurrentVersion,
            this.colRepoVersion});
            this.ToolsListView.HideSelection = false;
            this.ToolsListView.Location = new System.Drawing.Point(24, 186);
            this.ToolsListView.Name = "ToolsListView";
            this.ToolsListView.Size = new System.Drawing.Size(416, 333);
            this.ToolsListView.TabIndex = 26;
            this.ToolsListView.UseCompatibleStateImageBehavior = false;
            this.ToolsListView.View = System.Windows.Forms.View.Details;
            this.ToolsListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ToolsListView_ItemChecked);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 170;
            // 
            // colCurrentVersion
            // 
            this.colCurrentVersion.Text = "Current Version";
            this.colCurrentVersion.Width = 120;
            // 
            // colRepoVersion
            // 
            this.colRepoVersion.Text = "Repository Version";
            this.colRepoVersion.Width = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Select Tool Modules";
            // 
            // RepoBrowseButton
            // 
            this.RepoBrowseButton.Location = new System.Drawing.Point(21, 56);
            this.RepoBrowseButton.Name = "RepoBrowseButton";
            this.RepoBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.RepoBrowseButton.TabIndex = 28;
            this.RepoBrowseButton.Text = "Browse >>";
            this.RepoBrowseButton.UseVisualStyleBackColor = true;
            this.RepoBrowseButton.Click += new System.EventHandler(this.RepoBrowseButton_Click);
            // 
            // RepoTextBox
            // 
            this.RepoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RepoTextBox.Location = new System.Drawing.Point(102, 58);
            this.RepoTextBox.Name = "RepoTextBox";
            this.RepoTextBox.Size = new System.Drawing.Size(398, 20);
            this.RepoTextBox.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Repository";
            // 
            // DefaultButton
            // 
            this.DefaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultButton.Location = new System.Drawing.Point(506, 112);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(75, 23);
            this.DefaultButton.TabIndex = 32;
            this.DefaultButton.Text = "Default Path";
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // DefaultRepoPathButton
            // 
            this.DefaultRepoPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultRepoPathButton.Location = new System.Drawing.Point(507, 57);
            this.DefaultRepoPathButton.Name = "DefaultRepoPathButton";
            this.DefaultRepoPathButton.Size = new System.Drawing.Size(75, 23);
            this.DefaultRepoPathButton.TabIndex = 33;
            this.DefaultRepoPathButton.Text = "Default Path";
            this.DefaultRepoPathButton.UseVisualStyleBackColor = true;
            this.DefaultRepoPathButton.Click += new System.EventHandler(this.DefaultRepoPathButton_Click);
            // 
            // LoadToolsButton
            // 
            this.LoadToolsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadToolsButton.Location = new System.Drawing.Point(457, 223);
            this.LoadToolsButton.Name = "LoadToolsButton";
            this.LoadToolsButton.Size = new System.Drawing.Size(126, 23);
            this.LoadToolsButton.TabIndex = 34;
            this.LoadToolsButton.Text = "Load Selected Tools";
            this.LoadToolsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoadToolsButton.UseVisualStyleBackColor = true;
            this.LoadToolsButton.Click += new System.EventHandler(this.LoadToolsButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(457, 364);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(126, 23);
            this.DeleteButton.TabIndex = 35;
            this.DeleteButton.Text = "Delete Selected Tools";
            this.DeleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // RevitVersionLabel
            // 
            this.RevitVersionLabel.AutoSize = true;
            this.RevitVersionLabel.Location = new System.Drawing.Point(21, 19);
            this.RevitVersionLabel.Name = "RevitVersionLabel";
            this.RevitVersionLabel.Size = new System.Drawing.Size(73, 13);
            this.RevitVersionLabel.TabIndex = 36;
            this.RevitVersionLabel.Text = "Revit Version:";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateButton.Location = new System.Drawing.Point(456, 319);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(125, 23);
            this.UpdateButton.TabIndex = 37;
            this.UpdateButton.Text = "Update Selected Tools";
            this.UpdateButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // UnloadToolsButton
            // 
            this.UnloadToolsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UnloadToolsButton.Location = new System.Drawing.Point(457, 271);
            this.UnloadToolsButton.Name = "UnloadToolsButton";
            this.UnloadToolsButton.Size = new System.Drawing.Size(125, 23);
            this.UnloadToolsButton.TabIndex = 38;
            this.UnloadToolsButton.Text = "Unload Selected Tools";
            this.UnloadToolsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UnloadToolsButton.UseVisualStyleBackColor = true;
            this.UnloadToolsButton.Click += new System.EventHandler(this.UnloadToolsButton_Click);
            // 
            // Ribbon_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 547);
            this.Controls.Add(this.UnloadToolsButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.RevitVersionLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.LoadToolsButton);
            this.Controls.Add(this.DefaultRepoPathButton);
            this.Controls.Add(this.DefaultButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RepoTextBox);
            this.Controls.Add(this.RepoBrowseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ToolsListView);
            this.Controls.Add(this.ToolsFolderTextBox);
            this.Controls.Add(this.ToolsBrowseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ToolbarTreeView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ribbon_Form";
            this.Text = "Ribbon Tools Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ribbon_Form_FormClosing);
            this.Load += new System.EventHandler(this.Ribbon_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView ToolbarTreeView;
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
        private System.Windows.Forms.ColumnHeader colRepoVersion;
        private System.Windows.Forms.Button DefaultButton;
        private System.Windows.Forms.Button DefaultRepoPathButton;
        private System.Windows.Forms.Button LoadToolsButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label RevitVersionLabel;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button UnloadToolsButton;
    }
}
namespace ArcadisMain
{
    partial class VersionsForm
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
            this.ModulesListView = new System.Windows.Forms.ListView();
            this.colModule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRepo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCurrent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.DoNotUpdateButton = new System.Windows.Forms.Button();
            this.UpgradeButton = new System.Windows.Forms.Button();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ModulesListView
            // 
            this.ModulesListView.BackColor = System.Drawing.SystemColors.Info;
            this.ModulesListView.CheckBoxes = true;
            this.ModulesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colModule,
            this.colRepo,
            this.colCurrent});
            this.ModulesListView.GridLines = true;
            this.ModulesListView.Location = new System.Drawing.Point(12, 95);
            this.ModulesListView.Name = "ModulesListView";
            this.ModulesListView.Size = new System.Drawing.Size(449, 263);
            this.ModulesListView.TabIndex = 6;
            this.ModulesListView.UseCompatibleStateImageBehavior = false;
            this.ModulesListView.View = System.Windows.Forms.View.Details;
            // 
            // colModule
            // 
            this.colModule.Text = "Assembly Module";
            this.colModule.Width = 200;
            // 
            // colRepo
            // 
            this.colRepo.Text = "New Version";
            this.colRepo.Width = 120;
            // 
            // colCurrent
            // 
            this.colCurrent.Text = "Current Version";
            this.colCurrent.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select assembly modules to update:";
            // 
            // DoNotUpdateButton
            // 
            this.DoNotUpdateButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DoNotUpdateButton.Location = new System.Drawing.Point(53, 382);
            this.DoNotUpdateButton.Name = "DoNotUpdateButton";
            this.DoNotUpdateButton.Size = new System.Drawing.Size(158, 23);
            this.DoNotUpdateButton.TabIndex = 8;
            this.DoNotUpdateButton.Text = "Do Not Update";
            this.DoNotUpdateButton.UseVisualStyleBackColor = true;
            this.DoNotUpdateButton.Click += new System.EventHandler(this.DoNotUpdateButton_Click);
            // 
            // UpgradeButton
            // 
            this.UpgradeButton.Location = new System.Drawing.Point(251, 382);
            this.UpgradeButton.Name = "UpgradeButton";
            this.UpgradeButton.Size = new System.Drawing.Size(167, 23);
            this.UpgradeButton.TabIndex = 9;
            this.UpgradeButton.Text = "Upgrate Selected Modules";
            this.UpgradeButton.UseVisualStyleBackColor = true;
            this.UpgradeButton.Click += new System.EventHandler(this.UpgradeButton_Click);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Enabled = false;
            this.MessageTextBox.Location = new System.Drawing.Point(12, 12);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ReadOnly = true;
            this.MessageTextBox.Size = new System.Drawing.Size(449, 61);
            this.MessageTextBox.TabIndex = 11;
            // 
            // VersionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 449);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.UpgradeButton);
            this.Controls.Add(this.DoNotUpdateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ModulesListView);
            this.Name = "VersionsForm";
            this.Text = "Revit Version Manager";
            this.Load += new System.EventHandler(this.VersionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ModulesListView;
        private System.Windows.Forms.ColumnHeader colModule;
        private System.Windows.Forms.ColumnHeader colRepo;
        private System.Windows.Forms.ColumnHeader colCurrent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DoNotUpdateButton;
        private System.Windows.Forms.Button UpgradeButton;
        private System.Windows.Forms.TextBox MessageTextBox;
    }
}
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Autodesk.Revit.UI;


namespace ArcadisMain
{
    public partial class VersionsForm : Form
    {
        private string m_revitAddinPath;
        private string m_repositoryPath;
        private IList<AssemblyVersions> newAssemblies;

        public string RevitAddInPath { set { m_revitAddinPath = value; } }
        public string RepositoryPath { set { m_repositoryPath = value; } }

        public IList<AssemblyVersions> NewAssemblies { set {newAssemblies = value; } }

        public VersionsForm()
        {
            InitializeComponent();
        }

        private void VersionsForm_Load(object sender, EventArgs e)
        {
            MessageTextBox.Text = "New versions or Arcadis Tools are available. Select modules to update.";

            string[] items = new string[3];

            foreach(AssemblyVersions assembly in newAssemblies)
            {
                items[0] = Path.GetFileNameWithoutExtension(assembly.AssemblyName);
                items[1] = assembly.RepositoryVersion;
                items[2] = assembly.CurrentVersion;

                Metrics.AppendLog("Assembly:" + items[0] + " Repository Version: " +  items[1] + " Current Version: " +  items[2]);

                ListViewItem viewItem = new ListViewItem(items);
                viewItem.Checked = true;
                ModulesListView.Items.Add(viewItem);

            }
        }

        private void DoNotUpdateButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpgradeButton_Click(object sender, EventArgs e)
        {
            TaskDialogResult result = TaskDialog.Show("Update Moduleds", "Please confirm to update Arcadis Tools.", TaskDialogCommonButtons.Cancel & TaskDialogCommonButtons.Ok);

            if (result == TaskDialogResult.Ok)
            {
                foreach (ListViewItem module in ModulesListView.CheckedItems)
                {
                    string repoFile = Path.Combine(m_repositoryPath, module.SubItems[0].Text + ".dll");
                    string revitFile = Path.Combine(m_revitAddinPath, module.SubItems[0].Text + ".dll");
                    File.Copy(repoFile, revitFile, true);

                    repoFile = Path.Combine(m_repositoryPath, module.SubItems[0].Text + ".addin");
                    revitFile = Path.Combine(m_revitAddinPath, module.SubItems[0].Text + ".addin");
                    File.Copy(repoFile, revitFile, true);

                    Metrics.AppendLog("Assembly:" + module.SubItems[0].Text + " updated");
                }
            }
            else
            {
                Metrics.AppendLog("No updates selected.");
            }

            Close();
        }
    }
}

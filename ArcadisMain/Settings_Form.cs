using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace ArcadisMain
{
    public partial class Settings_Form : System.Windows.Forms.Form
    {
        Document m_doc;

        public Document Document { set { m_doc = value; } }

        public Settings_Form()
        {
            InitializeComponent();
        }

        private void Settings_Form_Load(object sender, EventArgs e)
        {
            //Get Document Preferences
            //------------------------
            Utils.CheckCreateProjectParameter(m_doc, "DocPreferences", BuiltInCategory.OST_ProjectInformation);
            Parameter par = m_doc.ProjectInformation.LookupParameter("DocPreferences");

            string json = par.AsString();
            if(null != json)
            {
                DocPreferences docPreferences = new JavaScriptSerializer().Deserialize<DocPreferences>(json);
                FamilyPathTextBox.Text = docPreferences.FamilyPath;
                LogFilesTextBox.Text = docPreferences.LogPath;
                
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {

            //Save Document Preferences
            //-------------------------
            DocPreferences docPreferences = new DocPreferences();
            docPreferences.FamilyPath = FamilyPathTextBox.Text;
            docPreferences.LogPath = LogFilesTextBox.Text;
            

            Parameter par = m_doc.ProjectInformation.LookupParameter("DocPreferences");
            string json = new JavaScriptSerializer().Serialize(docPreferences);

            Transaction tx = new Transaction(m_doc);
            tx.Start("Project Information");
            par.Set(json);
            tx.Commit();

            this.Close();
        }

    
        private void BrowseFamilyButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    FamilyPathTextBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void BrowseLogButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    LogFilesTextBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void RepoBrowseButton_Click(object sender, EventArgs e)
        {

        }
    }
}

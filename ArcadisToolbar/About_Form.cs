using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace ArcadisToolbar_I
{
   

    public partial class About_Form : System.Windows.Forms.Form
    {
        public Document m_doc;

        public About_Form()
        {
            InitializeComponent();
        }

        private void About_Form_Load(object sender, EventArgs e)
        {
            AboutTextBox.Text = "Copyright 2020 Autodesk, Inc. All rights reserved. " +
                "\r\n\r\nTHE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR" +
                "\r\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY," +
                "\r\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE" +
                "\r\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER" +
                "\r\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM," +
                "\r\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE." +
                "\r\n\r\nAutodesk" +
                "\r\nCustomer Services Organisation" +
                "\r\nFarnborough" +
                "\r\nFernando Pavon" +
                "\r\nfernando.pavon@autodesk.com" +
                "\r\nVersion 0.0.0.1" +
                "\r\n1 July 2020";

#if (Revit2018)
            RevitVersionLabel.Text = "Revit Version 2018";
#elif (Revit2019)
            RevitVersionLabel.Text = "Revit Version 2019";
#elif (Revit2020)
            RevitVersionLabel.Text = "Revit Version 2020";
#endif

            
            if (Utils.g_old_arcadisToolbar_I_Version != Utils.g_arcadisToolbar_I_Version)
            {
                ArcadisToolbarILabel.Text = "(New) Arcadis Tollbar I Version: " + Utils.g_arcadisToolbar_I_Version;
                ArcadisToolbarILabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                ArcadisToolbarILabel.Text = "Arcadis Tollbar I Version: " + Utils.g_arcadisToolbar_I_Version;
            }
                
            ArcadisToolbarIILabel.Text = "Arcadis Tollbar II Version: " + Utils.g_arcadisToolbar_II_Version;
            ExportPanelLabel.Text = "Export Panel Version: " + Utils.g_ExportPanel_Version;
            ImportPanelLabel.Text = "Import Panel Version: " + Utils.g_ImportPanel_Version;
            MetricsTrackerLabel.Text = "Metrics Tracker Version: " + Utils.g_MetricsTracker_Version;
            DynamicToolsLabel.Text = "Dynamic Tools Version: " + Utils.g_DynamicTools_Version;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            Parameter parBin = m_doc.ProjectInformation.LookupParameter("MyBinaryData");

            string ver = parBin.AsString();

            BinaryVersions binVersions = DeserializeBinaryData(ver);
        }

        private BinaryVersions DeserializeBinaryData(string strVer)
        {
            try
            {
                MemoryStream s = new MemoryStream(Convert.FromBase64String(strVer));
                s.Position = 0;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Binder = new JtLinkBinder();

                return bf.Deserialize(s) as BinaryVersions;

            }
            catch (Exception ex)
            {
                string mess = ex.Message;
                return null;
            }
        }
    }
}

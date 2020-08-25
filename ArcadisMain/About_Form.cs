using System;
using System.Windows.Media;
using Autodesk.Revit.DB;

namespace ArcadisMain
{
    public partial class About_Form : System.Windows.Forms.Form
    {
        public Document m_doc;
        string revitVersion;

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
            revitVersion = "Revit Version 2018";
#elif (Revit2019)
            revitVersion = "Revit Version 2019";
#elif (Revit2020)
            revitVersion = "Revit Version 2020";
#endif
            InfoTextBox.AppendText("\u2022Revit Version: " + Utils.k_revitVersion);
            InfoTextBox.AppendText("\r\n\r\n\u2022Revit Language: " + Utils.k_revitLanguage);
            InfoTextBox.AppendText("\r\n\r\n\u2022System Country: " + Utils.k_systemCountry);
            InfoTextBox.AppendText("\r\n\r\n\u2022System Language: " + Utils.k_systemLanguage);

            //VersionsTextBox.AppendText("\u2022" + revitVersion);

            string strGeo = string.Empty;

            foreach (AssemblyVersion assembly in Utils.s_assemblies)
            {
                if (assembly.Geography != "")
                {
                    strGeo = assembly.Geography;
                }
                else
                {
                    strGeo = "";
                }
                string line = "\u2022" + assembly.AssemblyName + "  Version: " + assembly.CurrentVersion + " " + strGeo + "\r\n\r\n";
                VersionsTextBox.AppendText(line);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

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
        bool isLoading = true;
        Document m_doc;

        public Document Document { set { m_doc = value; } }

        public Settings_Form()
        {
            InitializeComponent();
        }

        private void Settings_Form_Load(object sender, EventArgs e)
        {

            InfoTextBox.AppendText("\u2022System Country: " + Utils.k_systemCountry);
            InfoTextBox.AppendText("\r\n\r\n\u2022System Language: " + Utils.k_systemLanguage);
            InfoTextBox.AppendText("\r\n\r\n\u2022Revit Version: " + Utils.k_revitVersion);
            InfoTextBox.AppendText("\r\n\r\n\u2022Revit Language: " + Utils.k_revitLanguage);

            TreeViewFromRibbon();

            MainUserPreferences up = MainUserPreferences.GetUserPreferences();
            CableCheckBox.Checked = up.CableCheckBox;
            DynCheckBox.Checked = up.DynamicCheckBox;
            ElectricalCheckBox.Checked = up.ElectricalCheckBox;
            ExportDataCheckBox.Checked = up.ExportDataCheckBox;
            ImportDataCheckBox.Checked = up.ImportDataCheckBox;

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

        private void TreeViewFromRibbon()
        {
            isLoading = true;

            Size size = new Size(20, 20);
            Image image;
            ImageList imageList = new ImageList();

            imageList.ImageSize = size; // Size(44, 16);
            image = Properties.Resources.Tab20; //.Tab40;
            imageList.Images.Add(image);
            image = Properties.Resources.Panel20; //.Panel44;
            imageList.Images.Add(image);

            foreach (ToolbarTab tab in Utils.s_arcadisRibbon.Tabs)
            {
                foreach (ToolbarPanel panel in tab.Panels)
                {
                    foreach (ToolbarCommand com in panel.Commands)
                    {
                        image = com.Bitmap;
                        imageList.Images.Add(image);
                    }
                }
            }

            ToolbarTreeView.ImageList = imageList;
            ToolbarTreeView.Indent = 20;
            ToolbarTreeView.ItemHeight = 30;

            ToolbarTreeView.Nodes.Clear();

            int index = 2;

            foreach (ToolbarTab tab in Utils.s_arcadisRibbon.Tabs)
            {
                TreeNode nodeTab = ToolbarTreeView.Nodes.Add(tab.TabName, tab.TabName);
                nodeTab.ImageIndex = 0;
                nodeTab.SelectedImageIndex = 0;
                nodeTab.NodeFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                nodeTab.Text = nodeTab.Text;
                nodeTab.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);

                if (tab.TabName == Utils.k_arcadisMainTab)
                {
                    nodeTab.Checked = true;
                }
                else
                {
                    nodeTab.Checked = tab.RibbonTab.IsVisible;
                }

                foreach (ToolbarPanel panel in tab.Panels)
                {
                    TreeNode nodePanel = nodeTab.Nodes.Add(panel.PanelName, panel.PanelName);
                    nodePanel.Checked = panel.Panel.Visible;
                    nodePanel.ImageIndex = 1;
                    nodePanel.SelectedImageIndex = 1;
                    nodePanel.NodeFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);

                    foreach (ToolbarCommand com in panel.Commands)
                    {
                        TreeNode nodeCommand = nodePanel.Nodes.Add(com.CommandName, com.CommandName);
                        nodeCommand.Checked = com.Command.Visible;
                        
                        nodeCommand.ImageIndex = index;
                        nodeCommand.SelectedImageIndex = index;
                        nodeCommand.NodeFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                        index++;
                    }
                }
            }

            ToolbarTreeView.ExpandAll();
            isLoading = false;
        }

        private void ApplyRibbon()
        {
            RibbonVisibility ribbonVisibility = new RibbonVisibility();

            foreach (ToolbarTab tab in Utils.s_arcadisRibbon.Tabs)
            {
                bool tabCheck = true;

                TreeNode nodeTab = ToolbarTreeView.Nodes.Find(tab.TabName, false).First();
                if (tab.TabName == Utils.k_arcadisMainTab)
                {
                    tabCheck = true;
                }
                else
                {
                    tabCheck = nodeTab.Checked;
                }

                TabVis tabVis = new TabVis(tab.TabName, tabCheck);// nodeTab.Checked);
                ribbonVisibility.Tabs.Add(tabVis);
                tab.RibbonTab.IsVisible = tabCheck;

                foreach (ToolbarPanel panel in tab.Panels)
                {
                    TreeNode nodePanel = nodeTab.Nodes.Find(panel.PanelName, false).First();
                    PanelVis panelCurrent = new PanelVis(panel.PanelName, nodePanel.Checked);
                    tabVis.Panels.Add(panelCurrent);
                    panel.Panel.Visible = nodePanel.Checked;

                    foreach (ToolbarCommand com in panel.Commands)
                    {
                        TreeNode nodeCommand = nodePanel.Nodes.Find(com.CommandName, false).First();
                        CommandVis commandCurrent = new CommandVis(com.CommandName, nodeCommand.Checked);
                        panelCurrent.Commands.Add(commandCurrent);
                        com.Command.Visible = nodeCommand.Checked;
                    }
                }
            }

            string jsonOut = new JavaScriptSerializer().Serialize(ribbonVisibility);
            Properties.Settings.Default.Toolbar_UserPreferences = jsonOut;
            Properties.Settings.Default.Save();

            ToolbarTreeView.ExpandAll();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            ApplyRibbon();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            //Save User Preferences
            //---------------------
            MainUserPreferences up = new MainUserPreferences();
            up.CableCheckBox = CableCheckBox.Checked;
            up.DynamicCheckBox = DynCheckBox.Checked;
            up.ElectricalCheckBox = ElectricalCheckBox.Checked;
            up.ExportDataCheckBox = ExportDataCheckBox.Checked;
            up.ImportDataCheckBox = ImportDataCheckBox.Checked;

            MainUserPreferences.SaveUserPreferences(up);

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

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void ToolbarTreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (isLoading) return;

            if (e.Node.Text == Utils.k_arcadisMainTab)
            {
                TaskDialog.Show("Information", "The Tab " + Utils.k_arcadisMainTab + " cannot be unchecked.");
                e.Cancel=true;
                return;
            }
            
            if (e.Node.Text == Utils.k_arcadisPanel)
            {
                TaskDialog.Show("Information", "The Panel " + Utils.k_arcadisPanel + " cannot be unchecked.");
                e.Cancel = true;
                return;
            }

            if (e.Node.Text == Utils.k_settings)
            {
                TaskDialog.Show("Information", "The Command" + Utils.k_settings + " cannot be unchecked.");
                e.Cancel = true;
            }
            
        }

        private void ToolbarTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (isLoading) return;
            if (e.Action == TreeViewAction.Unknown) return;

            if (e.Node.Nodes.Count > 0)
            {
                this.CheckAllChildNodes(e.Node, e.Node.Checked);
            }

            ApplyRibbon();
        }

        private void ElectricalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ElectricalCheckBox.Checked)
            {
                if (Utils.b_electricalTools != true)
                {
                    try
                    {
                        Utils.b_electricalTools = Utils.LoadAddin(Utils.k_electricalAddin, Utils.b_electricalTools);
                    }
                    catch (Exception ex)
                    {
                        Metrics.AppendLog("Exception in loading Electrical Addin:\r\n" + ex.Message);
                    }
                }
                CheckPanel(Utils.k_arcadisMainTab, Utils.k_electricalPanel, true);
            }
            else
            {
                CheckPanel(Utils.k_arcadisMainTab, Utils.k_electricalPanel, false);
            }
            ApplyRibbon();
            TreeViewFromRibbon();
        }

        private void CableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CableCheckBox.Checked)
            {
                if (Utils.b_cableTools != true)
                {
                    try
                    {
                        Utils.b_cableTools = Utils.LoadAddin(Utils.k_cableAddin, Utils.b_cableTools);
                    }
                    catch (Exception ex)
                    {
                        Metrics.AppendLog("Exception in loading Cable Addin:\r\n" + ex.Message);
                    }
                }
                CheckPanel(Utils.k_arcadisMainTab, Utils.k_cablePanel, true);
            }
            else
            {
                CheckPanel(Utils.k_arcadisMainTab, Utils.k_cablePanel, false); 
            }
            ApplyRibbon();
            TreeViewFromRibbon();
        }

        private void ExportDataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ExportDataCheckBox.Checked)
            {
                if (Utils.b_exportTools != true)
                {
                    try
                    {
                        Utils.b_exportTools = Utils.LoadAddin(Utils.k_exportAddin, Utils.b_exportTools);
                    }
                    catch (Exception ex)
                    {
                        Metrics.AppendLog("Exception in loading Export Addin:\r\n" + ex.Message);
                    }
                }
                CheckPanel(Utils.k_arcadisMainTab, Utils.k_exportPanel, true);
            }
            else
            {
                CheckPanel(Utils.k_arcadisMainTab, Utils.k_exportPanel, false);
            }
            ApplyRibbon();
            TreeViewFromRibbon();
        }

        private void ImportDataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ImportDataCheckBox.Checked)
            {
                if (Utils.b_importTools != true)
                {
                    try
                    {
                        Utils.b_importTools = Utils.LoadAddin(Utils.k_importAddin, Utils.b_importTools);
                    }
                    catch (Exception ex)
                    {
                        Metrics.AppendLog("Exception in loading Import Addin:\r\n" + ex.Message);
                    }
                }
                CheckPanel(Utils.k_arcadisMainTab, Utils.k_importPanel, true);
            }
            else
            {
                CheckPanel(Utils.k_arcadisMainTab, Utils.k_importPanel, false);
            }
            ApplyRibbon();
            TreeViewFromRibbon();
        }

        private void CheckPanel(string tabName, string panelName, bool check)
        {
            foreach (TreeNode tabNode in ToolbarTreeView.Nodes)
            {
                if (tabNode.Text == tabName)
                {
                    foreach(TreeNode panelNode in tabNode.Nodes)
                    {
                        if(panelNode.Text == panelName)
                        {
                            panelNode.Checked = check;

                            foreach(TreeNode com in panelNode.Nodes)
                            {
                                com.Checked = check;
                            }
                        }
                    }
                }
            }
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

        private void DynCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DynCheckBox.Checked)
            {
                try
                {
                    if (Utils.b_dynamicTools == true) return;
                    Utils.b_dynamicTools = Utils.LoadAddin(Utils.k_dynamicAddin, Utils.b_dynamicTools);
                    TreeViewFromRibbon();
                }
                catch (Exception ex)
                {
                    Metrics.AppendLog("Exception in loading Dynamic Addin:\r\n" + ex.Message);
                }
            }
            else
            {
                TaskDialog.Show("Unloading Tools", "Unloading Dynamic Tools");
            }
        }
    }
}

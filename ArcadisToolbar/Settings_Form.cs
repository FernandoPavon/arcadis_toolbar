using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Autodesk.Windows;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Newtonsoft.Json;
using static ArcadisToolbar_I.RibbonVisibility;
using System.Resources;
using System.Collections;
using System.Windows.Media.Imaging;
using MetricsTracker;


namespace ArcadisToolbar_I
{
    public partial class Settings_Form : System.Windows.Forms.Form
    {
        bool isLoading = true;

        public Settings_Form()
        {
            InitializeComponent();
        }

        private void Settings_Form_Load(object sender, EventArgs e)
        {
            Image image;
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(44, 16);
            image = Properties.Resources.Tab40;
            imageList.Images.Add(image);
            image = Properties.Resources.Panel44;
            imageList.Images.Add(image);
            image = Properties.Resources.Button44;
            imageList.Images.Add(image);

            ToolbarTreeView.ImageList = imageList;
            ToolbarTreeView.Indent = 20;
            ToolbarTreeView.ItemHeight = 22;

            TreeViewFromRibbon();
        }

        private void TreeViewFromRibbon()
        {
            isLoading = true;

            foreach (ToolbarTab tab in ArcadisApp.s_arcadisRibbon.Tabs)
            {
                TreeNode nodeTab = ToolbarTreeView.Nodes.Add(tab.TabName, tab.TabName);
                nodeTab.ImageIndex = 0;
                nodeTab.SelectedImageIndex = 0;
                nodeTab.NodeFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                nodeTab.Text = nodeTab.Text;
                nodeTab.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
                //nodeTab.ForeColor = System.Drawing.Color.White;

                if (tab.TabName == Utils.k_arcadisTab_1)
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
                        nodeCommand.ImageIndex = 2;
                        nodeCommand.SelectedImageIndex = 2;
                        nodeCommand.NodeFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    }
                }
            }

            isLoading = false;
            //ToolbarTreeView.ExpandAll();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            RibbonVisibility ribbonVisibility = new RibbonVisibility();

            foreach (ToolbarTab tab in ArcadisApp.s_arcadisRibbon.Tabs)
            {
                bool tabCheck = true;

                TreeNode nodeTab = ToolbarTreeView.Nodes.Find(tab.TabName, false).First();
                if (tab.TabName == Utils.k_arcadisTab_1)
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
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolbarTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (isLoading) return;
            if (e.Action == TreeViewAction.Unknown) return;

            if (e.Node.Nodes.Count > 0)
            {
                this.CheckAllChildNodes(e.Node, e.Node.Checked);
            }
           
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

            if (e.Node.Text == Utils.k_arcadisTab_1)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Information", "The Tab " + Utils.k_arcadisTab_1 + " cannot be unchecked.");
                e.Cancel=true;
                return;
            }

            if (e.Node.Text == Utils.k_preferencesPanel)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Information", "The Panel " + Utils.k_preferencesPanel + " cannot be unchecked.");
                e.Cancel = true;
                return;
            }

            if (e.Node.Text == Utils.k_settings)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Information", "The Command" + Utils.k_settings + " cannot be unchecked.");
                e.Cancel = true;
            }
        }

        private void DynamicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DynamicCheckBox.Checked)
            {
                try
                {
                    UIControlledApplication application = Utils.g_controlledUIApp;

                    string asspath = Path.GetDirectoryName(Utils.g_assemblyPath);
                    string path = Path.Combine(asspath, "DynamicTools.addin");

                    try
                    {
                        Utils.g_controlledUIApp.LoadAddIn(path);
                    }
                    catch
                    {
                    }
                }
                catch(Exception ex)
                {
                    TaskDialog.Show("Exception", ex.Message);
                }
            }
            else
            {
                TaskDialog.Show("Unloading Tools", "Unloading Dynamic Tools");
            }
        }
    }
}

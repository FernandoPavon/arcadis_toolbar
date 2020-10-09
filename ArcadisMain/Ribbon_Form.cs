using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using Autodesk.Revit.UI;

namespace ArcadisMain
{
    public partial class Ribbon_Form : Form
    {
        bool isLoading = true;
        string m_arcadisMainPath = string.Empty;
        private readonly IList<AssemblyVersion> m_assemblies = new List<AssemblyVersion>();

        public Ribbon_Form()
        {
            InitializeComponent();
        }

        private void Ribbon_Form_Load(object sender, EventArgs e)
        {
            TreeViewFromArcadisRibbon();

            MainUserPreferences up = MainUserPreferences.GetUserPreferences();
            m_arcadisMainPath = Path.GetDirectoryName(Utils.g_mainAssemblyPath);
            
            if(up.ToolsPath == string.Empty)
            {
                up.ToolsPath = m_arcadisMainPath;
            }

            ToolsFolderTextBox.Text = up.ToolsPath;
            RepoTextBox.Text = Utils.k_repository;
            RevitVersionLabel.Text = Utils.k_revitVersion;

            string[] files = Directory.GetFiles(m_arcadisMainPath);
            string[] items = new string[3];

            foreach (string assemblyPath in files)
            {
                string ext = Path.GetExtension(assemblyPath);

                if (ext != ".dll") continue;

                string assemblyName = Path.GetFileName(assemblyPath);
                if (assemblyName.Equals(Utils.k_arcadisMain)) continue;

                AssemblyVersion module = new AssemblyVersion();
                module.AssemblyName = assemblyName;
                module.CurrentVersion = FileVersionInfo.GetVersionInfo(assemblyPath).ProductVersion;

                //var geography = reflectedAssembly.GetCustomAttributes(typeof(AssemblyGeography), false)[0];
                //string geo = ((AssemblyGeography)geography).Value;

                m_assemblies.Add(module);

                items[0] = module.AssemblyName;
                items[1] = module.CurrentVersion;
                items[2] = Utils.CheckRepoModuleVersion(RepoTextBox.Text, module.AssemblyName);

                ListViewItem viewItem = new ListViewItem(items);

                foreach(string mod in up.ToolModules)
                {
                    if(mod == module.AssemblyName)
                    {
                        viewItem.Checked = true;
                    }
                }
                
                ToolsListView.Items.Add(viewItem);
            }

            isLoading = false;
        }

        private void TreeViewFromArcadisRibbon()
        {

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
                    if (panel.Panel.Visible == false) continue;
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
                if (tab.Panels.Count < 1) continue;

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

                if (tab.Panels.Count < 1)
                {
                    nodeTab.Checked = false;
                    tab.RibbonTab.IsVisible = false;
                }

                foreach (ToolbarPanel panel in tab.Panels)
                {
                    if (panel.Panel.Visible == false) continue;

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
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            IList<string> modules = new List<string>();

            foreach(ListViewItem item in ToolsListView.CheckedItems)
            {
                modules.Add(item.Text);
            }

            MainUserPreferences up = new MainUserPreferences();

            up.ToolsPath = ToolsFolderTextBox.Text;
            up.ToolModules = modules;

            MainUserPreferences.SaveUserPreferences(up);

            Close();
        }

       

        private void ToolsListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (isLoading) return;

            string moduleName = e.Item.Text;
            string module = Path.GetFileNameWithoutExtension(moduleName);

            if (e.Item.Checked)
            {
                string moduleAddIn = module + ".addin";

                Utils.LoadAddin(moduleAddIn);
                TreePanelVisible(moduleName, true);
            }
            else
            {
                TreePanelVisible(moduleName, false);
            }

            TreeViewFromArcadisRibbon();
        }

        private void TreePanelVisible(string module, bool visible)
        {
            foreach (ToolbarTab tab in Utils.s_arcadisRibbon.Tabs)
            {
                foreach (ToolbarPanel panel in tab.Panels)
                {
                    if (panel.AssemblyName == module) panel.Panel.Visible = visible;
                }
            }
        }

        private void RepoBrowseButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    RepoTextBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void ToolsBrowseButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    ToolsFolderTextBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            ToolsFolderTextBox.Text = Utils.k_defaultToolsPath;
        }

        private void DefaultRepoPathButton_Click(object sender, EventArgs e)
        {
            ToolsFolderTextBox.Text = Utils.k_repository;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            TaskDialog.Show("Feature", "Not implemented yet");
        }

        private void LoadToolsButton_Click(object sender, EventArgs e)
        {
            TaskDialog.Show("Feature", "Not implemented yet");
        }
    }
}

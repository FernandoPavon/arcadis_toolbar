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
        string m_modulePath = string.Empty;
        string m_repoPath = string.Empty;
        private readonly IList<AssemblyVersion> m_assemblies = new List<AssemblyVersion>();
        MainUserPreferences m_up;

        public Ribbon_Form()
        {
            InitializeComponent();
        }

        private void Ribbon_Form_Load(object sender, EventArgs e)
        {
            TreeViewFromArcadisRibbon();

            m_up = MainUserPreferences.GetUserPreferences();
            m_arcadisMainPath = Path.GetDirectoryName(Utils.g_mainAssemblyPath);
            m_repoPath = Utils.k_repository;


            if (m_up.ToolsPath == string.Empty)
            {
                m_up.ToolsPath = m_arcadisMainPath;
            }
            
          
            m_modulePath = m_arcadisMainPath;

            ToolsFolderTextBox.Text = m_modulePath;
            RepoTextBox.Text = m_repoPath;
            RevitVersionLabel.Text = "Revit Version: " +  Utils.k_revitVersion;

            GetModules(m_modulePath, m_up);
           
            isLoading = false;
        }

        private void GetModules(string path, MainUserPreferences up)
        {
            ToolsListView.Items.Clear();

            if (path.Length < 1) return;

            string[] files = Directory.GetFiles(path);
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

                m_assemblies.Add(module);

                items[0] = module.AssemblyName;
                items[1] = module.CurrentVersion;
                items[2] = Utils.CheckRepoModuleVersion(m_repoPath, module.AssemblyName);

                ListViewItem viewItem = new ListViewItem(items);
                
                ToolsListView.Items.Add(viewItem);
            }
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

        private void ToolsListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
           
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
                    m_repoPath = fbd.SelectedPath;
                    RepoTextBox.Text = m_repoPath;
                }
                GetModules(m_modulePath, m_up);
            }
        }

        private void ToolsBrowseButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    m_modulePath = fbd.SelectedPath;
                    ToolsFolderTextBox.Text = m_modulePath;
                }
                GetModules(m_modulePath, m_up);
            }

            LoadToolsButton.Enabled = false;
            UnloadToolsButton.Enabled = false;
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            ToolsFolderTextBox.Text = Utils.k_defaultToolsPath;
            GetModules(Utils.k_defaultToolsPath, m_up);

            LoadToolsButton.Enabled = true;
            UnloadToolsButton.Enabled = true;
        }

        private void DefaultRepoPathButton_Click(object sender, EventArgs e)
        {
            RepoTextBox.Text = Utils.k_repository;
            GetModules(m_modulePath, m_up);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = ToolsListView.CheckedItems;

            if (checkedItems.Count < 1) return;

            TaskDialogResult result = TaskDialog.Show("Warning", "Are you sure you want to delete the selected tools?", TaskDialogCommonButtons.No | TaskDialogCommonButtons.Yes, TaskDialogResult.No);

            if(TaskDialogResult.No == result)
            {
                return;
            }
            else
            {
                foreach (ListViewItem item in checkedItems)
                {
                    string moduleName = item.Text;
                   
                    TreePanelVisible(moduleName, false);
                    string dllModule = Path.Combine(m_modulePath, moduleName);

                    try
                    {
                        File.Delete(dllModule);
                    }
                    catch
                    {
                        TaskDialog.Show("Information", "Could not delete file: " + dllModule);
                    }

                    string addinModule = Path.GetFileNameWithoutExtension(dllModule);
                    addinModule += ".addin";
                    addinModule = Path.Combine(m_modulePath, addinModule);

                    try
                    {
                        File.Delete(addinModule);
                    }
                    catch
                    {
                        TaskDialog.Show("Information", "Could not delete file: " + addinModule);
                    }
                }
                TreeViewFromArcadisRibbon();
            }

            GetModules(m_modulePath, m_up);
        }

        private void LoadToolsButton_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = ToolsListView.CheckedItems;

            foreach(ListViewItem item in checkedItems)
            {
                string moduleName = item.Text;
                string module = Path.GetFileNameWithoutExtension(moduleName);

                string moduleAddIn = module + ".addin";
                string addinPath = Path.Combine(m_modulePath, moduleAddIn);

                Utils.LoadAddin(addinPath);

                TreePanelVisible(moduleName, true);
            }
            TreeViewFromArcadisRibbon();
        }

        private void UnloadToolsButton_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = ToolsListView.CheckedItems;

            foreach (ListViewItem item in checkedItems)
            {
                string moduleName = item.Text;
                TreePanelVisible(moduleName, false);
            }
            TreeViewFromArcadisRibbon();
        }

        private void Ribbon_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainUserPreferences up = new MainUserPreferences();

            up.ToolsPath = ToolsFolderTextBox.Text;
            up.ToolModules = GetLoadedModules();

            MainUserPreferences.SaveUserPreferences(up);
        }

        private IList<string> GetLoadedModules()
        {
            IList<string> loadedModules = new List<string>();

            foreach (ToolbarTab tab in Utils.s_arcadisRibbon.Tabs)
            {
                if (tab.Panels.Count < 1) continue;

                foreach (ToolbarPanel panel in tab.Panels)
                {
                    if (panel.Panel.Visible == false) continue;
                    if (Utils.k_arcadisMain.Equals(panel.AssemblyName)) continue;

                    loadedModules.Add( panel.AssemblyName);
                }
            }
            return loadedModules;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = ToolsListView.CheckedItems;
            if (checkedItems.Count < 1) return;

            string repoPath = Path.Combine(m_repoPath, Utils.k_revitVersion);

            foreach (ListViewItem item in checkedItems)
            {
                string dllModule = item.Text;
                string addinModule = Path.GetFileNameWithoutExtension(dllModule) + ".addin";

                string dllSource = Path.Combine(repoPath, dllModule);
                string addinSource = Path.Combine(repoPath, addinModule);

                string dllDest = Path.Combine(m_modulePath, dllModule);
                string addinDest = Path.Combine(m_modulePath, addinModule);

                try
                {
                    File.Copy(dllSource, dllDest, true);
                }
                catch
                {
                    TaskDialog.Show("Exception", "Cannot copy module in use : " + item.Text);
                    return;
                }

                try
                {
                    File.Copy(addinSource, addinDest, true);
                }
                catch
                {
                    TaskDialog.Show("Exception", "Error copying file: " + addinModule);
                }
            }
        }
    }
}

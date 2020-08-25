using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcadisMain
{
    public partial class Ribbon_Form : Form
    {
        public Ribbon_Form()
        {
            InitializeComponent();
        }

        private void Ribbon_Form_Load(object sender, EventArgs e)
        {
            TreeViewFromArcadisRibbon();

            MainUserPreferences up = MainUserPreferences.GetUserPreferences();
            CableCheckBox.Checked = up.CableCheckBox;
            DynCheckBox.Checked = up.DynamicCheckBox;
            ElectricalCheckBox.Checked = up.ElectricalCheckBox;
            ExportDataCheckBox.Checked = up.ExportDataCheckBox;
            ImportDataCheckBox.Checked = up.ImportDataCheckBox;
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
            //Save User Preferences
            //---------------------
            MainUserPreferences up = new MainUserPreferences();
            up.CableCheckBox = CableCheckBox.Checked;
            up.DynamicCheckBox = DynCheckBox.Checked;
            up.ElectricalCheckBox = ElectricalCheckBox.Checked;
            up.ExportDataCheckBox = ExportDataCheckBox.Checked;
            up.ImportDataCheckBox = ImportDataCheckBox.Checked;

            MainUserPreferences.SaveUserPreferences(up);

            Close();
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
                else
                {
                    UnLoadPanelFromTree(Utils.k_arcadisMainTab, Utils.k_electricalPanel, true);
                }
            }
            else
            {
                UnLoadPanelFromTree(Utils.k_arcadisMainTab, Utils.k_electricalPanel, false);
            }

            TreeViewFromArcadisRibbon();
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
                else
                {
                    UnLoadPanelFromTree(Utils.k_arcadisToolsTab, Utils.k_cablePanel, true);
                }
            }
            else
            {
                UnLoadPanelFromTree(Utils.k_arcadisToolsTab, Utils.k_cablePanel, false);
            }

            TreeViewFromArcadisRibbon();
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
                else
                {
                    UnLoadPanelFromTree(Utils.k_arcadisMainTab, Utils.k_exportPanel, true);
                }
            }
            else
            {
                UnLoadPanelFromTree(Utils.k_arcadisMainTab, Utils.k_exportPanel, false);
            }

            TreeViewFromArcadisRibbon();
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
                else
                {
                    UnLoadPanelFromTree(Utils.k_arcadisMainTab, Utils.k_importPanel, true);
                }
            }
            else
            {
                UnLoadPanelFromTree(Utils.k_arcadisMainTab, Utils.k_importPanel, false);
            }

            TreeViewFromArcadisRibbon();
        }

        private void UnLoadPanelFromTree(string strTab, string strPanel, bool loaded)
        {
            foreach (ToolbarTab tab in Utils.s_arcadisRibbon.Tabs)
            {
                if (tab.TabName == strTab)
                {
                    if (strTab != Utils.k_arcadisMainTab) tab.RibbonTab.IsVisible = loaded;

                    foreach (ToolbarPanel panel in tab.Panels)
                    {
                        if (panel.PanelName == strPanel) panel.Panel.Visible = loaded;
                    }
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
                    TreeViewFromArcadisRibbon();
                }
                catch (Exception ex)
                {
                    Metrics.AppendLog("Exception in loading Dynamic Addin:\r\n" + ex.Message);
                }
            }
            else
            {
                //Unload tools
            }
        }
    }
}

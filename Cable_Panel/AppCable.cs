using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Autodesk.Revit.UI;
using ArcadisMain;
using System.Drawing;

namespace Cable_Panel
{
    class AppCable : IExternalApplication
    {
        DateTime m_startTime;

        public Result OnStartup(UIControlledApplication application)
        {
            if (Utils.b_cableTools) return Result.Succeeded;

            try
            {
                m_startTime = DateTime.Now;

                Assembly exeAssembly = Assembly.GetExecutingAssembly();
                string assemblyPath = exeAssembly.Location;
                string arcadisTab = Utils.k_arcadisToolsTab;

                //Get Assembly Versions
                //Utils.g_DynamicTools_Version = exeAssembly.GetName().Version.ToString();

                var geography = exeAssembly.GetCustomAttributes(typeof(AssemblyGeography), false)[0];
                string geo = ((AssemblyGeography)geography).Value;

                foreach (AssemblyVersion assembly in Utils.s_assemblies)
                {
                    if (assembly.AssemblyName == "Cable_Panel.dll")
                    {
                        assembly.Geography = geo;
                    }
                }

                Metrics.AppendLog("\r\nLoading Cable Panel");
                Metrics.AppendLog("Geography: " + geo);
                Metrics.AppendLog("Toolbar Tab: " + arcadisTab);
                Metrics.AppendLog("Assembly Path: " + assemblyPath);
                Metrics.AppendLog("Session Start: " + m_startTime.ToString());
                
                ToolbarTab toolTab = null;
                foreach (ToolbarTab tab in Utils.s_arcadisRibbon.Tabs)
                {
                    if (arcadisTab.Equals(tab.TabName))
                    {
                        toolTab = tab;
                        
                        break;
                    }
                }

                //Cable Panel
                //-----------------------
                RibbonPanel panel = application.CreateRibbonPanel(arcadisTab, Utils.k_cablePanel);
                ToolbarPanel toolPanel = new ToolbarPanel(panel.Name, panel, "Cable_Panel.dll");
                toolTab.Panels.Add(toolPanel);

                string strCommand = "Cable_Panel.Trefoils_Command";
                Bitmap bitmap = Properties.Resources.FloorSingle_32;
                Bitmap bitmapHelp = null;
                string helpURL = "https://help.autodesk.com/view/RVT/2020/ENU/?guid=GUID-35DE66AB-6EF5-48C0-B477-F3B1B120F18A";
                ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, helpURL);
                string longDesc = "Long help description for command button. Can include a long descriptive text with and an optional image.";
                Utils.CreateCommand(panel, toolPanel, "Trefoil", "Trefoil Floor", assemblyPath, strCommand, bitmap, "Automaticaly place trefolis with cleats.", bitmapHelp, longDesc, contextHelp);

                strCommand = "Cable_Panel.Trefoils_Command";
                bitmap = Properties.Resources.MultiLevelSingle_32;
                Utils.CreateCommand(panel, toolPanel, "Trefoil Complex", "Trefoil Complex", assemblyPath, strCommand, bitmap, "Automaticaly place multi-level trefoils.", bitmapHelp, longDesc, contextHelp);

                strCommand = "Cable_Panel.Parallel_Command";
                bitmap = Properties.Resources.FloorCleat_32;
                Utils.CreateCommand(panel, toolPanel, "Parallel Floor", "Parallel Floor", assemblyPath, strCommand, bitmap, "Automaticaly place parallel cables with cleats.", bitmapHelp, longDesc, contextHelp);

                strCommand = "Cable_Panel.Parallel_Command";
                bitmap = Properties.Resources.Complex_32;
                Utils.CreateCommand(panel, toolPanel, "Parallel Complex", "Parallel Complex", assemblyPath, strCommand, bitmap, "Automaticaly place multi-level parallel cables.", bitmapHelp, longDesc, contextHelp);

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Exception creating command button", ex.Message);
                Metrics.AppendLog("Exception Creating Toolbars: \r\n" + ex.Message);
                return Result.Failed;
            }
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            Metrics.AppendLog("Cable Panel Shutdown");
            return Result.Succeeded;
        }
    }
}

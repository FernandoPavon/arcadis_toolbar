using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Reflection;
using Autodesk.Revit.UI;
using ArcadisMain;
using System.Drawing;
using System.Resources;
using System.Collections;

namespace Electrical_Panel_UK
{
    public class AppElectricalUK : IExternalApplication
    {
        DateTime m_startTime;

        public Result OnStartup(UIControlledApplication application)
        {
            if (Utils.b_electricalTools) return Result.Succeeded;

            try
            {
                m_startTime = DateTime.Now;

                Assembly exeAssembly = Assembly.GetExecutingAssembly();
                string assemblyPath = exeAssembly.Location;
                string arcadisTab = Utils.k_arcadisMainTab;

                var geography = exeAssembly.GetCustomAttributes(typeof(AssemblyGeography), false)[0];
                string geo = ((AssemblyGeography)geography).Value;

                foreach (AssemblyVersion assembly in Utils.s_assemblies)
                {
                    if (assembly.AssemblyName == "Electrical_Panel_UK.dll")
                    {
                        assembly.Geography = geo;
                    }
                }

                //Get Assembly Versions
                //Utils.g_DynamicTools_Version = exeAssembly.GetName().Version.ToString();

                Metrics.AppendLog("\r\nLoading Electrical Panel UK");
                Metrics.AppendLog("Geography: " + geo);
                Metrics.AppendLog("Toolbar Tab: " + arcadisTab);
                Metrics.AppendLog("Assembly Path: " + assemblyPath);
                Metrics.AppendLog("Session Start: " + m_startTime.ToString());
                //Metrics.AppendLog("Dynamic Tools Version: " + Utils.g_DynamicTools_Version);

                ToolbarTab toolTab = null;
                foreach (ToolbarTab tab in Utils.s_arcadisRibbon.Tabs)
                {
                    if (arcadisTab.Equals(tab.TabName))
                    {
                        toolTab = tab;
                        break;
                    }
                }

                //Electrical Panel
                //-----------------------
                RibbonPanel panel = application.CreateRibbonPanel(arcadisTab, Utils.k_electricalPanel_UK);
                ToolbarPanel toolPanel = new ToolbarPanel(panel.Name, panel, "Electrical_Panel_UK.dll");
                toolTab.Panels.Add(toolPanel);

                string strCommand = "Electrical_Panel_UK.Fixtures_Command";
                Bitmap bitmap = Properties.Resources.ElectricalFixture;
                Bitmap bitmapHelp = null;
                string helpURL = "https://help.autodesk.com/view/RVT/2020/ENU/?guid=GUID-35DE66AB-6EF5-48C0-B477-F3B1B120F18A";
                ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, helpURL);
                string longDesc = "Long help description for command button. Can include a long descriptive text with and an optional image.";
                Utils.CreateCommand(panel, toolPanel, "Fixtures", "Door Fixtures", assemblyPath, strCommand, bitmap, "Automaticaly place electrical fixtures", bitmapHelp, longDesc, contextHelp);

                strCommand = "Electrical_Panel_UK.Cable_Command";
                bitmap = Properties.Resources.CableTrays;
                Utils.CreateCommand(panel, toolPanel, "CableTray", "Cable Trays", assemblyPath, strCommand, bitmap, "Automaticaly place cable trays", bitmapHelp, longDesc, contextHelp);

               
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
            Metrics.AppendLog("Electrical Panel Shutdown");
            return Result.Succeeded;
        }

    }
}

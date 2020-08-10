using System;
using System.Reflection;
using Autodesk.Revit.UI;
using CommonTools;
using System.Drawing;

namespace Export_Panel
{
    class AppExport : IExternalApplication
    {
        DateTime m_startTime;

        public Result OnStartup(UIControlledApplication application)
        {
            if (Utils.b_exportTools) return Result.Succeeded;

            try
            {
                m_startTime = DateTime.Now;

                Assembly exeAssembly = Assembly.GetExecutingAssembly();
                string assemblyPath = exeAssembly.Location;
                string arcadisTab = Utils.k_arcadisMainTab;

                Metrics.AppendLog("\r\nLoading Export Panel");
                Metrics.AppendLog("Toolbar Tab: " + arcadisTab);
                Metrics.AppendLog("Assembly Path: " + assemblyPath);
                Metrics.AppendLog("Load time: " + m_startTime.ToString());

                ToolbarTab toolTab = null;
                foreach (ToolbarTab tab in Utils.s_arcadisRibbon.Tabs)
                {
                    if (arcadisTab.Equals(tab.TabName))
                    {
                        toolTab = tab;
                        break;
                    }
                }

                //Export Panel
                //-----------------------
                RibbonPanel panel = application.CreateRibbonPanel(arcadisTab, Utils.k_exportPanel);
                ToolbarPanel toolPanel = new ToolbarPanel(panel.Name, panel);
                toolTab.Panels.Add(toolPanel);

                string strCommand = "Export_Panel.ExportData_Command";
                Bitmap bitmap = Properties.Resources.ExportData;
                Bitmap bitmapHelp = null;
                string helpURL = "https://help.autodesk.com/view/RVT/2020/ENU/?guid=GUID-35DE66AB-6EF5-48C0-B477-F3B1B120F18A";
                ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, helpURL);
                string longDesc = "Long help description for command button. Can include a long descriptive text with and an optional image.";
                Utils.CreateCommand(panel, toolPanel, "Export Data", "Export Data", assemblyPath, strCommand, bitmap, "Export Data.", bitmapHelp, longDesc, contextHelp);

                strCommand = "Export_Panel.ExportExcel_Command";
                bitmap = Properties.Resources.ExportExcel;
                Utils.CreateCommand(panel, toolPanel, "Export Excel", "Export Excel", assemblyPath, strCommand, bitmap, "Export to Excel.", bitmapHelp, longDesc, contextHelp);

                strCommand = "Export_Panel.ExportPCF_Command";
                bitmap = Properties.Resources.ExportPCF;
                Utils.CreateCommand(panel, toolPanel, "Export PCF", "Export PCF", assemblyPath, strCommand, bitmap, "Export to PCF", bitmapHelp, longDesc, contextHelp);

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
            Metrics.AppendLog("Export Panel Shutdown");
            return Result.Succeeded;
        }
    }
}

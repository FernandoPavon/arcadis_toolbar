using System;
using System.Reflection;
using Autodesk.Revit.UI;
using ArcadisMain;
using System.Drawing;

namespace Import_Panel
{
    class AppImport : IExternalApplication
    {
        DateTime m_startTime;

        public Result OnStartup(UIControlledApplication application)
        {
            if (Utils.b_importTools) return Result.Succeeded;

            try
            {
                m_startTime = DateTime.Now;

                Assembly exeAssembly = Assembly.GetExecutingAssembly();
                string assemblyPath = exeAssembly.Location;
                string arcadisTab = Utils.k_arcadisMainTab;

                Metrics.AppendLog("\r\nLoading Import Panel");
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
                RibbonPanel panel = application.CreateRibbonPanel(arcadisTab, Utils.k_importPanel);
                ToolbarPanel toolPanel = new ToolbarPanel(panel.Name, panel, "Import_Panel.dll");
                toolTab.Panels.Add(toolPanel);

                string strCommand = "Import_Panel.ImportData_Command";
                Bitmap bitmap = Properties.Resources.ImportData;
                Bitmap bitmapHelp = null;
                string helpURL = "https://help.autodesk.com/view/RVT/2020/ENU/?guid=GUID-35DE66AB-6EF5-48C0-B477-F3B1B120F18A";
                ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, helpURL);
                string longDesc = "Long help description for command button. Can include a long descriptive text with and an optional image.";
                Utils.CreateCommand(panel, toolPanel, "Import Data", "Import Data", assemblyPath, strCommand, bitmap, "Import Data.", bitmapHelp, longDesc, contextHelp);

                strCommand = "Import_Panel.ImportExcel_Command";
                bitmap = Properties.Resources.ImportExcel;
                Utils.CreateCommand(panel, toolPanel, "Import Excel", "Import Excel", assemblyPath, strCommand, bitmap, "Import to Excel.", bitmapHelp, longDesc, contextHelp);

                strCommand = "Import_Panel.ImportPCF_Command";
                bitmap = Properties.Resources.ImportPCF;
                Utils.CreateCommand(panel, toolPanel, "Import PCF", "Import PCF", assemblyPath, strCommand, bitmap, "Import to PCF", bitmapHelp, longDesc, contextHelp);

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
            Metrics.AppendLog("Import Panel Shutdown");
            return Result.Succeeded;
        }
    }
}


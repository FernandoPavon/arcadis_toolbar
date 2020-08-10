#region Copyright

/*
 *  Copyright 2020 Autodesk, Inc. All rights reserved.
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:

 *  The above copyright notice and this permission notice shall be included in all
 *  copies or substantial portions of the Software.

 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *  SOFTWARE.

 *  Autodesk Consulting Services
 *  fernando.pavon@autodesk.com
 *  Version 0.0.0.1
 *  Proof of concept
 *  1 August 2020
 *  
 */
#endregion

using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;
using Autodesk.Revit.UI;
using CommonTools;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace ArcadisMain
{
    public class MainApp : IExternalApplication
    {
        DateTime m_startTime;
        private string m_revitAddinPath;
        private readonly IList<AssemblyVersions> NewAssemblies = new List<AssemblyVersions>();

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                m_startTime = DateTime.Now;
                Metrics.AppendLog("Launching Arcadis Main Application");
                Metrics.AppendLog("Session Start: " + m_startTime.ToString());

                //Language info
                //-------------
                CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                var ri = new RegionInfo(ci.Name);

                Utils.k_systemCountry = ri.DisplayName;
                Utils.k_systemLanguage = ci.NativeName;
                Utils.k_revitLanguage = application.ControlledApplication.Language.ToString();

                Metrics.AppendLog("System Language: " + Utils.k_systemLanguage);
                Metrics.AppendLog("System Country: " + Utils.k_systemCountry);
                Metrics.AppendLog("Revit language: " + Utils.k_revitLanguage);

                Metrics.AppendLog("\r\nChecking for new versions");

                Utils.g_controlledUIApp = application;
                Assembly mainAssembly = Assembly.GetExecutingAssembly();
                Utils.g_mainAssemblyPath = mainAssembly.Location;
                m_revitAddinPath = Path.GetDirectoryName(Utils.g_mainAssemblyPath);

                string locPath = Utils.g_mainAssemblyPath;

                string Revit = string.Empty;

                if (m_revitAddinPath.Contains("2018")) Revit = "2018";
                else if (m_revitAddinPath.Contains("2019")) Revit = "2019";
                else if (m_revitAddinPath.Contains("2020")) Revit = "2020";
                else if (m_revitAddinPath.Contains("2021")) Revit = "2021";

                Utils.k_revitVersion = Revit;

                Metrics.AppendLog("Revit Version: " + Utils.k_revitVersion);
                
                string arcadisRepository = Path.Combine(Utils.k_repository, Utils.k_revitVersion);

                Metrics.AppendLog("Repository : " + arcadisRepository);

                //Look for new Versions
                //---------------------
                IList<string> modules = new List<string>
                {
                    "ArcadisMain.dll",
                    "Electrical_Panel.dll",
                    "DynamicTools.dll",
                    "Import_Panel.dll",
                    "Export_Panel.dll"
                };

                //string[] files = Directory.GetFiles(arcadisRepository);

                foreach (string assemblyName in modules)
                {
                    string repoPath = Path.Combine(arcadisRepository, assemblyName);
                    string revitPath = Path.Combine(m_revitAddinPath, assemblyName);

                    string revitVersion = FileVersionInfo.GetVersionInfo(revitPath).ProductVersion;
                    string repoVersion = FileVersionInfo.GetVersionInfo(repoPath).ProductVersion;

                    if (repoVersion != revitVersion)
                    {
                        AssemblyVersions module = new AssemblyVersions();
                        module.AssemblyName = assemblyName;
                        module.CurrentVersion = revitVersion;
                        module.RepositoryVersion = repoVersion;
                        NewAssemblies.Add(module);
                    }
                }

                if (NewAssemblies.Count > 0)
                {
                    VersionsForm form = new VersionsForm();
                    form.RevitAddInPath = m_revitAddinPath;
                    form.RepositoryPath = arcadisRepository;
                    form.NewAssemblies = NewAssemblies;
                    form.ShowDialog();
                }

                //Create Arcatis Tabs
                //-------------------
                application.CreateRibbonTab(Utils.k_arcadisMainTab);
                ToolbarTab mainTab = AddTabs(Utils.k_arcadisMainTab, true);

                application.CreateRibbonTab(Utils.k_arcadisToolsTab);
                ToolbarTab toolsTab = AddTabs(Utils.k_arcadisToolsTab, false);
                
                // About Arcadis Tools Panel
                //--------------------------
                RibbonPanel panel = application.CreateRibbonPanel(Utils.k_arcadisMainTab, Utils.k_arcadisPanel);
                ToolbarPanel toolPanel = new ToolbarPanel(panel.Name, panel);
                mainTab.Panels.Add(toolPanel);

                string strCommand = "ArcadisMain.About_Command";
                Bitmap bitmap = Properties.Resources.Info;
                Bitmap bitmapHelp = Properties.Resources.AboutHelp;
                string helpURL = "https://www.arcadis.com/en/global/";
                ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, helpURL);
                string longDesc = "Long help description for command button. Can include a long descriptive text with and an optional image.";
                Utils.CreateCommand(panel, toolPanel, "About Tools", "About Tools", locPath, strCommand, bitmap, "Information about Arcadis automation tools", bitmapHelp, longDesc, contextHelp);

                strCommand = "ArcadisMain.Settings_Command";
                bitmap = Properties.Resources.settings;
                bitmapHelp = Properties.Resources.SettingsHelp;
                helpURL = "https://help.autodesk.com/view/RVT/2020/ENU/?guid=GUID-35DE66AB-6EF5-48C0-B477-F3B1B120F18A";
                contextHelp = new ContextualHelp(ContextualHelpType.Url, helpURL);
                Utils.CreateCommand(panel, toolPanel, Utils.k_settings, Utils.k_settings, locPath, strCommand, bitmap, "Arcadis Toolbar Settings", bitmapHelp, longDesc, contextHelp);

                strCommand = "ArcadisMain.Metrics_Command";
                bitmap = Properties.Resources.BarChart2;
                bitmapHelp = Properties.Resources.MetricsHelp;
                Utils.CreateCommand(panel, toolPanel, "Metrics Tracker", "Metrics Tracker", locPath, strCommand, bitmap, "Display session Metrics Tracker Log", bitmapHelp, longDesc, contextHelp);

                MainUserPreferences up = MainUserPreferences.GetUserPreferences();

                if(up.CableCheckBox == true) Utils.b_cableTools = Utils.LoadAddin(Utils.k_cableAddin, Utils.b_cableTools);
                if(up.DynamicCheckBox == true) Utils.b_dynamicTools = Utils.LoadAddin(Utils.k_dynamicAddin, Utils.b_dynamicTools);
                if(up.ElectricalCheckBox == true) Utils.b_electricalTools = Utils.LoadAddin(Utils.k_electricalAddin, Utils.b_electricalTools);
                if(up.ExportDataCheckBox == true) Utils.b_exportTools = Utils.LoadAddin(Utils.k_exportAddin, Utils.b_exportTools);
                if(up.ImportDataCheckBox == true) Utils.b_importTools = Utils.LoadAddin(Utils.k_importAddin, Utils.b_importTools);

            }
            catch (Exception ex)
            {
                Metrics.AppendLog("\r\nException: " + ex.Message);
                TaskDialog.Show("Exception", ex.Message);

                return Result.Failed;
            }
            return Result.Succeeded;
        }

        private ToolbarTab AddTabs(string tabName, bool visible)
        {
            ToolbarTab toolTab = null;
            foreach (Autodesk.Windows.RibbonTab tab in Autodesk.Windows.ComponentManager.Ribbon.Tabs)
            {
                if (tab.Name == tabName)
                {
                    toolTab = new ToolbarTab(tabName, tab);
                    toolTab.RibbonTab.IsVisible = visible;
                    Utils.s_arcadisRibbon.Tabs.Add(toolTab);
                    break;
                }
            }

            return toolTab;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            DateTime endTime = DateTime.Now;
            Metrics.AppendLog("\r\n\r\nRevit Session End: " + endTime.ToString());

            TimeSpan session = endTime - m_startTime;
            Metrics.AppendLog("Revit Session duration: " + session.ToString());

            return Result.Succeeded;
        }
    }

    public class AssemblyVersions
    {
        public string AssemblyName  {get; set;}
        public string RepositoryVersion { get; set; }
        public string CurrentVersion { get; set; }

    }
}

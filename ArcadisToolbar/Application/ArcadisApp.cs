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
 *  1 July 2020
 *  
 */
#endregion

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Windows.Media.Imaging;
using System.Reflection;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using MetricsTracker;
using Export_Panel;
using Import_Panel;
using ArcadisToolbar_II;
using System.Drawing;
using System.Threading;
using Autodesk.Revit.DB.Events;
using System.Runtime.Serialization.Formatters.Binary;

namespace ArcadisToolbar_I
{
    class ArcadisApp : IExternalApplication
    {
        DateTime m_startTime;
        static internal ArcadisRibbon s_arcadisRibbon = new ArcadisRibbon();

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                m_startTime = DateTime.Now;

                Utils.g_controlledUIApp = application;
                Assembly exeAssembly = Assembly.GetExecutingAssembly();
                Utils.g_assemblyPath = exeAssembly.Location;

                //Document Opened Event
                application.ControlledApplication.DocumentOpened += new EventHandler
                <DocumentOpenedEventArgs>(DocumentOpened);

                string locPath = Utils.g_assemblyPath;
                string arcadisTab_I = Utils.k_arcadisTab_1;

                //Get Assembly Versions
                Utils.g_arcadisToolbar_I_Version = exeAssembly.GetName().Version.ToString();

                Assembly[] myAssemblies = Thread.GetDomain().GetAssemblies();

                Assembly assembly = myAssemblies.Single(s => s.GetName().Name == "ArcadisToolbar_II");
                if (null != assembly) Utils.g_arcadisToolbar_II_Version = assembly.GetName().Version.ToString();

                assembly = myAssemblies.Single(s => s.GetName().Name == "Export_Panel");
                if (null != assembly) Utils.g_ExportPanel_Version = assembly.GetName().Version.ToString();

                assembly = myAssemblies.Single(s => s.GetName().Name == "Import_Panel");
                if (null != assembly) Utils.g_ImportPanel_Version = assembly.GetName().Version.ToString();

                assembly = myAssemblies.Single(s => s.GetName().Name == "MetricsTracker");
                if (null != assembly) Utils.g_MetricsTracker_Version = assembly.GetName().Version.ToString();

                //assembly = myAssemblies.Single(s => s.GetName().Name == "DynamicTools");
                //Utils.g_DynamicTools_Version = assembly.GetName().Version.ToString();

                Metrics.AppendLog("Launching Arcadis Application");
                Metrics.AppendLog("Toolbar Tab: " + arcadisTab_I);
                Metrics.AppendLog("Assembly Path: " + locPath);
                Metrics.AppendLog("Session Start: " + m_startTime.ToString());
                Metrics.AppendLog("ArcadisToolbar_I Version: " + Utils.g_arcadisToolbar_I_Version);
                Metrics.AppendLog("ArcadisToolbar_II Version: " + Utils.g_arcadisToolbar_II_Version);
                Metrics.AppendLog("Export Panel Version: " + Utils.g_ExportPanel_Version);
                Metrics.AppendLog("Import Panel Version: " + Utils.g_ImportPanel_Version);
                Metrics.AppendLog("Metrics Tracker Version: " + Utils.g_MetricsTracker_Version);

                //Arcadis Tools_I Tab 
                //------------------------
                application.CreateRibbonTab(arcadisTab_I);
                ToolbarTab toolTab = null;
                foreach (Autodesk.Windows.RibbonTab tab in Autodesk.Windows.ComponentManager.Ribbon.Tabs)
                {
                    if (tab.Name == arcadisTab_I)
                    {
                        toolTab = new ToolbarTab(arcadisTab_I, tab);
                        s_arcadisRibbon.Tabs.Add(toolTab);
                        break;
                    }
                }

                // About Panel
                RibbonPanel panel = application.CreateRibbonPanel(arcadisTab_I, "Information");
                ToolbarPanel toolPanel = new ToolbarPanel(panel.Name, panel);
                toolTab.Panels.Add(toolPanel);

                string strCommand = "ArcadisToolbar_I.About_Command";
                Bitmap bitmap = ArcadisToolbar_I.Properties.Resources.Info;
                Bitmap bitmapHelp = ArcadisToolbar_I.Properties.Resources.AboutHelp;
                string helpURL = "https://www.arcadis.com/en/global/";
                ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, helpURL);
                string longDesc = "Long help description for command button. Can include a long descriptive text with and an optional image.";
                CreateCommand(panel, toolPanel, "About", "About", locPath, strCommand, bitmap, "Information about Arcadis automation tools", bitmapHelp, longDesc, contextHelp);

                panel = application.CreateRibbonPanel(arcadisTab_I, "Preferences");
                toolPanel = new ToolbarPanel(panel.Name, panel);
                toolTab.Panels.Add(toolPanel);

                strCommand = "ArcadisToolbar_I.Settings_Command";
                bitmap = ArcadisToolbar_I.Properties.Resources.settings;
                bitmapHelp = ArcadisToolbar_I.Properties.Resources.SettingsHelp;
                helpURL = "https://help.autodesk.com/view/RVT/2020/ENU/?guid=GUID-35DE66AB-6EF5-48C0-B477-F3B1B120F18A";
                contextHelp = new ContextualHelp(ContextualHelpType.Url, helpURL);
                CreateCommand(panel, toolPanel, "Settings", "Settings", locPath, strCommand, bitmap, "Arcadis Toolbar Settings", bitmapHelp, longDesc, contextHelp);

                panel = application.CreateRibbonPanel(arcadisTab_I, "Metrics Tracker");
                toolPanel = new ToolbarPanel(panel.Name, panel);
                toolTab.Panels.Add(toolPanel);

                strCommand = "ArcadisToolbar_I.Metrics_Command";
                bitmap = ArcadisToolbar_I.Properties.Resources.BarChart2;
                bitmapHelp = ArcadisToolbar_I.Properties.Resources.MetricsHelp;
                CreateCommand(panel, toolPanel, "Metrics Tracker", "Logs", locPath, strCommand, bitmap, "Display session Metrics Tracker Log", bitmapHelp, longDesc, contextHelp);

                //Electrical Panel
                //-----------------------
                panel = application.CreateRibbonPanel(arcadisTab_I, "Electrical");
                toolPanel = new ToolbarPanel(panel.Name, panel);
                toolTab.Panels.Add(toolPanel);

                strCommand = "ArcadisToolbar_I.Fixtures_Command";
                bitmap = ArcadisToolbar_I.Properties.Resources.ElectricalFixture;
                bitmapHelp = null;
                CreateCommand(panel, toolPanel, "Fixtures", "Door Fixtures", locPath, strCommand, bitmap, "Automaticaly place electrical fixtures", bitmapHelp, longDesc, contextHelp);

                strCommand = "ArcadisToolbar_I.Cable_Command";
                bitmap = ArcadisToolbar_I.Properties.Resources.CableTrays;
                CreateCommand(panel, toolPanel, "CableTray", "Cable Trays", locPath, strCommand, bitmap, "Automaticaly place cable trays", bitmapHelp, longDesc, contextHelp);

                strCommand = "ArcadisToolbar_I.Fixtures_Command";
                bitmap = ArcadisToolbar_I.Properties.Resources.Light;
                CreateCommand(panel, toolPanel, "Lights", "Desk Lights", locPath, strCommand, bitmap, "Automaticaly place lights.", bitmapHelp, longDesc, contextHelp);

                //Export Panel
                //-----------------------
                string tabExport = Utils.k_arcadisTab_1;
                string path = Path.GetDirectoryName(locPath);
                locPath = Path.Combine(path, "Export_Panel.dll");

                panel = application.CreateRibbonPanel(arcadisTab_I, "Export Model Data");
                toolPanel = new ToolbarPanel(panel.Name, panel);
                toolTab.Panels.Add(toolPanel);

                strCommand = "Export_Panel.ExportPCF_Command";
                bitmap = Export_Panel.Properties.Resources.ExportPCF;
                CreateCommand(panel, toolPanel, "Export PCF", "PCF File", locPath, strCommand, bitmap, "Export PCF file.", bitmapHelp, longDesc, contextHelp);

                strCommand = "Export_Panel.ExportExcel_Command";
                bitmap = Export_Panel.Properties.Resources.ExportExcel;
                CreateCommand(panel, toolPanel, "Export Excel", "Excel File", locPath, strCommand, bitmap, "Export to Excel.", bitmapHelp, longDesc, contextHelp);

                strCommand = "Export_Panel.ExportData_Command";
                bitmap = Export_Panel.Properties.Resources.ExportData;
                CreateCommand(panel, toolPanel, "Export Data", "Database", locPath, strCommand, bitmap, "Export to Database.", bitmapHelp, longDesc, contextHelp);

                //Import Panel
                //-----------------------
                string tabImport = Utils.k_arcadisTab_1;
                path = Path.GetDirectoryName(locPath);
                locPath = Path.Combine(path, "Import_Panel.dll");

                panel = application.CreateRibbonPanel(arcadisTab_I, "Import Model Data");
                toolPanel = new ToolbarPanel(panel.Name, panel);
                toolTab.Panels.Add(toolPanel);

                strCommand = "Import_Panel.ImportPCF_Command";
                bitmap = Import_Panel.Properties.Resources.ImportPCF;
                CreateCommand(panel, toolPanel, "Import PCF", "PCF File", locPath, strCommand, bitmap, "Import PCF file.", bitmapHelp, longDesc, contextHelp);

                strCommand = "Import_Panel.ImportExcel_Command";
                bitmap = Import_Panel.Properties.Resources.ImportExcel;
                CreateCommand(panel, toolPanel, "Import Excel", "Excel File", locPath, strCommand, bitmap, "Import Excel file.", bitmapHelp, longDesc, contextHelp);

                strCommand = "Import_Panel.ImportData_Command";
                bitmap = Import_Panel.Properties.Resources.ImportData;
                CreateCommand(panel, toolPanel, "Import Data", "Database", locPath, strCommand, bitmap, "Import from database.", bitmapHelp, longDesc, contextHelp);


                //Arcadis Tools_II Tab  
                //------------------------
                string arcadisTab_II = Utils.k_arcadisTab_2;
                path = Path.GetDirectoryName(locPath);
                locPath = Path.Combine(path, "ArcadisToolbar_II.dll");

                application.CreateRibbonTab(arcadisTab_II);

                foreach (Autodesk.Windows.RibbonTab tab in Autodesk.Windows.ComponentManager.Ribbon.Tabs)
                {
                    if (tab.Name == arcadisTab_II)
                    {
                        toolTab = new ToolbarTab(arcadisTab_II, tab);
                        s_arcadisRibbon.Tabs.Add(toolTab);
                        break;
                    }
                }

                //-------------------------------------
                panel = application.CreateRibbonPanel(arcadisTab_II, "Trefoil Supports");
                toolPanel = new ToolbarPanel(panel.Name, panel);
                toolTab.Panels.Add(toolPanel);

                strCommand = "ArcadisToolbar_II.Trefoils_Command";
                bitmap = ArcadisToolbar_II.Properties.Resources.FloorCleat_32;
                CreateCommand(panel, toolPanel, "Trefoils", "Trefoil", locPath, strCommand, bitmap, "Trefoils and floor cleats.", bitmapHelp, longDesc, contextHelp);

                strCommand = "ArcadisToolbar_II.Trefoils_Command";
                bitmap = ArcadisToolbar_II.Properties.Resources.Complex_32;
                CreateCommand(panel, toolPanel, "Trefoils Multi Level", "Trefoil Multi Level", locPath, strCommand, bitmap, "Multi levels trefoils and supports.", bitmapHelp, longDesc, contextHelp);

                
                panel = application.CreateRibbonPanel(arcadisTab_II, "Parallel Supports");
                toolPanel = new ToolbarPanel(panel.Name, panel);
                toolTab.Panels.Add(toolPanel);

                strCommand = "ArcadisToolbar_II.Parallel_Command";
                bitmap = ArcadisToolbar_II.Properties.Resources.FloorSingle_32;
                CreateCommand(panel, toolPanel, "Parallel Cables", "Parallel Cables", locPath, strCommand, bitmap, "Parallel cables and floor cleats.", bitmapHelp, longDesc, contextHelp);

                strCommand = "ArcadisToolbar_II.Parallel_Command";
                bitmap = ArcadisToolbar_II.Properties.Resources.MultiLevelSingle_32;
                CreateCommand(panel, toolPanel, "Parallel Multi Level", "Parallel Multi Level", locPath, strCommand, bitmap, "Multi levels parallel cables and supports.", bitmapHelp, longDesc, contextHelp);

                Utils.SetRibbonVisibility();

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Exception creating command button", ex.Message);
                Metrics.AppendLog("Exception Creating Toolbars: \r\n" + ex.Message);
                return Result.Failed;
            }
        }

        private void CreateCommand(RibbonPanel panel, ToolbarPanel toolPanel, string name, string title, string path, string com, Bitmap bitmap, string tooltip, Bitmap bitmapHelp, string longDesc, ContextualHelp contextHelp)
        {
            try
            {
                PushButton button = panel.AddItem(new PushButtonData(name, title, path, com)) as PushButton;
                button.LargeImage = ConvertBitmap(bitmap);
                button.ToolTip = tooltip;
                if(null != bitmapHelp) button.ToolTipImage = ConvertBitmap(bitmapHelp);
                button.LongDescription = longDesc;
                button.SetContextualHelp(contextHelp);
                toolPanel.Commands.Add(new ToolbarCommand(name, button));
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Exception creating command button", ex.Message);
                Metrics.AppendLog("Exception creating button: " + name + "\r\n" + ex.Message);
            }
        }

        public BitmapImage ConvertBitmap(Bitmap bitmap)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                ms.Seek(0, SeekOrigin.Begin);
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Exception creating button image", ex.Message);
                Metrics.AppendLog("Exception creating button image.\r\n" + ex.Message);
                return null;
            }
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            //Remove Event
            application.ControlledApplication.DocumentOpened -= DocumentOpened;

            DateTime endTime = DateTime.Now;
            Metrics.AppendLog("\r\nSession End: " + endTime.ToString());

            TimeSpan session = endTime - m_startTime;
            Metrics.AppendLog("Session duration: " + session.ToString());

            return Result.Succeeded;
        }

        public void DocumentOpened(object sender, DocumentOpenedEventArgs args)
        {
            Document doc = args.Document;

            BinaryVersions binVer = new BinaryVersions();
            binVer.ArcadisToolbar_I_Version = Utils.g_arcadisToolbar_I_Version;
            binVer.ArcadisToolbar_II_Version = Utils.g_arcadisToolbar_II_Version;
            binVer.ExportPanel_Version = Utils.g_ExportPanel_Version;
            binVer.ImportPanel_Version = Utils.g_ImportPanel_Version;
            binVer.MetricsTracker_Version = Utils.g_MetricsTracker_Version;

            bool paramBinary = Utils.CheckCreateProjectParameter(doc, "MyBinaryData", BuiltInCategory.OST_ProjectInformation);

            Parameter par; 

            using (Transaction transaction = new Transaction(doc, "Versions"))
            {
                if (transaction.Start() == TransactionStatus.Started)
                {
                    //Check Toolbar_I
                    if( Utils.CheckCreateProjectParameter(doc, Utils.k_PI_ArcadisToolbar_I, BuiltInCategory.OST_ProjectInformation))
                    {
                        par = doc.ProjectInformation.LookupParameter(Utils.k_PI_ArcadisToolbar_I);
                        Utils.g_old_arcadisToolbar_I_Version = par.AsString();

                        if (Utils.g_old_arcadisToolbar_I_Version != Utils.g_arcadisToolbar_I_Version)
                        {
                            TaskDialog.Show("Version", "Arcadis Toolbar I\r\n" + "Old Version: " + Utils.g_old_arcadisToolbar_I_Version + "\r\nNew Version: " + Utils.g_arcadisToolbar_I_Version);
                            par.Set(Utils.g_arcadisToolbar_I_Version);
                        }
                    }

                    //Check Toolbar_II
                    if (Utils.CheckCreateProjectParameter(doc, Utils.k_PI_ArcadisToolbar_II, BuiltInCategory.OST_ProjectInformation))
                    {
                        par = doc.ProjectInformation.LookupParameter(Utils.k_PI_ArcadisToolbar_II);
                        Utils.g_old_arcadisToolbar_II_Version = par.AsString();

                        if (Utils.g_old_arcadisToolbar_II_Version != Utils.g_arcadisToolbar_II_Version)
                        {
                            TaskDialog.Show("Version", "Arcadis Toolbar I\r\n" + "Old Version: " + Utils.g_old_arcadisToolbar_II_Version + "\r\nNew Version: " + Utils.g_arcadisToolbar_II_Version);
                            par.Set(Utils.g_arcadisToolbar_II_Version);
                        }
                    }

                    Parameter parBin = doc.ProjectInformation.LookupParameter("MyBinaryData");
                    parBin.Set(SerializeBinaryData(binVer));

                    transaction.Commit();
                }
            }
        }

        private string SerializeBinaryData(BinaryVersions binVer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            bf.Serialize(stream, binVer);
            stream.Position = 0;

            long n2 = stream.Length;
            int n = (int)n2;
            byte[] buf = new byte[n];
            stream.Read(buf, 0, n);
            return Convert.ToBase64String(buf);
           
        }
    }
}

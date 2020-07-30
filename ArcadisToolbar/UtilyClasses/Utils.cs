using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
//using Autodesk.Windows;
using System.Windows.Media.Imaging;
using MetricsTracker;
using System.Drawing;
using static ArcadisToolbar_I.RibbonVisibility;
using System.IO;
using System.Windows.Media;
using System.Drawing.Imaging;
using System.Reflection;
using Autodesk.Revit.ApplicationServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace ArcadisToolbar_I
{
    class Utils
    {
        public static string k_arcadisTab_1 = "Arcadis Tools_I"; 
        public static string k_arcadisTab_2 = "Arcadis Tools_II";

        public static string k_preferencesPanel = "Preferences";
        public static string k_settings = "Settings";

        public static UIControlledApplication g_controlledUIApp = null;
        public static string g_assemblyPath = null;

        //Version control
        //---------------
        //Project Information Parameter Names
        public const string k_PI_ArcadisToolbar_I = "ArcadisToolbar_I_Version";
        public const string k_PI_ArcadisToolbar_II = "ArcadisToolbar_II_Version";
        public const string k_PI_ExportPanel = "ExportPanel_Version";
        public const string k_PI_ImportPanel = "ImportPanel_Version";
        public const string k_PI_MetricsTracker = "MetricsTracker_Version";
        //New Versions
        public static string g_arcadisToolbar_I_Version = "Not loaded";
        public static string g_arcadisToolbar_II_Version = "Not loaded";
        public static string g_ExportPanel_Version = "Not loaded";
        public static string g_ImportPanel_Version = "Not loaded";
        public static string g_MetricsTracker_Version = "Not loaded";
        public static string g_DynamicTools_Version = "Not loaded";
        //Old Versions
        public static string g_old_arcadisToolbar_I_Version = "Not loaded";
        public static string g_old_arcadisToolbar_II_Version = "Not loaded";
        public static string g_old_ExportPanel_Version = "Not loaded";
        public static string g_old_ImportPanel_Version = "Not loaded";
        public static string g_old_MetricsTracker_Version = "Not loaded";
        public static string g_old_DynamicTools_Version = "Not loaded";


        public static Assembly DynamicTools = null;

        public static void SetRibbonVisibility()
        {
            string json = Properties.Settings.Default.Toolbar_UserPreferences;
            if (null == json || json.Length < 1) return;

            RibbonVisibility jsonToolbars = JsonConvert.DeserializeObject<RibbonVisibility>(json);

            foreach (ToolbarTab toolbarTab in ArcadisApp.s_arcadisRibbon.Tabs)
            {
                TabVis tabVis = GetJsonTab(jsonToolbars, toolbarTab.TabName);
                if (null == tabVis)
                {
                    toolbarTab.RibbonTab.IsVisible = true;
                    continue;
                }

                if (toolbarTab.TabName == tabVis.TabName)
                {
                    if (tabVis.TabName == Utils.k_arcadisTab_1)
                    {
                        toolbarTab.RibbonTab.IsVisible = true;
                    }
                    else
                    {
                        if (null != tabVis) toolbarTab.RibbonTab.IsVisible = tabVis.Visible;
                    }
                }

                foreach (ToolbarPanel toolbarPanel in toolbarTab.Panels)
                {
                    PanelVis panelVis = GetJsonPanel(jsonToolbars, toolbarTab.TabName, toolbarPanel.PanelName);
                    if (null != panelVis) toolbarPanel.Panel.Visible = panelVis.Visible;

                    foreach (ToolbarCommand toolbarCommand in toolbarPanel.Commands)
                    {
                        CommandVis commandVis = GetJsonCommand(jsonToolbars, toolbarTab.TabName, toolbarPanel.PanelName, toolbarCommand.CommandName);
                        if (null != commandVis) toolbarCommand.Command.Visible = commandVis.Visible;
                    }
                }
            }
        }
            
        public static TabVis GetJsonTab(RibbonVisibility ribbon, string tab)
        {
            foreach (TabVis tabVis in ribbon.Tabs)
            {
                if (tabVis.TabName == tab)
                {
                    return tabVis;
                }
            }
            return null;
        }

        public static PanelVis GetJsonPanel(RibbonVisibility ribbon, string strTab, string strPanel)
        {
            foreach (TabVis tabVis in ribbon.Tabs)
            {
                if (tabVis.TabName == strTab)
                {
                    foreach (PanelVis panelVis in tabVis.Panels)
                    {
                        if (panelVis.PanelName == strPanel)
                        {
                            return panelVis;
                        }
                    }
                }
            }
            return null;
        }

        public static CommandVis GetJsonCommand(RibbonVisibility ribbon, string strTab, string strPanel, string strCommand)
        {
            foreach (TabVis tabVis in ribbon.Tabs)
            {
                if (tabVis.TabName == strTab)
                {
                    foreach (PanelVis panelVis in tabVis.Panels)
                    {
                        if (panelVis.PanelName == strPanel)
                        {
                            foreach (CommandVis commandVis in panelVis.Commands)
                            {
                                if (commandVis.CommandName == strCommand)
                                {
                                    return commandVis;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

       

        private static ImageSource ConvertImage(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        private static BitmapImage ConvertBitmap(Bitmap bitmap)
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

        //Shared Parameters
        //-----------------
        public static bool CheckCreateProjectParameter(Document doc, string param, BuiltInCategory bicCheck)
        {
            try
            {
                BindingMap map = doc.ParameterBindings;

                DefinitionBindingMapIterator it = map.ForwardIterator();
                it.Reset();

                Category cat = Category.GetCategory(doc, bicCheck);

                CategorySet catSet = new CategorySet();
                catSet.Insert(Category.GetCategory(doc, bicCheck));
                
                ElementBinding eb = null;

                while (it.MoveNext())
                {
                    if (param == it.Key.Name)
                    {
                        eb = it.Current as ElementBinding;
                        if (eb.Categories.Contains(cat)) return true;
                    }
                }

                SubTransaction trans = new SubTransaction(doc);

                try
                {
                    trans.Start();
                    CreateSharedProjectParameters(doc, param, catSet);
                    trans.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    trans.RollBack();
                    throw new Exception("Exception in Create Shared Parameters" + ex.Message);
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in Check Project Parameter.\n" + ex);
            }
        }

        public static bool CreateSharedProjectParameters(Document doc, string param, CategorySet catSet)
        {
            DefinitionFile sharedParamsFile = GetSharedParamsFile(doc);

            if (null == sharedParamsFile)
            {
                throw new Exception("Shared Paremeter file does not exist.\nSet or Create the project Shared Parameter file.");
            }

            DefinitionGroup sharedParamsGroup = GetCreateSharedParamsGroup(sharedParamsFile, "Group6Face");
            Definition definition = GetCreateSharedParamsDefinition(sharedParamsGroup, ParameterType.Text, param, true);

            BindingMap bindMap = doc.ParameterBindings;

            Autodesk.Revit.DB.Binding binding = bindMap.get_Item(definition);
            bindMap.ReInsert(definition, binding);

            InstanceBinding instanceBinding = doc.Application.Create.NewInstanceBinding(catSet);

            try
            {
                if (!doc.ParameterBindings.Insert(definition, instanceBinding))
                {
                    doc.ParameterBindings.ReInsert(definition, instanceBinding);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Uneable to create parameter bindings.\n" + ex.Message);
            }
        }

        public static DefinitionFile GetSharedParamsFile(Document doc)
        {
            string sharedParamsFileName;

            try
            {
                sharedParamsFileName = doc.Application.SharedParametersFilename;
            }
            catch (Exception ex)
            {
                throw new Exception("No Shared Parameter file set.\n" + ex.Message);
            }
            
            DefinitionFile sharedParametersFile;
            try
            {
                sharedParametersFile = doc.Application.OpenSharedParameterFile();

                //if (null == sharedParametersFile)
                //{
                //    sharedParametersFile = GetTempSharedParamsFile(doc.Application);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Cannnot open Shared Parameter file.\n" + ex.Message);
            }
            return sharedParametersFile;
        }

        public static DefinitionGroup GetCreateSharedParamsGroup(DefinitionFile sharedParametersFile, string groupName)
        {
            try
            {
                DefinitionGroup group = sharedParametersFile.Groups.get_Item(groupName);

                if (null == group)
                {
                    try
                    {
                        group = sharedParametersFile.Groups.Create(groupName);
                    }
                    catch (Exception)
                    {
                        group = null;
                    }
                }

                return group;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception creating Shared Parameter Group.\n" + ex.Message);
            }
        }

        public static Definition GetCreateSharedParamsDefinition(DefinitionGroup defGroup, ParameterType defType, string defName, bool visible)
        {
            Definition definition = defGroup.Definitions.get_Item(defName);

            if (null == definition)
            {
                try
                {
                    ExternalDefinitionCreationOptions opt = new ExternalDefinitionCreationOptions(defName, defType);
                    opt.Visible = visible;
                    definition = defGroup.Definitions.Create(opt); // 2015
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception creating Definition.\n" + ex.Message);
                }
            }
            return definition;
        }

        public static string SerializeBinaryData(BinaryVersions binVer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            bf.Serialize(stream, binVer);
            stream.Position = 0;

            long n2 = stream.Length;
            int n = (int)n2;
            byte[] buf = new byte[n];
            stream.Read(buf, 0, n);
            return System.Convert.ToBase64String(buf);
        }

        public static string SerializeBinaryString(string str)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            bf.Serialize(stream, str);
            stream.Position = 0;

            long n2 = stream.Length;
            int n = (int)n2;
            byte[] buf = new byte[n];
            stream.Read(buf, 0, n);
            return System.Convert.ToBase64String(buf);
        }

        public static string DeserializeBinaryString(string str)
        {
            try
            {
                MemoryStream s = new MemoryStream(Convert.FromBase64String(str));
                s.Position = 0;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Binder = new JtLinkBinder();

                return bf.Deserialize(s) as string;

            }
            catch (Exception ex)
            {
                string mess = ex.Message;
                return null;
            }
        }

        /*
        public static DefinitionFile GetTempSharedParamsFile(Application app)
        {
            try 
            {
                string fileNameOld = app.SharedParametersFilename;

                // Create and set new file and get its DefinitionFile
                string fileNameNew = string.Format("{0}\\{1}.txt", SpecialDirectories.MyDocuments, kTempSPFileName);
                // ALWAYS overwrite the old one! We don't want any "stale" old params in there! 
                //if (!File.Exists(fileNameNew))
                //{
                StreamWriter stream = new StreamWriter(fileNameNew);
                stream.Close();
                //}
                app.SharedParametersFilename = fileNameNew;
                DefinitionFile res = app.OpenSharedParameterFile();

                // Restore current file
                app.SharedParametersFilename = fileNameOld;

                // Return tmp. DefinitionFile
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Failed to set Temporary Shared Params File: " + ex.Message);
            }
        }
        */
    }
}


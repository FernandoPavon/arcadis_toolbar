using System;
using Newtonsoft.Json;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;
using System.Reflection;

using System.Windows.Media;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace ArcadisMain
{

    public class Utils
    {
        public static ArcadisRibbon s_arcadisRibbon = new ArcadisRibbon();
        public static IList<AssemblyVersion> s_assemblies = new List<AssemblyVersion>();

        //Repository
        public const string k_repository = "c:\\Arcadis_AddIn_Repository";
        //Tab Names
        public const string k_arcadisMainTab = "Arcadis Main"; 
        public const string k_arcadisToolsTab = "Arcadis Tools";
        //Panel Names
        public const string k_arcadisPanel = "Main Panel";
        public const string k_exportPanel = "Export Tools";
        public const string k_importPanel = "Import Tools";
        public const string k_dynamicPanel = "Dynamic Tools";
        public const string k_cablePanel = "Cable Tools";
        public const string k_electricalPanel = "Electrical Tools";

        public static string k_settings = "User Settings";

        public static UIControlledApplication g_controlledUIApp = null;
        public static string g_mainAssemblyPath = null;

        public static string k_systemLanguage = "";
        public static string k_systemCountry = "";
        public static string k_revitLanguage = "";
        public static string k_revitVersion = "";

        //Addin modules
        //-------------
        public const string k_cableAddin = "Cable_Panel.addin";
        public const string k_dynamicAddin = "DynamicTools.addin";
        public const string k_electricalAddin = "Electrical_Panel.addin";
        public const string k_exportAddin = "Export_Panel.addin";
        public const string k_importAddin = "Import_Panel.addin";
        //Addin loanded or not
        public static bool b_cableTools = false;
        public static bool b_electricalTools = false;
        public static bool b_exportTools = false;
        public static bool b_importTools = false;
        public static bool b_dynamicTools = false;

        public static Assembly DynamicTools = null;

        public static bool LoadAddin(string addin, bool loaded)
        {
            if (loaded) return true;

            string asspath = Path.GetDirectoryName(Utils.g_mainAssemblyPath);
            string path = Path.Combine(asspath, addin);
            try
            {
                g_controlledUIApp.LoadAddIn(path);
            }
            catch
            {
                Metrics.AppendLog("Error loading addin: " + addin);
            }

            return true;
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

                Transaction trans = new Transaction(doc);

                try
                {
                    trans.Start("Project Parameters");
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

        public static void CreateCommand(Autodesk.Revit.UI.RibbonPanel panel, ToolbarPanel toolPanel, string name, string title, string path, string com, Bitmap bitmap, string tooltip, Bitmap bitmapHelp, string longDesc, ContextualHelp contextHelp)
        {
            try
            {
                PushButton button = panel.AddItem(new PushButtonData(name, title, path, com)) as PushButton;
                button.LargeImage = ConvertBitmap(bitmap);
                button.ToolTip = tooltip;
                if (null != bitmapHelp) button.ToolTipImage = ConvertBitmap(bitmapHelp);
                button.LongDescription = longDesc;
                button.SetContextualHelp(contextHelp);
                toolPanel.Commands.Add(new ToolbarCommand(name, button, bitmap));
            }
            catch (Exception ex)
            {
                Metrics.AppendLog("Exception creating button: " + name + "\r\n" + ex.Message);
            }
        }

        public static BitmapImage ConvertBitmap(Bitmap bitmap)
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
                Metrics.AppendLog("Exception creating button image.\r\n" + ex.Message);
                return null;
            }
        }
    }

    //Assembly Classes
    [AttributeUsage(AttributeTargets.Assembly)]
    public  class AssemblyGeography : Attribute
    {
        public string Value { get; private set; }

        public AssemblyGeography() : this("") { }
        public AssemblyGeography(string value) { Value = value; }
    }
}


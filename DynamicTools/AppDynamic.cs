using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Reflection;
using Autodesk.Revit.UI;
using CommonTools;
using System.Drawing;
using System.Resources;
using System.Collections;


namespace DynamicTools
{
    class AppDynamic : IExternalApplication
    {
        DateTime m_startTime;
        
        public Result OnStartup(UIControlledApplication application)
        {
            if (Utils.b_dynamicTools) return Result.Succeeded;

            try
            {
                m_startTime = DateTime.Now;
                
                Assembly exeAssembly = Assembly.GetExecutingAssembly();
                DynUtils.g_DynamicPath = exeAssembly.Location;
                
                string locPath = DynUtils.g_DynamicPath;

                Bitmap bit1 = Properties.Resources.SixFaces;
                Bitmap bit2 = Properties.Resources.Bulb;

                CreateDynamicButtom(application, Utils.k_arcadisMainTab, DynUtils.g_DynamicPath, bit1);
                CreateDynamicButtom(application, Utils.k_arcadisToolsTab, DynUtils.g_DynamicPath, bit2);

                CreateContextButton("Modify");
                CreateContextButton("Structure");

                //Get Assembly Versions
                //DynUtils.g_DynamicTools_Version = exeAssembly.GetName().Version.ToString();

                Metrics.AppendLog("Launching Dynamic Tools Application");
                Metrics.AppendLog("Toolbar Tab: " );
                Metrics.AppendLog("Assembly Path: " + locPath);
                Metrics.AppendLog("Session Start: " + m_startTime.ToString());
                //Metrics.AppendLog("Dynamic Tools Version: " + DynUtils.g_DynamicTools_Version);

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Exception creating command button", ex.Message);
                Metrics.AppendLog("Exception Creating Toolbars: \r\n" + ex.Message);
                return Result.Failed;
            }
        }

        private void CreateContextButton(string tabName)
        {
            Autodesk.Windows.RibbonTab tab = Autodesk.Windows.ComponentManager.Ribbon.FindTab(tabName);
           
            var button = new Autodesk.Windows.RibbonButton
            {
                Id = "ID_DYN_BUTTON",
                Text = "My Button",
                Name = "My Name",
                ShowText = true,
                IsEnabled = true,
                IsVisible = true,
                IsToolTipEnabled = true,
                IsCheckable = true,
                ShowToolTipOnDisabled = true,
                MinHeight = 0,
                MinWidth = 0,
                ToolTip = "My dynamic command button",
                ShowImage = true,
                LargeImage = GetImage(),
                Size = Autodesk.Windows.RibbonItemSize.Large,
                Orientation = System.Windows.Controls.Orientation.Vertical
            };

            Autodesk.Windows.ComponentManager.UIElementActivated 
                += new EventHandler<Autodesk.Windows.UIElementActivatedEventArgs>(ComponentManager_UIElementActivated);

            var panelSource = new Autodesk.Windows.RibbonPanelSource
            {
                Title = "My Panel",
                Id = "ID_PANEL" 
            };

            panelSource.Items.Add(button);

            var panel = new Autodesk.Windows.RibbonPanel
            {
                Source = panelSource
            };

            tab.Panels.Add(panel);
           
        }

        void ComponentManager_UIElementActivated(object sender, Autodesk.Windows.UIElementActivatedEventArgs e)
        {
            if (e == null || e.Item == null || e.Item.Id == null) return;

            if(e.Item.Id == "ID_DYN_BUTTON")
            {
                TaskDialog.Show("Dynamic Command", "Dynamic command clicked");
            }
        }

        private void CreateDynamicButtom(UIControlledApplication application, string tab, string dllPath, Bitmap bitmap)
        {
            RibbonPanel panel = application.CreateRibbonPanel(tab, "Dynamic Tools");
            
            string strCommand = "DynamicTools.Dynamic_Command";

            PushButton button = panel.AddItem(new PushButtonData("Dynamic", "Dynamic", dllPath, strCommand)) as PushButton;
            button.LargeImage = ConvertBitmap(bitmap);
            button.ToolTip = "Dynamic test command button";
        }
        
        private BitmapImage GetImage()
        {
            Assembly DynamicTools = Assembly.LoadFile(DynUtils.g_DynamicPath);
            var stream = DynamicTools.GetManifestResourceStream(DynamicTools.GetName().Name + ".g.resources");

            if (stream != null)
            {
                var resourceReader = new ResourceReader(stream);

                foreach (DictionaryEntry resource in resourceReader)
                {
                    if (resource.Key.ToString().Contains("bulb"))
                    {
                        var uri = new Uri("/" + DynamicTools.GetName().Name + ";component/" + resource.Key.ToString(), UriKind.Relative);
                        return new BitmapImage(uri);
                    }
                }
            }

            return null;
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
            Metrics.AppendLog("Dynamic Tools Shutdown" );
            return Result.Succeeded;
        }
    }
}

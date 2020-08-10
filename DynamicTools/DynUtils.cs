using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;

namespace DynamicTools
{
    class DynUtils
    {
        public static string g_DynamicPath = "";
        public static string g_DynamicTools_Version = "Not loaded";

        public static Assembly DynamicTools = null;

        public static void CreateCommandImage(RibbonPanel panel,  string name, string title, string path, string com, BitmapImage bitImage, string tooltip)
        {
            try
            {
                PushButton button = panel.AddItem(new PushButtonData(name, title, path, com)) as PushButton;
                button.LargeImage = bitImage; // Convert(bitmap);
                button.ToolTip = tooltip;
                //toolPanel.Commands.Add(new ToolbarCommand(name, button));
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Exception creating command button", ex.Message);
                //Metrics.AppendLog("Exception creating button: " + name + "\r\n" + ex.Message);
            }
        }
    }
}

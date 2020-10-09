using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Autodesk.Revit.DB;


namespace ArcadisMain
{
    class MainUserPreferences
    {
        public MainUserPreferences()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            ToolsPath = string.Empty;
            ToolModules = new List<string>();
        }

        public string ToolsPath { get; set; }

        public IList<string> ToolModules { get; set; }

        // Get and save User Preferences
        public static MainUserPreferences GetUserPreferences()
        {
            MainUserPreferences userPreferences;

            try
            {
                Properties.Settings settings = Properties.Settings.Default;
                string json = settings.Settings_UserPreferences;

                if (json == "" || json == null)
                {
                    userPreferences = new MainUserPreferences();
                }
                else
                {
                    userPreferences = new JavaScriptSerializer().Deserialize<MainUserPreferences>(json);
                }

                return userPreferences;
            }
            catch (Exception ex)
            {
                Metrics.AppendLog("Exception in GetUserPreferences\r\n" + ex.Message);
                return null;
            }
        }

        public static void SaveUserPreferences(MainUserPreferences up)
        {
            string json = new JavaScriptSerializer().Serialize(up);

            Properties.Settings settings = Properties.Settings.Default;
            settings.Settings_UserPreferences = json;
            settings.Save();
        }
    }
}

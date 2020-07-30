using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using System.Web.Script.Serialization;

namespace ArcadisToolbar_I
{
    class Settings_UserPreferences
    {
        public static Settings_UserPreferences GetUserPreferences(Document doc)
        {
            Settings_UserPreferences userPreferences;

            try
            {
                Properties.Settings settings = Properties.Settings.Default;
                string json = settings.Settings_UserPreferences;

                if (json == "" || json == null)
                {
                    userPreferences = new Settings_UserPreferences();
                }
                else
                {
                    userPreferences = new JavaScriptSerializer().Deserialize<Settings_UserPreferences>(json);
                }

                return userPreferences;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static void SaveUserPreferences(Settings_UserPreferences up)
        {
            try
            {
                string json = new JavaScriptSerializer().Serialize(up);

                Properties.Settings settings = Properties.Settings.Default;
                settings.Settings_UserPreferences = json;
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}

using System.Configuration;
using System.Windows.Forms;

namespace RandomDraw
{
    class MyConfiguration
    {
        public static string fileName = Application.ExecutablePath;
        public static bool addSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
            config.AppSettings.Settings.Add(key, value);
            config.Save();
            return true;
        }
        public static string getSetting(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
            string value = config.AppSettings.Settings[key].Value;
            return value;
        }
        public static bool updateSeeting(string key, string newValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
            string value = config.AppSettings.Settings[key].Value = newValue;
            config.Save();
            return true;
        }
    }
}

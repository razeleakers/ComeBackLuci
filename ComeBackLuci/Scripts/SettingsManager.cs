using System;
using System.Text;
using ComeBackLuci.Properties;

namespace ComeBackLuci
{
    public static class SettingsManager
    {
        public static bool Setup
        {
            get { return bool.Parse(Settings.Default["Setup"].ToString()); }
            set { Settings.Default["Setup"] = value; }
        }

        public static string LastFile
        {
            get { return Settings.Default["LastFile"].ToString(); }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) Settings.Default["LastFile"] = string.Empty;
                else Settings.Default["LastFile"] = value;
            }
        }

        public static string ErrorDir
        {
            get { return Settings.Default["ErrorDir"].ToString(); }
            set 
            {
                if (string.IsNullOrWhiteSpace(value)) Settings.Default["ErrorDir"] = string.Empty;
                else Settings.Default["ErrorDir"] = value;
            }
        }

        public static string Webhook
        {
            get { return string.IsNullOrWhiteSpace(Settings.Default["Webhook"].ToString()) ? string.Empty : Encoding.Unicode.GetString(Convert.FromBase64String(Settings.Default["Webhook"].ToString())); }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) Settings.Default["Webhook"] = string.Empty;
                else Settings.Default["Webhook"] = Convert.ToBase64String(Encoding.Unicode.GetBytes(value));
            }

        }

        public static void Save()
        {
            Settings.Default.Save();
        }
    }
}

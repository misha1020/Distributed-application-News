using System.Configuration;
using System;

namespace NewsServiceLibrary
{
    class ConfigManager
    {
        public static string Get(string key)
        {
            if (ConfigurationManager.AppSettings[key] != null)
                return ConfigurationManager.AppSettings[key];
            else
                throw new ConfigurationErrorsException($"fielel {key} not found");
        }

        public static void AddOrUpdate(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                throw new ConfigurationErrorsException($"Failed to write {key}");
            }
        }
    }
}

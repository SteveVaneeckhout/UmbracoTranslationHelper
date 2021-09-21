using Microsoft.Win32;
using System;

namespace UmbracoTranslationHelper.Extensions
{
    public static class Settings
    {
        private static string GetSetting(string name)
        {
            using RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\UmbracoTranslationHelper");
            if (key != null)
            {
                return key.GetValue(name) as string;
            }

            return null;
        }

        private static void SaveSetting(string name, string value)
        {
            using RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\UmbracoTranslationHelper");
            key.SetValue(name, value);
        }

        public static string GetUmbracoSourcePath()
        {
            return GetSetting("UmbracoSourcePath");
        }

        public static void SaveUmbracoSourcePath(string path)
        {
            SaveSetting("UmbracoSourcePath", path);
        }

        public static string GetLeadingLanguage()
        {
            return GetSetting("LeadingLanguage");
        }

        public static void SaveLeadingLanguage(string leadingLanguage)
        {
            SaveSetting("LeadingLanguage", leadingLanguage);
        }
    }
}

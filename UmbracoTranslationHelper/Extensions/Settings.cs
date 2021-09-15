using Microsoft.Win32;
using System;

namespace UmbracoTranslationHelper.Extensions
{
    public static class Settings
    {
        public static readonly string[] DictionarySubDirectories = new string[] { @"src\Umbraco.Web.UI\umbraco\config\lang", @"umbraco\config\lang", "lang" };

        public static string GetSetting(string name)
        {
            using RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\UmbracoTranslationHelper");
            if (key != null)
            {
                return key.GetValue(name) as string;
            }

            return null;
        }

        public static void SaveSetting(string name, string value)
        {
            using RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\UmbracoTranslationHelper");
            key.SetValue(name, value);
        }
    }
}

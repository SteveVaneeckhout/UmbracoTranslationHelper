using Microsoft.Win32;
using System;

namespace UmbracoTranslationHelper.Extensions
{
    public static class Settings
    {
        public static string GetSetting(string name)
        {
            using RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\UmbracoTranslationHelper");
            if (key != null)
            {
                Object o = key.GetValue(name);
                return o.ToString();
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

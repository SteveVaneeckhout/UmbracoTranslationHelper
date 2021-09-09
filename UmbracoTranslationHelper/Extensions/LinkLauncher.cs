using System.Diagnostics;

namespace UmbracoTranslationHelper.Extensions
{
    public static class LinkLauncher
    {
        public static void Launch(string url)
        {
            using var browser = new Process();
            browser.StartInfo.FileName = url;
            browser.StartInfo.UseShellExecute = true;
            browser.Start();
        }
    }
}

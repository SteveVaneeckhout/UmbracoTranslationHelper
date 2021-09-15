using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UmbracoTranslationHelper.Extensions;

#pragma warning disable IDE1006 // Naming Styles

namespace UmbracoTranslationHelper
{
    public partial class SanitizeForm : Form
    {

        public SanitizeForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sanitizeButton_Click(object sender, EventArgs e)
        {
            var leadingLanguageFileName = Settings.GetSetting("LeadingLanguage");
            var dictionariesDirectory = Settings.GetSetting("UmbracoSourcePath");
            var files = Directory.GetFiles(dictionariesDirectory, "*.xml");
            var exceptions = new Dictionary<string, string>();

            var leading = LanguageFile.Deserialize(files.First(f => Path.GetFileName(f) == leadingLanguageFileName));

            LanguageFile.Serialize(leading, dictionariesDirectory);
            foreach (var file in files.Where(f => Path.GetFileName(f) != leadingLanguageFileName))
            {
                try
                {
                    var dictionary = LanguageFile.Deserialize(file, leading.Translations);
                    LanguageFile.Serialize(dictionary, dictionariesDirectory);
                }
                catch (Exception ex)
                {
                    exceptions.Add(Path.GetFileName(file), ex.Message);
                }
            }

            if (exceptions.Count > 0)
            {
                errorsLabel.Text = "Errors:\r\n";

                foreach (var item in exceptions)
                {
                    errorsLabel.Text += item.Key + ": " + item.Value + "\r\n";
                }

                errorsLabel.Visible = true;
            }
            else
            {
                errorsLabel.Text = "All dictionaries sanitized!";
                errorsLabel.Visible = true;
            }
        }
    }
}

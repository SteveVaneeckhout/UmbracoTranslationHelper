using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles

namespace UmbracoTranslationHelper
{
    public partial class SanitizeForm : Form
    {
        private readonly string _dictionariesDirectory;

        public SanitizeForm(string dictionariesDirectory)
        {
            InitializeComponent();
            _dictionariesDirectory = dictionariesDirectory;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sanitizeButton_Click(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(_dictionariesDirectory, "*.xml");
            var exceptions = new Dictionary<string, string>();

            var leading = LanguageFile.Deserialize(files.Single(f => f.EndsWith("en_us.xml")));

            foreach (var file in files.Where(f => !f.EndsWith("en_us.xml")))
            {
                try
                {
                    var dictionary = LanguageFile.Deserialize(file, leading.Translations);
                    LanguageFile.Serialize(dictionary, _dictionariesDirectory);
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UmbracoTranslationHelper.Extensions;
using UmbracoTranslationHelper.Models;

#pragma warning disable IDE1006 // Naming Styles

namespace UmbracoTranslationHelper
{
    public partial class OptionsForm : Form
    {
        private readonly string[] DictionarySubDirectories = new string[] { @"src\Umbraco.Core\EmbeddedResources\Lang\", @"src\Umbraco.Web.UI\umbraco\config\lang", @"umbraco\config\lang", "lang" };

        public OptionsForm()
        {
            InitializeComponent();

            var sourcePath = Settings.GetUmbracoSourcePath();

            if (sourcePath != null)
            {
                sourcePathTextbox.Text = sourcePath;
                LoadLanguages(sourcePath, Settings.GetLeadingLanguage());
            }

            okButton.Enabled = leadingLanguagesComboBox.SelectedItem != null;
        }

        private void LoadLanguages(string sourcePath, string selectedLanguage = null)
        {
            var files = Directory.GetFiles(sourcePath, "*.xml");
            var languageFiles = new List<LanguageFile>();

            foreach (var file in files)
            {
                try
                {
                    languageFiles.Add(LanguageFile.Deserialize(file));
                }
                catch (Exception)
                {
                    MessageBox.Show($"File is corrupt: {file}");
                }
            }

            var comboBoxItems = languageFiles.Select(lf => new ComboBoxItem() { Text = $"{lf.Language} ({lf.Culture})", Value = lf.FileName }).ToArray();

            leadingLanguagesComboBox.Items.Clear();
            leadingLanguagesComboBox.Items.AddRange(comboBoxItems);

            if (sourcePath.Contains(@"umbraco\config\lang"))
            {
                // Leading language for Umbraco is en_us.xml
                leadingLanguagesComboBox.SelectedItem = comboBoxItems.FirstOrDefault(l => l.Value == "en_us.xml");
                leadingLanguagesComboBox.Enabled = false;
            }
            else if (selectedLanguage != null)
            {
                leadingLanguagesComboBox.SelectedItem = comboBoxItems.FirstOrDefault(l => l.Value == selectedLanguage);
                leadingLanguagesComboBox.Enabled = true;
            }
            else
            {
                leadingLanguagesComboBox.Enabled = true;
            }

            okButton.Enabled = leadingLanguagesComboBox.SelectedItem != null;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                var newDirectory = folderBrowserDialog.SelectedPath;

                if (Directory.GetFiles(newDirectory, "*.xml").Length == 0)
                {
                    // dictionaries not found, try subdirectories.
                    var dictionariesFound = false;

                    foreach (var subdir in DictionarySubDirectories)
                    {
                        newDirectory = Path.Combine(folderBrowserDialog.SelectedPath, subdir);

                        if (Directory.Exists(newDirectory) && Directory.GetFiles(newDirectory, "*.xml").Length > 0)
                        {
                            dictionariesFound = true;
                            break;
                        }
                    }

                    if (!dictionariesFound)
                    {
                        MessageBox.Show(this, "No language files found in " + folderBrowserDialog.SelectedPath, "Files not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        sourcePathTextbox.Text = newDirectory;
                        LoadLanguages(newDirectory);
                    }
                }
                else
                {
                    sourcePathTextbox.Text = newDirectory;
                    LoadLanguages(newDirectory);
                }
            }
        }

        private void leadingLanguagesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            okButton.Enabled = leadingLanguagesComboBox.SelectedItem != null;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Settings.SaveUmbracoSourcePath(sourcePathTextbox.Text);
            Settings.SaveLeadingLanguage(((ComboBoxItem)leadingLanguagesComboBox.SelectedItem).Value);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

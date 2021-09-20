using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UmbracoTranslationHelper.Extensions;
using UmbracoTranslationHelper.Models;

#pragma warning disable IDE1006 // Naming Styles

namespace UmbracoTranslationHelper
{
    public partial class MainForm : Form
    {
        private const string TitleBar = "Umbraco Package & Backoffice Translation Tool";

        private LanguageFile Original { get; set; }
        private LanguageFile Translations { get; set; }
        private string UmbracoSourcePath { get; set; }

        public MainForm()
        {
            InitializeComponent();

            fileSaveMenuItem.Enabled = false;
            fileCloseMenuItem.Enabled = false;

            UmbracoSourcePath = Settings.GetUmbracoSourcePath();

            if (UmbracoSourcePath == null)
            {
                fileNewMenuItem.Enabled = false;
                fileOpenMenuItem.Enabled = false;
            }
        }

        private void onlyNontranslationsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void RefreshListView()
        {
            if (Original == null || Translations == null)
            {
                return;
            }

            var groups = new List<ListViewGroup>();
            var items = new List<ListViewItem>();

            foreach (var area in Original.Translations.Areas)
            {
                var group = new ListViewGroup(area.Alias);

                foreach (var word in area.Keys)
                {
                    var item = new ListViewItem(word.Alias)
                    {
                        Tag = area.Alias + "|" + word.Alias
                    };

                    item.SubItems.Add(word.Value.Limit(50));

                    // Try to find translation
                    var translationArea = Translations.Translations.Areas.FirstOrDefault(a => a.Alias == area.Alias);
                    bool hasTranslation = false;

                    if (translationArea != null)
                    {
                        var translatedWord = translationArea.Keys.FirstOrDefault(k => k.Alias == word.Alias);

                        if (translatedWord != null)
                        {
                            hasTranslation = true;
                            item.SubItems.Add(translatedWord.Value.Limit(50));
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                        }
                    }
                    else
                    {
                        item.SubItems.Add(string.Empty);
                    }

                    if (!onlyNontranslationsCheckbox.Checked || (onlyNontranslationsCheckbox.Checked && !hasTranslation))
                    {
                        group.Items.Add(item);
                        items.Add(item);
                    }
                }

                if (group.Items.Count > 0)
                {
                    groups.Add(group);
                }
            }

            wordsListView.BeginUpdate();
            wordsListView.Items.Clear();
            wordsListView.Groups.AddRange(groups.ToArray());
            wordsListView.Items.AddRange(items.ToArray());
            wordsListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            wordsListView.EndUpdate();
        }

        private void RefreshListViewSelectedItem(LanguageAreaKey key)
        {
            var item = wordsListView.SelectedItems[0];

            item.SubItems[2].Text = key.Value;
        }

        /// <summary>
        /// Closes and unloads the document.
        /// </summary>
        /// <returns>Returns true when document is closed, false when document close was cancelled by the user</returns>
        private bool CloseDocument()
        {
            if (Translations != null && Translations.IsDirty)
            {
                var result = MessageBox.Show(this, "Do you want to save the changes in this translation?", "Save changes", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.Yes:
                        SaveDocument();
                        break;
                    case DialogResult.No:
                    default:
                        break;
                }
            }

            wordsListView.Groups.Clear();
            wordsListView.Items.Clear();
            Original = null;
            Translations = null;
            onlyNontranslationsCheckbox.Checked = false;
            fileSaveMenuItem.Enabled = false;
            fileCloseMenuItem.Enabled = false;

            SetFormTitle();

            return true;
        }

        private void SaveDocument()
        {
            LanguageFile.Serialize(Translations, UmbracoSourcePath);
            Translations.IsDirty = false;
            SetFormTitle();
        }

        private static string GenerateTitle(LanguageFile l, int translationCount)
        {
            var percent = ((decimal)l.TranslationCount / translationCount) * 100;

            return $"{l.Language} ({l.Culture}) - {percent:0}% complete";
        }

        private void wordsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenTranslationForm();
        }

        private void wordsListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                OpenTranslationForm();
            }
        }

        private void OpenTranslationForm()
        {
            if (wordsListView.SelectedItems.Count > 0)
            {
                // area.alias + "|" + word.alias;
                string[] tagParts = wordsListView.SelectedItems[0].Tag.ToString().Split('|');
                var originalKey = Original.Translations.Areas.First(a => a.Alias == tagParts[0]).Keys.First(k => k.Alias == tagParts[1]);
                var translation = Translations.Translations.Areas.FirstOrDefault(a => a.Alias == tagParts[0])?.Keys.FirstOrDefault(k => k.Alias == tagParts[1])?.Value;

                var form = new TranslationEditorForm()
                {
                    AreaAlias = tagParts[0],
                    Alias = tagParts[1],
                    Original = originalKey.Value,
                    Translation = translation,
                    TranslationCulture = Translations.Translations.Alias
                };

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var area = Translations.Translations.Areas.FirstOrDefault(a => a.Alias == form.AreaAlias);

                    if (area == null)
                    {
                        // create area and key
                        area = new LanguageArea()
                        {
                            Alias = form.AreaAlias,
                            Keys = new List<LanguageAreaKey>()
                        };

                        Translations.Translations.Areas.Add(area);
                    }

                    var key = area.Keys.FirstOrDefault(k => k.Alias == form.Alias);

                    if (key == null)
                    {
                        // create key
                        key = new LanguageAreaKey()
                        {
                            Alias = form.Alias,
                            Version = originalKey.Version
                        };

                        area.Keys.Add(key);
                    }

                    if (key.Value != form.Translation)
                    {
                        key.Value = form.Translation;
                        Translations.IsDirty = true;
                        SetFormTitle();
                        RefreshListViewSelectedItem(key);
                    }
                }
                form.Dispose();
            }
        }

        private void SetFormTitle()
        {
            Text = TitleBar + (Translations == null ? string.Empty : " - " + Translations.Translations.LocalName + (Translations.IsDirty ? "*" : string.Empty));
        }

        /* File menu */
        private void fileNewMenuItem_Click(object sender, EventArgs e)
        {
            var isClosed = CloseDocument();

            if (!isClosed)
            {
                return;
            }

            var newFileForm = new NewFileForm();
            if (newFileForm.ShowDialog() == DialogResult.OK)
            {
                if (UmbracoSourcePath == null)
                {
                    if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        if (Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.xml").Length == 0)
                        {
                            // dictionaries not found, try subdirectories.

                            foreach (var subdir in Settings.DictionarySubDirectories)
                            {
                                var newDirectory = Path.Combine(folderBrowserDialog.SelectedPath, subdir);
                                if (Directory.GetFiles(newDirectory, "*.xml").Length > 0)
                                {
                                    UmbracoSourcePath = newDirectory;
                                    Settings.SaveUmbracoSourcePath(UmbracoSourcePath);

                                    break;
                                }
                            }

                            if (UmbracoSourcePath == null)
                            {
                                MessageBox.Show(this, "No dictionaries found in " + folderBrowserDialog.SelectedPath, "Files not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }

                if (UmbracoSourcePath != null)
                {
                    if (Directory.Exists(UmbracoSourcePath))
                    {
                        var leadingLanguageFileName = Settings.GetLeadingLanguage();
                        var files = Directory.GetFiles(UmbracoSourcePath, "*.xml");
                        var languageFiles = new List<LanguageFile>();

                        if (files.Any(f => Path.GetFileName(f) == leadingLanguageFileName))
                        {
                            this.Translations = newFileForm.LanguageFile;
                            this.Original = LanguageFile.Deserialize(files.Single(f => Path.GetFileName(f) == leadingLanguageFileName));
                        }

                        fileSaveMenuItem.Enabled = true;
                        fileCloseMenuItem.Enabled = true;

                        SetFormTitle();
                        RefreshListView();
                    }
                    else
                    {
                        MessageBox.Show(this, "Directory with language files not found at: " + UmbracoSourcePath, "Directory not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            newFileForm.Dispose();
        }

        private void fileOpenMenuItem_Click(object sender, EventArgs e)
        {
            var isClosed = CloseDocument();

            if (!isClosed)
            {
                return;
            }

            if (UmbracoSourcePath == null)
            {
                if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.xml").Length == 0)
                    {
                        // dictionaries not found, try subdirectories.

                        foreach (var subdir in Settings.DictionarySubDirectories)
                        {
                            var newDirectory = Path.Combine(folderBrowserDialog.SelectedPath, subdir);
                            if (Directory.GetFiles(newDirectory, "*.xml").Length > 0)
                            {
                                UmbracoSourcePath = newDirectory;
                                Settings.SaveUmbracoSourcePath(UmbracoSourcePath);

                                break;
                            }
                        }

                        if (UmbracoSourcePath == null)
                        {
                            MessageBox.Show(this, "No dictionaries found in " + folderBrowserDialog.SelectedPath, "Files not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            if (UmbracoSourcePath != null)
            {
                if (Directory.Exists(UmbracoSourcePath))
                {
                    var files = Directory.GetFiles(UmbracoSourcePath, "*.xml");
                    var languageFiles = new List<LanguageFile>();

                    var leadingLanguageFileName = Settings.GetLeadingLanguage();
                    LanguageFile leading = null;

                    if (files.Any(f => Path.GetFileName(f) == leadingLanguageFileName))
                    {
                        leading = LanguageFile.Deserialize(files.FirstOrDefault(f => Path.GetFileName(f) == leadingLanguageFileName));
                    }

                    if (leading == null)
                    {
                        MessageBox.Show(this, "Could not find main dictionary file.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (var file in files.Where(f => Path.GetFileName(f) != leadingLanguageFileName))
                    {
                        try
                        {
                            languageFiles.Add(LanguageFile.Deserialize(file, leading.Translations));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show($"File is corrupt: {file}");
                        }
                    }

                    var languageChoiceForm = new LanguageChoice(languageFiles.Select(l => new ComboBoxItem() { Value = l.Culture, Text = GenerateTitle(l, leading.TranslationCount) })
                                                                             .OrderBy(ld => ld.Text)
                                                                             .ToArray());

                    if (languageChoiceForm.ShowDialog(this) == DialogResult.OK)
                    {
                        Original = leading;
                        Translations = languageFiles.FirstOrDefault(l => l.Culture == languageChoiceForm.SelectedLanguage);

                        SetFormTitle();

                        fileSaveMenuItem.Enabled = true;
                        fileCloseMenuItem.Enabled = true;

                        RefreshListView();
                    }
                    languageChoiceForm.Dispose();
                }
                else
                {
                    MessageBox.Show(this, "Directory with language files not found at: " + UmbracoSourcePath, "Directory not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void fileSaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void fileCloseMenuItem_Click(object sender, EventArgs e)
        {
            CloseDocument();
        }

        private void fileExitMenuItem_Click(object sender, EventArgs e)
        {
            CloseDocument();
            Close();
        }

        /* Tools menu */
        private void sanitizeDictionaryFilesMenuItem_Click(object sender, EventArgs e)
        {
            var isClosed = CloseDocument();

            if (!isClosed)
            {
                return;
            }

            var sanitizeForm = new SanitizeForm();

            sanitizeForm.ShowDialog();
            sanitizeForm.Dispose();
        }

        private void optionsMenuItem_Click(object sender, EventArgs e)
        {
            var isClosed = CloseDocument();

            if (!isClosed)
            {
                return;
            }

            var optionsForm = new OptionsForm();
            if (optionsForm.ShowDialog(this) == DialogResult.OK)
            {
                UmbracoSourcePath = Settings.GetUmbracoSourcePath();

                fileNewMenuItem.Enabled = true;
                fileOpenMenuItem.Enabled = true;
            }
            optionsForm.Dispose();
        }

        /* Help menu */
        private void helpCheckForUpdateMenuItem_Click(object sender, EventArgs e)
        {
            LinkLauncher.Launch("https://github.com/SteveVaneeckhout/UmbracoTranslationHelper/releases");
        }
        private void helpAboutMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();

            aboutForm.ShowDialog(this);
            aboutForm.Dispose();
        }
    }
}

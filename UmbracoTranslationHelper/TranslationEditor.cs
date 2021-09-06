using System;
using System.Diagnostics;
using System.Web;
using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles

namespace UmbracoTranslationHelper
{
    public partial class TranslationEditorForm : Form
    {
        private string alias;

        public string AreaAlias { get; set; }
        public string Alias
        {
            get => alias;
            set
            {
                alias = value;
                Text = "Translate " + alias;
            }
        }

        public string Original
        {
            get
            {
                return originalTextbox.Text;
            }
            set
            {
                originalTextbox.Text = value;

                // Allow Enter and Tab keys to be used in the editor in case of newlines.
                translationTextbox.AcceptsReturn = value.Contains('\r');
                translationTextbox.AcceptsTab = value.Contains('\r');
            }
        }

        public string Translation
        {
            get
            {
                return translationTextbox.Text;
            }
            set
            {
                translationTextbox.Text = value;
            }
        }

        public string TranslationCulture { get; set; }

        public TranslationEditorForm()
        {
            InitializeComponent();
        }

        private void TranslationEditorForm_Shown(object sender, EventArgs e)
        {
            translationTextbox.Focus();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void translationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using var browser = new Process();
            browser.StartInfo.FileName = $"https://translate.google.com/?sl=en&tl={TranslationCulture}&text={HttpUtility.UrlEncode(this.Original)}&op=translate";
            browser.StartInfo.UseShellExecute = true;
            browser.Start();
        }
    }
}

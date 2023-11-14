using System;
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
                translationTextbox.ScrollBars = value.Contains('\r') ? ScrollBars.Both : ScrollBars.None;
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

            okButton.Enabled = false;
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
            var language = TranslationCulture[..2];

            Extensions.LinkLauncher.Launch($"https://translate.google.com/?sl=en&tl={language}&text={HttpUtility.UrlEncode(this.Original)}&op=translate");
        }

        private void translationTextbox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !string.IsNullOrEmpty(translationTextbox.Text);
        }
    }
}

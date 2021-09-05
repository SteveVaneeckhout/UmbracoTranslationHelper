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

        private void Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void translationLinkLabel_Click(object sender, EventArgs e)
        {
            using var compiler = new Process();
            compiler.StartInfo.FileName = $"https://translate.google.com/?sl=en&tl={TranslationCulture}&text={HttpUtility.UrlEncode(this.Original)}&op=translate";
            compiler.StartInfo.UseShellExecute = true;
            compiler.Start();
        }
    }
}

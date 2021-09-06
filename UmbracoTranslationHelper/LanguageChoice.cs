using System;
using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles

namespace UmbracoTranslationHelper
{
    public partial class LanguageChoice : Form
    {
        public LanguageChoice(LanguageDisplay[] languages)
        {
            InitializeComponent();

            languagesListbox.Items.AddRange(languages);
            okButton.Enabled = false;
        }

        public string SelectedLanguage => ((LanguageDisplay)languagesListbox.SelectedItem).Culture;

        private void Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void languagesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            okButton.Enabled = languagesListbox.SelectedItem != null;
        }

        private void languagesListbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LanguageChoice_Shown(object sender, EventArgs e)
        {
            languagesListbox.Focus();
        }
    }
}

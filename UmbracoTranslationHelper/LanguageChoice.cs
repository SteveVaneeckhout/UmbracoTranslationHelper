using System;
using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles

namespace UmbracoTranslationHelper
{
    public partial class LanguageChoice : Form
    {
        public LanguageChoice(LanguageDisplay[] files)
        {
            InitializeComponent();

            languagesListbox.Items.AddRange(files);
            okButton.Enabled = false;
        }

        public string SelectedLanguage => ((LanguageDisplay)languagesListbox.SelectedItem).Culture;

        private void Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void languagesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languagesListbox.SelectedItem != null)
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }

        private void languagesListbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

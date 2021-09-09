using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles

namespace UmbracoTranslationHelper
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            versionContentLabel.Text = Application.ProductVersion;
        }

        private void repositoryValueLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Extensions.LinkLauncher.Launch("https://github.com/SteveVaneeckhout/UmbracoTranslationHelper");
        }

        private void umbracoRepositoryValueLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Extensions.LinkLauncher.Launch("https://github.com/umbraco/Umbraco-CMS");
        }

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}

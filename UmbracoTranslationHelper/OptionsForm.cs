using System;
using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles

namespace UmbracoTranslationHelper
{
    public partial class OptionsForm : Form
    {
        public string SourcePath
        {
            get
            {
                return sourcePathTextbox.Text;
            }
            set
            {
                sourcePathTextbox.Text = value;
            }
        }

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                SourcePath = folderBrowserDialog.SelectedPath;
            }
        }
    }
}

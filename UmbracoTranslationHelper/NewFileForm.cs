using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmbracoTranslationHelper.Models;

#pragma warning disable IDE1006 // Naming Styles

namespace UmbracoTranslationHelper
{
    public partial class NewFileForm : Form
    {
        public LanguageFile LanguageFile { get; set; }

        public NewFileForm()
        {
            InitializeComponent();

            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
                                      .Select(c => new Item()
                                      {
                                          Display = c.DisplayName + " - " + c.Name,
                                          Value = c
                                      })
                                      .OrderBy(c => c.Display)
                                      .ToArray();

            cultureComboBox.Items.AddRange(cultures.ToArray());
            cultureComboBox.DisplayMember = "Display";
            cultureComboBox.ValueMember = "Value";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var culture = ((Item)cultureComboBox.SelectedItem).Value;

            LanguageFile = new LanguageFile()
            {
                FileName = culture.TwoLetterISOLanguageName + ".xml",
                Translations = new Language()
                {
                    Alias = culture.TwoLetterISOLanguageName,
                    IntName = culture.EnglishName,
                    LocalName = culture.NativeName,
                    Culture = culture.Name,
                    Lcid = culture.LCID.ToString(),
                    Creator = new LanguageCreator()
                    {
                        Name = "The Umbraco community",
                        Link = "https://our.umbraco.com/documentation/Extending-Umbraco/Language-Files"
                    }
                }
            };

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private class Item
        {
            public string Display { get; set; }
            public CultureInfo Value { get; set; }
        }
    }
}

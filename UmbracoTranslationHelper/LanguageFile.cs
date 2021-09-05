using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UmbracoTranslationHelper.Models;

namespace UmbracoTranslationHelper
{
    public class LanguageFile
    {
        public string Culture => Translations.Culture;
        public string Language => Translations.IntName;
        public int TranslationCount => Translations.Areas.Sum(a => a.Keys.Count);
        public Language Translations { get; set; }

        public static LanguageFile Deserialize(string filename)
        {
            var serializer = new XmlSerializer(typeof(Language));
            var result = new LanguageFile();

            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                result.Translations = (Language)serializer.Deserialize(reader);
            }

            return result;
        }

        public static void Serialize(LanguageFile language, string path)
        {
            var file = language.Translations;
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                Encoding = new UTF8Encoding(false) // no BOM
            };

            using Stream fs = new FileStream(Path.Combine(path, file.Alias + ".xml"), FileMode.Create);
            using XmlWriter writer = XmlTextWriter.Create(fs, settings);

            // Manually generate document because key values only use a <![CDATA[ ]]> when the value contains HTML.
            writer.WriteStartDocument(true);

            writer.WriteStartElement("language");
            writer.WriteAttributeString("alias", file.Alias);
            writer.WriteAttributeString("intName", file.IntName);
            writer.WriteAttributeString("localName", file.LocalName);
            writer.WriteAttributeString("lcid", file.Lcid);
            writer.WriteAttributeString("culture", file.Culture);

            // Creator
            writer.WriteStartElement("creator");
            writer.WriteElementString("name", file.Creator.Name);
            writer.WriteElementString("link", file.Creator.Link);
            writer.WriteEndElement();

            // Areas
            foreach (var area in file.Areas)
            {
                writer.WriteStartElement("area");
                writer.WriteAttributeString("alias", area.Alias);

                // Keys
                foreach (var key in area.Keys)
                {
                    writer.WriteStartElement("key");
                    writer.WriteAttributeString("alias", key.Alias);

                    if (key.Version != null)
                    {
                        writer.WriteAttributeString("version", key.Version);
                    }

                    // Use CDATA if value contains HTML elements.
                    if (key.Value.Contains('<') || key.Value.Contains('>'))
                    {
                        writer.WriteCData(key.Value);
                    }
                    else
                    {
                        writer.WriteString(key.Value);
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
    }
}

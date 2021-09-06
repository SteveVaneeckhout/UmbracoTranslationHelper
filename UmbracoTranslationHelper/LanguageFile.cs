using System;
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
            var result = new Language();

            XmlDocument document = new();
            document.Load(filename);

            result.Alias = document.DocumentElement.GetAttribute("alias");
            result.IntName = document.DocumentElement.GetAttribute("intName");
            result.LocalName = document.DocumentElement.GetAttribute("localName");
            result.Lcid = document.DocumentElement.GetAttribute("lcid");
            result.Culture = document.DocumentElement.GetAttribute("culture");

            foreach (XmlNode areaNode in document.DocumentElement.ChildNodes)
            {
                if (areaNode.Name == "creator")
                {
                    foreach (XmlNode creatorNode in areaNode.ChildNodes)
                    {
                        if (creatorNode.Name == "name")
                        {
                            result.Creator.Name = creatorNode.InnerText;
                        }
                        else if (creatorNode.Name == "link")
                        {
                            result.Creator.Link = creatorNode.InnerText;
                        }
                    }

                    continue;
                }

                if (areaNode.Name != "area")
                {
                    continue;
                }

                var area = new LanguageArea
                {
                    Alias = areaNode.Attributes["alias"].Value
                };

                foreach (XmlNode key in areaNode.ChildNodes)
                {
                    if (key.NodeType == XmlNodeType.Text)
                    {
                        // Useless text outside elements, ignore
                        continue;
                    }
                    if (key.NodeType == XmlNodeType.Comment)
                    {
                        area.Keys.Add(new LanguageAreaKey()
                        {
                            Comments = key.Value
                        });
                        continue;
                    }

                    try
                    {
                        var newKey = new LanguageAreaKey()
                        {
                            Alias = key.Attributes["alias"].Value,
                            Version = key.Attributes["version"]?.Value,
                            Value = key.InnerText
                        };

                        area.Keys.Add(newKey);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }
                }

                result.Areas.Add(area);
            }

            return new LanguageFile() { Translations = result };
        }

        public static void Serialize(Language dictionary, string path)
        {
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                Encoding = new UTF8Encoding(false) // no BOM
            };

            using Stream fs = new FileStream(Path.Combine(path, dictionary.Alias + ".xml"), FileMode.Create);
            using XmlWriter writer = XmlTextWriter.Create(fs, settings);

            // Manually generate document because key values only use a <![CDATA[ ]]> when the value contains HTML.
            writer.WriteStartDocument(true);

            writer.WriteStartElement("language");
            writer.WriteAttributeString("alias", dictionary.Alias);
            writer.WriteAttributeString("intName", dictionary.IntName);
            writer.WriteAttributeString("localName", dictionary.LocalName);
            writer.WriteAttributeString("lcid", dictionary.Lcid);
            writer.WriteAttributeString("culture", dictionary.Culture);

            // Creator
            writer.WriteStartElement("creator");
            writer.WriteElementString("name", dictionary.Creator.Name);
            writer.WriteElementString("link", dictionary.Creator.Link);
            writer.WriteEndElement();

            // Areas
            foreach (var area in dictionary.Areas)
            {
                writer.WriteStartElement("area");
                writer.WriteAttributeString("alias", area.Alias);

                // Keys
                foreach (var key in area.Keys)
                {
                    if (key.Comments != null)
                    {
                        writer.WriteComment(key.Comments);

                        continue;
                    }

                    writer.WriteStartElement("key");
                    writer.WriteAttributeString("alias", key.Alias);

                    if (key.Version != null)
                    {
                        writer.WriteAttributeString("version", key.Version);
                    }

                    // Use CDATA if value contains HTML elements or newlines.
                    if (key.Value.Contains('<') || key.Value.Contains('>') || key.Value.Contains('\r'))
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

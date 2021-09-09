﻿using System;
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
        public string FileName { get; set; }
        public Language Translations { get; set; }

        public static LanguageFile Deserialize(string filename, Language leading = null)
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

                // Check for duplicate areas and if it exists in the leading file
                if (result.Areas.Any(a => a.Alias == area.Alias) || (leading != null && !leading.Areas.Any(a => a.Alias == area.Alias)))
                {
                    continue;
                }

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

                        // Check for duplicate keys and if it exists in the leading file
                        if (!area.Keys.Any(k => k.Alias == newKey.Alias)
                            && (leading == null
                                || leading.Areas.Single(a => a.Alias == area.Alias).Keys
                                                .Any(k => k.Alias == newKey.Alias)))
                        {
                            area.Keys.Add(newKey);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }
                }

                result.Areas.Add(area);
            }

            return new LanguageFile() { FileName = Path.GetFileName(filename), Translations = result };
        }

        public static void Serialize(LanguageFile languageFile, string path)
        {
            var translations = languageFile.Translations;

            var settings = new XmlWriterSettings()
            {
                Indent = true,
                Encoding = new UTF8Encoding(false) // no BOM
            };

            using Stream fs = new FileStream(Path.Combine(path, languageFile.FileName), FileMode.Create);
            using XmlWriter writer = XmlTextWriter.Create(fs, settings);

            // Manually generate document because key values only use a <![CDATA[ ]]> when the value contains HTML.
            writer.WriteStartDocument(true);

            writer.WriteStartElement("language");
            writer.WriteAttributeString("alias", translations.Alias);
            writer.WriteAttributeString("intName", translations.IntName);
            writer.WriteAttributeString("localName", translations.LocalName);
            writer.WriteAttributeString("lcid", translations.Lcid);
            writer.WriteAttributeString("culture", translations.Culture);

            // Creator
            writer.WriteStartElement("creator");
            writer.WriteElementString("name", translations.Creator.Name);
            writer.WriteElementString("link", translations.Creator.Link);
            writer.WriteEndElement();

            // Areas
            foreach (var area in translations.Areas)
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

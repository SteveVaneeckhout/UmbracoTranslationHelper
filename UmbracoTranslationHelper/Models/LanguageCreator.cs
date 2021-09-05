using System;
using System.Xml;
using System.Xml.Serialization;

namespace UmbracoTranslationHelper.Models
{
    [Serializable()]
    [XmlType(AnonymousType = true)]
    public class LanguageCreator
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }
    }
}
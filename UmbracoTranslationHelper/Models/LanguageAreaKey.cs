using System;
using System.Xml;
using System.Xml.Serialization;

namespace UmbracoTranslationHelper.Models
{
    [Serializable()]
    [XmlType(AnonymousType = true)]
    public class LanguageAreaKey
    {
        [XmlAttribute("alias")]
        public string Alias { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlText()]
        public string Value { get; set; }
    }
}
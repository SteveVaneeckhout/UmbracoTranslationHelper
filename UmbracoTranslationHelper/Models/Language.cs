using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace UmbracoTranslationHelper.Models
{
    [Serializable()]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "language", Namespace = "", IsNullable = false)]
    public class Language
    {
        [XmlElement("creator")]
        public LanguageCreator Creator { get; set; }

        [XmlElement("area")]
        public List<LanguageArea> Areas { get; set; }

        [XmlAttribute("alias")]
        public string Alias { get; set; }

        [XmlAttribute("intName")]
        public string IntName { get; set; }

        [XmlAttribute("localName")]
        public string LocalName { get; set; }

        [XmlAttribute("lcid")]
        public string Lcid { get; set; }

        [XmlAttribute("culture")]
        public string Culture { get; set; }
    }
}
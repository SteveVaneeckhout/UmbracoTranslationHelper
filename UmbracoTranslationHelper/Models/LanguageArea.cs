using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace UmbracoTranslationHelper.Models
{
    [Serializable()]
    [XmlType(AnonymousType = true)]
    public class LanguageArea
    {
        [XmlElement("key")]
        public List<LanguageAreaKey> Keys { get; set; }

        [XmlAttribute("alias")]
        public string Alias { get; set; }
    }
}
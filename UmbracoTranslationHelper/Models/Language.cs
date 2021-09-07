using System.Collections.Generic;

namespace UmbracoTranslationHelper.Models
{
    public class Dictionary
    {
        public LanguageCreator Creator { get; set; } = new LanguageCreator();
        public List<LanguageArea> Areas { get; set; } = new List<LanguageArea>();
        public string Alias { get; set; }
        public string IntName { get; set; }
        public string LocalName { get; set; }
        public string Lcid { get; set; }
        public string Culture { get; set; }
    }
}

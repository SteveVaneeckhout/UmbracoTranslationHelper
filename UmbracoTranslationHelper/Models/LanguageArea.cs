using System.Collections.Generic;

namespace UmbracoTranslationHelper.Models
{
    public class LanguageArea
    {
        public List<LanguageAreaKey> Keys { get; set; } = new List<LanguageAreaKey>();

        public string Alias { get; set; }
    }
}

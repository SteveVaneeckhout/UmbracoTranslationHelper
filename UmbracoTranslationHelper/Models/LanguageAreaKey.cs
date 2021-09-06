namespace UmbracoTranslationHelper.Models
{
    public class LanguageAreaKey
    {
        public string Alias { get; set; }
        public string Version { get; set; }
        public string Value { get; set; }

        /// <summary>
        /// This propert is used if there is only a comment instead of a key element.
        /// </summary>
        public string Comments { get; set; }
    }
}

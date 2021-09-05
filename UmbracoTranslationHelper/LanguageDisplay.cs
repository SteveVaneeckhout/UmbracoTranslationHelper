namespace UmbracoTranslationHelper
{
    public class LanguageDisplay
    {
        public string Culture { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}

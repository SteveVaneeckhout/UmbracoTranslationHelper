namespace UmbracoTranslationHelper.Extensions
{
    public static class StringExtensions
    {
        public static string Limit(this string word, int chars)
        {
            if (string.IsNullOrEmpty(word) || word.Length <= chars)
            {
                return word;
            }

            return word.Substring(0, chars) + "...";
        }
    }
}

namespace UmbracoTranslationHelper.Extensions
{
    public static class StringExtensions
    {
        public static string Limit(this string word, int chars)
        {
            if (word is null)
            {
                return "";
            }

            var tmpWord = word.Trim();

            if (tmpWord == "" || tmpWord.Length <= chars)
            {
                return tmpWord;
            }

            return tmpWord.Substring(0, chars) + "…";
        }
    }
}

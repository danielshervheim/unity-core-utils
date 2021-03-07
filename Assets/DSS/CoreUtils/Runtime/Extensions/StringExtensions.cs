namespace DSS.CoreUtils.Extensions
{
    // @brief A collection of String extension methods.
    public static class StringExtensions
    {
        // @brief Returns a the string with the first letter capitalized.
        public static string FirstLetterUppercase(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }

    // Source(s)
    // ---------
    // FirstLetterUppercase
    // stackoverflow user "Carlos Muñoz"
    // https://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-with-maximum-performance
}
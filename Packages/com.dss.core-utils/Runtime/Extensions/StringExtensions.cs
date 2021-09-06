using System;
using System.Text;

namespace DSS.CoreUtils.Extensions
{

// @brief A collection of String extension methods.
public static class StringExtensions
{
    // @brief Returns the given string, with the first letter capitalized.
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

    // @brief Returns the given string, with the (first instance of the) given substring removed from it
    public static string RemoveSubstring(this string str, string substr)
    {
        return str.Remove(str.IndexOf(substr)) + str.Substring(str.IndexOf(substr) + substr.Length);
    }

    // @brief Reduces all back-to-back white-space characters to a single white-space character.
    public static string ReduceWhitespace(this string value)
    {
        var newString = new StringBuilder();
        bool previousIsWhitespace = false;
        for (int i = 0; i < value.Length; i++)
        {
            if (Char.IsWhiteSpace(value[i]))
            {
                if (previousIsWhitespace)
                {
                    continue;
                }

                previousIsWhitespace = true;
            }
            else
            {
                previousIsWhitespace = false;
            }

            newString.Append(value[i]);
        }

        return newString.ToString();
    }
}

// Source(s)
// ---------
//
// FirstLetterUppercase
// stackoverflow user "Carlos Muñoz"
// https://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-with-maximum-performance
//
// ReduceWhiteSpace
// stackoverflow user "ScubaSteve"
// https://stackoverflow.com/questions/206717/how-do-i-replace-multiple-spaces-with-a-single-space-in-c


}  // namespace DSS.CoreUtils.Extensions

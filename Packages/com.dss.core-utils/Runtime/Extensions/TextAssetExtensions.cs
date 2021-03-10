using UnityEngine;

namespace DSS.CoreUtils.Extensions
{
    // @brief A collection of TextAsset extension methods.
    public static class TextAssetExtensions
    {
        // @brief Returns a string array of the lines in this TextAsset.
        public static string[] Lines(this TextAsset textAsset)
        {
            return textAsset.text.Split('\n');
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace DSS.ColorPalettes
{
    // @brief Contains a list of key-color value pairs, to keep a color theme consistent across a project.
    [CreateAssetMenu(fileName = "New Color Palette", menuName = "DSS/Color Palettes/Color Palette", order = 1)]
    public class ColorPalette : ScriptableObject
    {
        [System.Serializable]
        public struct Entry
        {
            public string name;
            public Color color;
        }

        // @brief the list of key-color value pairs.
        [SerializeField] List<Entry> entries = default;

        protected static readonly Color defaultColor = new Color(1f,0f,1f,1f);

        // @brief Returns the color of the specified key, or
        // pink if the key isn't defined for this palette.
        public virtual Color GetColor(string key)
        {
            foreach (Entry entry in entries)
            {
                if (entry.name.Equals(key))
                {
                    return entry.color;
                }
            }
            return defaultColor;
        }
    }
}
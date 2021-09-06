using UnityEngine;
using UnityEngine.UI;

namespace DSS.CoreUtils.Extensions
{
    // @brief A collection of RectTransform extension methods.
    public static class GraphicExtensions
    {
        // @brief Sets this graphic color's R channel.
        public static void SetR(this Graphic graphic, float r)
        {
            graphic.color = new Color(r, graphic.color.g, graphic.color.b, graphic.color.a);
        }

        // @brief Returns this graphic color's R channel.
        public static float GetR(this Graphic graphic)
        {
            return graphic.color.r;
        }

        // @brief Sets this graphic color's G channel.
        public static void SetG(this Graphic graphic, float g)
        {
            graphic.color = new Color(graphic.color.r, g, graphic.color.b, graphic.color.a);
        }

        // @brief Returns this graphic color's G channel.
        public static float GetG(this Graphic graphic)
        {
            return graphic.color.g;
        }

        // @brief Sets this graphic color's B channel.
        public static void SetB(this Graphic graphic, float b)
        {
            graphic.color = new Color(graphic.color.r, graphic.color.g, b, graphic.color.a);
        }

        // @brief Returns this graphic color's B channel.
        public static float GetB(this Graphic graphic)
        {
            return graphic.color.b;
        }

        // @brief Sets this graphic color's alpha channel.
        public static void SetA(this Graphic graphic, float a)
        {
            graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, a);
        }

        // @brief Returns this graphic color's alpha channel.
        public static float GetA(this Graphic graphic)
        {
            return graphic.color.a;
        }
    }
}
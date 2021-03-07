using UnityEngine;

namespace DSS.CoreUtils.Extensions
{
    // @brief A collection of Transform extension methods.
    public static class TransformExtensions
    {
        public static void SetLocalScaleX(this Transform t, float x)
        {
            t.localScale = new Vector3(x, t.localScale.y, t.localScale.z);
        }

        public static void SetLocalScaleY(this Transform t, float y)
        {
            t.localScale = new Vector3(t.localScale.x, y, t.localScale.z);
        }

        public static void SetLocalScaleZ(this Transform t, float z)
        {
            t.localScale = new Vector3(t.localScale.x, t.localScale.y, z);
        }  
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace DSS.CoreUtils.Extensions
{

// @brief A collection of Transform extension methods.
public static class TransformExtensions
{
    // @brief Sets Transform.localScale.x to the given value.
    public static void SetLocalScaleX(this Transform t, float x)
    {
        t.localScale = new Vector3(x, t.localScale.y, t.localScale.z);
    }

    // @brief Sets Transform.localScale.y to the given value.
    public static void SetLocalScaleY(this Transform t, float y)
    {
        t.localScale = new Vector3(t.localScale.x, y, t.localScale.z);
    }

    // @brief Sets Transform.localScale.z to the given value.
    public static void SetLocalScaleZ(this Transform t, float z)
    {
        t.localScale = new Vector3(t.localScale.x, t.localScale.y, z);
    }  

    // @brief Returns a flattened list of the given transform and all its descendants.
    public static List<Transform> Flatten(this Transform root)
    {
        List<Transform> flattened = new List<Transform>();
        FlattenRecursively(root, flattened);
        return flattened; 
    }

    // Helper for Flatten()
    private static void FlattenRecursively(Transform root, List<Transform> list)
    {
        list.Add(root);
        foreach (Transform t in root)
        {
            FlattenRecursively(t, list);
        }
    }

    // @brief Resets the given transform to the world-space identity.
    public static void Reset(this Transform root)
    {
        root.position = Vector3.zero;
        root.rotation = Quaternion.identity;
        root.localScale = Vector3.one;
    }

    // @brief Resets the given transform to its local-space identity.
    public static void ResetLocal(this Transform root)
    {
        root.localPosition = Vector3.zero;
        root.localRotation = Quaternion.identity;
        root.localScale = Vector3.one;
    }

    // @brief Returns a unix-like path describing this transforms position in its parent hierarchy.
    public static string GetPath(this Transform t)
    {
        string path = "";
        Transform cur = t;
        while (cur != null)
        {
            path = cur.gameObject.name + "/" + path;
            cur = cur.parent; 
        }
        return path;
    }
}

}  // namespace DSS.CoreUtils.Extensions
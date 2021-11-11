using UnityEngine;

namespace DSS.CoreUtils.Extensions
{

// @brief A collection of GameObject extension methods.
public static class GameObjectExtensions
{
    public static void EnableGameObject(this GameObject go)
    {
        go.SetActive(true);
    }

    public static void DisableGameObject(this GameObject go)
    {
        go.SetActive(false);
    }

    public static void ToggleGameObject(this GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }
}

}  // namespace DSS.CoreUtils.Extensions
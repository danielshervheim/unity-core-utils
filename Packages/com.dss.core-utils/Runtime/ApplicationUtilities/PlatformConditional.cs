using System.Collections.Generic;
using UnityEngine;

namespace DSS.CoreUtils.ApplicationUtilities
{
    // @brief Enables / disables the gameObject based on the current platform.
    public class PlatformConditional : MonoBehaviour
    {
        // @brief This gameObject will be disabled if the game is run on any of these platforms.
        [SerializeField] private List<RuntimePlatform> disableOnPlatforms;

        private void Awake()
        {
            if (disableOnPlatforms.Contains(Application.platform))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
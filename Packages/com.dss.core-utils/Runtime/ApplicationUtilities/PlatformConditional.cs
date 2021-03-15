using System.Collections.Generic;
using UnityEngine;

namespace DSS.CoreUtils.ApplicationUtilities
{
    // @brief Enables / disables the gameObject based on the current platform.
    [AddComponentMenu("DSS/Application Utilities/Platform Conditional")]	
    public class PlatformConditional : MonoBehaviour
    {
        public enum Behaviour { DisableIf, DisableIfNot };

        // @brief The list of platforms to check against.
        [SerializeField] private List<RuntimePlatform> platforms = default;

        // @brief The behaviour if the list of platforms contains the current platform.
        [SerializeField] private Behaviour behaviour = Behaviour.DisableIf;

        private void Awake()
        {
            if (behaviour == Behaviour.DisableIf)
            {
                if (platforms.Contains(Application.platform))
                {
                    this.gameObject.SetActive(false);
                }
            }
            else if (behaviour == Behaviour.DisableIfNot)
            {
                if (!platforms.Contains(Application.platform))
                {
                    this.gameObject.SetActive(false);
                }
            }  
        }
    }
}
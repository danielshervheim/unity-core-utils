using UnityEngine;
using UnityEngine.EventSystems;

namespace DSS.CoreUtils.ApplicationUtilities
{
    // @brief Exposes a method to open a URL in the users web browser.
    [AddComponentMenu("DSS/Application Utilities/Open URL")]	
    public class OpenURL : MonoBehaviour
    {
        [SerializeField] string url = "https://www.google.com/";

        public void Open()
        {
            Open(url);
        }

        public void Open(string alternateUrl)
        {
            Application.OpenURL(alternateUrl);
        }
    }
}
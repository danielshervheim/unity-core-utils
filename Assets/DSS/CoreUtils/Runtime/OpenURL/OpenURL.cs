using UnityEngine;
using UnityEngine.EventSystems;

namespace DSS.CoreUtils
{
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
using UnityEngine;

namespace DSS.CoreUtils.ApplicationUtilities
{
    // @brief Exposes a method to quit the application.
    [AddComponentMenu("DSS/Application Utilities/Quiter")]	
    public class Quiter : MonoBehaviour
    {
        public void Quit()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
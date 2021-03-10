using UnityEngine;

namespace DSS.CoreUtils.ApplicationUtilities
{
    // @brief Sets the Application's target framerate when the scene first loads.
    public class SetTargetFrameRate : MonoBehaviour
    {
        // @brief The target framerate.
        [SerializeField] int targetFrameRate = 60;

        // @brief Wether or not to destroy this component after setting the framerate.
        [SerializeField] bool destroyAfterSetting = true;

        // @brief Wether or not to prevent setting the framerate in WebGL, which can cause slowdowns.
        [SerializeField] bool preventInWebGL = true;

        void Start()
        {
            // Note: there is a bug in the WebGL exporter that causes it to run
            // super slow if you try and manually set the framerate.
            if (preventInWebGL)
            {
                #if !(UNITY_WEBGL)
                    Application.targetFrameRate = targetFrameRate;
                #endif
            }
            else
            {
                Application.targetFrameRate = targetFrameRate;
            }
            

            if (destroyAfterSetting)
            {
                Destroy(this);
            }
        }
    }
}
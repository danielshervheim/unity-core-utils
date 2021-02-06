using UnityEngine;

namespace DSS.SetTargetFrameRate
{
    // @brief Sets the Application's target framerate when the scene first loads.
    public class SetTargetFrameRate : MonoBehaviour
    {
        // @brief The target framerate.
        [SerializeField] int targetFrameRate = 60;

        // @brief Wether or not to destroy this component after setting the framerate.
        [SerializeField] bool destroyAfterSetting = true;

        void Start()
        {
            Application.targetFrameRate = targetFrameRate;

            if (destroyAfterSetting)
            {
                Destroy(this);
            }
        }
    }
}
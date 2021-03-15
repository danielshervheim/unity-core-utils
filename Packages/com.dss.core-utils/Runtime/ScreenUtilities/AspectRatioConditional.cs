using UnityEngine;

namespace DSS.CoreUtils.ScreenUtilities
{
    // @brief Enables / disables the gameObject based on the screen's aspect ratio.
    // (This is useful for having certain UI elements only appear in portrait vs landscape
    // mode, for example).
    [AddComponentMenu("DSS/Screen Utilities/Aspect Ratio Conditional")]	
    public class AspectRatioConditional : MonoBehaviour
    {
        private enum EnabledRequirement { Portrait, Landscape };

        // @brief The screen watcher reference to listen to events from.
        [SerializeField] private ScreenWatcher screenWatcher = default;

        // @brief This gameObjects behaviour.
        [SerializeField] private EnabledRequirement enabledWhenScreenIs = EnabledRequirement.Portrait;

        private void Start()
        {
            screenWatcher.onAspectRatioChange.AddListener(AspectRatioChanged);

            // Set the active status initially.
            AspectRatioChanged(screenWatcher.AspectRatio);
        }

        private void AspectRatioChanged(float aspectRatio)
        {
            if (aspectRatio < 1f)
            {
                gameObject.SetActive(enabledWhenScreenIs == EnabledRequirement.Portrait);
            }
            else
            {
                gameObject.SetActive(enabledWhenScreenIs == EnabledRequirement.Landscape);
            }
        }
    }
}
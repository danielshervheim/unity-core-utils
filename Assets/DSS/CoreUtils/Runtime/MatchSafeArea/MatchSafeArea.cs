using UnityEngine;
using static DSS.Extensions.RectTransformExtensions;

namespace DSS.CoreUtils
{
    // @brief Resizes the attached RectTransform to match the Screen's safe area.
    // (For non-notched devices, this essentially does nothing).
    [RequireComponent(typeof(RectTransform))]
    [ExecuteInEditMode]
    public class MatchSafeArea : MonoBehaviour
    {
        // @brief The RectTransform to resize.
        [SerializeField] RectTransform target = default;

        // @brief The top-most Canvas containing the target RectTransform.
        [SerializeField] Canvas targetCanvas = default;

        int width = 0;
        int height = 0;
        Rect safeArea = new Rect();

        void Update()
        {
            if (target == null || targetCanvas == null)
            {
                return;
            }

            if (NeedsMatching())
            {
                Match();
            }

        }

        bool NeedsMatching()
        {
            return width != Screen.width ||
                   height != Screen.height ||
                   safeArea != Screen.safeArea;
        }

        void Match()
        {
            width = Screen.width;
            height = Screen.height;
            safeArea = Screen.safeArea;

            Vector2 anchorMin = Screen.safeArea.position;
            Vector2 anchorMax = Screen.safeArea.position + Screen.safeArea.size;

            anchorMin.x /= targetCanvas.pixelRect.width;
            anchorMin.y /= targetCanvas.pixelRect.height;
            anchorMax.x /= targetCanvas.pixelRect.width;
            anchorMax.y /= targetCanvas.pixelRect.height;

            target.anchorMin = anchorMin;
            target.anchorMax = anchorMax;
            target.SetLeft(0f);
            target.SetRight(0f);
            target.SetTop(0f);
            target.SetBottom(0f);
        }

        public void UseThisRectTransform()
        {
            target = GetComponent<RectTransform>();
        }

        public void UseThisCanvas()
        {
            Canvas[] c = GetComponentsInParent<Canvas>();
            if (c.Length > 0)
            {
                targetCanvas = c[c.Length-1];
            }
        }

    }

    // Source(s)
    // ---------
    // https://connect.unity.com/p/updating-your-gui-for-the-iphone-x-and-other-notched-devices
}
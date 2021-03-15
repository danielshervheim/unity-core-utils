using UnityEngine;
using static DSS.CoreUtils.Extensions.RectTransformExtensions;

namespace DSS.CoreUtils.ScreenUtilities
{
    // @brief Expands the RectTransform to fill out as much of its parent as possible,
    // without expanding past the safe area.
    [RequireComponent(typeof(RectTransform))]
    [ExecuteInEditMode]
    public class CropToSafeArea : MonoBehaviour
    {
        // @brief The RectTransform to resize.
        [SerializeField] private RectTransform target = default;

        private Vector2 min;
        private Vector2 max;

        public void UseThisRectTransform()
        {
            target = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (target == null)
            {
                return;
            }

            target.Expand();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(target, Screen.safeArea.min, null, out min);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(target, Screen.safeArea.max, null, out max);
            max = target.rect.max-max;  // make it relative to max, instead of min

            target.Expand();
            target.SetLeft(Mathf.Max(0f, min.x));
            target.SetRight(Mathf.Max(0f, max.x));
            target.SetBottom(Mathf.Max(0f, min.y));
            target.SetTop(Mathf.Max(0f, max.y));
        }

        
    }
}
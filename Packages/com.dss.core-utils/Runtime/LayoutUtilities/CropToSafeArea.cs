using UnityEngine;
using UnityEngine.UI;

using static DSS.CoreUtils.Extensions.RectTransformExtensions;

namespace DSS.CoreUtils.LayoutUtilities
{
    // @brief Expands the RectTransform to fill out as much of its parent as possible,
    // without expanding past the safe area.
    [AddComponentMenu("DSS/Layout Utilities/Crop To Safe Area")]
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform))]
    public class CropToSafeArea : MonoBehaviour, ILayoutSelfController
    {
        [System.NonSerialized] private RectTransform m_rect;
        private DrivenRectTransformTracker m_tracker;

        private Rect cachedSafeArea;

        // private property to get the RectTransform.
        private RectTransform rectTransform
        {
            get
            {
                if (m_rect == null)
                {
                    m_rect = GetComponent<RectTransform>();
                }
                return m_rect;
            }
        }

        private void OnEnable()
        {
            cachedSafeArea = Screen.safeArea;
            SetDirty();
        }

        private void Update()
        {
            if (cachedSafeArea != Screen.safeArea)
            {
                cachedSafeArea = Screen.safeArea;
                SetDirty();
            }
        }

        private void OnDisable()
        {
            m_tracker.Clear();
        }

        public void SetLayoutHorizontal()
        {
            m_tracker.Clear();

            StartLayout();
        }

        public void SetLayoutVertical()
        {
            FinishLayout();
        }

        private void StartLayout()
        {
            // Add the horizontal properties to the tracker.
            m_tracker.Add(this, rectTransform, DrivenTransformProperties.All);

            // Expand the rect initially, around the minimum point (0,0).
            rectTransform.Reset();
            rectTransform.ExpandAtPivot(Vector2.zero);

            // Compute the safe area boundaries in local space.
            Vector2 min, max;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Screen.safeArea.min, null, out min);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Screen.safeArea.max, null, out max);
            max = rectTransform.rect.max-max;

            // Set the horizontal offsets.
            rectTransform.SetLeft(Mathf.Max(0f, min.x));
            rectTransform.SetRight(Mathf.Max(0f, max.x));
        }

        private void FinishLayout()
        {
            // Compute the safe area boundaries in local space.
            Vector2 min, max;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Screen.safeArea.min, null, out min);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Screen.safeArea.max, null, out max);
            max = rectTransform.rect.max-max;

            // Set the vertical offsets.
            rectTransform.SetBottom(Mathf.Max(0f, min.y));
            rectTransform.SetTop(Mathf.Max(0f, max.y));
        }

        private void SetDirty()
        {
            if (!this.enabled)
            {
                return;
            }
            LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
        }

        #if UNITY_EDITOR
        private void OnValidate()
        {
            SetDirty();
        }
        #endif
    }
}

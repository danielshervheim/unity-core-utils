using UnityEngine;
using UnityEngine.UI;

using static DSS.CoreUtils.Extensions.RectTransformExtensions;

namespace DSS.CoreUtils.LayoutUtilities
{
    // @brief Snaps a RectTransform to 100% of its parent width (or height)
    // if its width (or height) becomes more than a certain percent of its
    // parent width (or height).
    // Think of it as a CSS media-query type of thing.
    [AddComponentMenu("DSS/Layout Utilities/Snap Rect")]	
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform))]
    public class SnapRect : MonoBehaviour, ILayoutSelfController
    {
        public enum Mode { Absolute, Relative };

        [SerializeField] private bool snapWidth = false;
        [SerializeField] private Mode widthMode = Mode.Absolute;

        [SerializeField][Range(0f,1f)] private float targetWidthRelative = 0.5f;
        [SerializeField] private float snapAtWidthAbsolute = 500f;

        [SerializeField] private float targetWidthAbsolute = 100f;
        [SerializeField][Range(0f,1f)] private float snapAtWidthRelative = 0.5f;

        [SerializeField] private bool snapHeight = false;
        [SerializeField] private Mode heightMode = Mode.Absolute;

        [SerializeField][Range(0f,1f)] private float targetHeightRelative = 0.5f;
        [SerializeField] private float snapAtHeightAbsolute = 500f;

        [SerializeField] private float targetHeightAbsolute = 100f;
        [SerializeField][Range(0f,1f)] private float snapAtHeightRelative = 0.5f;

        [System.NonSerialized] private RectTransform m_rect;
        [System.NonSerialized] private RectTransform m_parentRect;
        private DrivenRectTransformTracker m_tracker;

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
        private RectTransform parentRectTransform
        {
            get
            {
                if (m_parentRect == null)
                {
                    m_parentRect = rectTransform.parent.GetComponent<RectTransform>();
                }
                return m_parentRect;
            }
        }

        private void OnEnable()
        {
            SetDirty();
        }

        private void OnDisable()
        {
            m_tracker.Clear();
        }

        public void SetLayoutHorizontal()
        {
            m_tracker.Clear();

            UpdateLayout(0);
        }

        public void SetLayoutVertical()
        {
            UpdateLayout(1);
        }

        private void UpdateLayout(int axis)
        {
            // Verify and prepare horizontal axis.
            if (axis == 0)
            {
                if (!snapWidth)
                {
                    return;
                }
                m_tracker.Add(this, rectTransform, DrivenTransformProperties.SizeDeltaX |
                                                   DrivenTransformProperties.AnchorMinX |
                                                   DrivenTransformProperties.AnchorMaxX |
                                                   DrivenTransformProperties.AnchoredPositionX);
                rectTransform.SetAnchorMinX(rectTransform.GetPivotX());
                rectTransform.SetAnchorMaxX(rectTransform.GetPivotX());
                rectTransform.SetAnchoredPositionX(0f);
            }

            // Verify and prepare vertical axis.
            if (axis == 1)
            {
                if (!snapHeight)
                {
                    return;
                }
                m_tracker.Add(this, rectTransform, DrivenTransformProperties.SizeDeltaY |
                                                   DrivenTransformProperties.AnchorMinY |
                                                   DrivenTransformProperties.AnchorMaxY |
                                                   DrivenTransformProperties.AnchoredPositionY);
                rectTransform.SetAnchorMinY(rectTransform.GetPivotY());
                rectTransform.SetAnchorMaxY(rectTransform.GetPivotY());
                rectTransform.SetAnchoredPositionY(0f);
            }

            // Compute the sizes to be working with.
            Vector2 sizeDelta = rectTransform.sizeDelta;
            Mode mode = (axis == 0) ? widthMode : heightMode;

            float targetAbsolute = (axis == 0) ? targetWidthAbsolute : targetHeightAbsolute;
            float targetRelative = (axis == 0) ? targetWidthRelative : targetHeightRelative;
            
            float snapAtAbsolute = (axis == 0) ? snapAtWidthAbsolute : snapAtHeightAbsolute;
            float snapAtRelative = (axis == 0) ? snapAtWidthRelative : snapAtHeightRelative;

            if (mode == Mode.Absolute)
            {
                if (targetAbsolute > snapAtRelative*parentRectTransform.rect.size[axis])
                {
                    sizeDelta[axis] = parentRectTransform.rect.size[axis];
                }
                else
                {
                    sizeDelta[axis] = targetAbsolute;
                }
            }
            else if (mode == Mode.Relative)
            {
                if (targetRelative*parentRectTransform.rect.size[axis] > snapAtAbsolute)
                {
                    sizeDelta[axis] = parentRectTransform.rect.size[axis];
                }
                else
                {
                    sizeDelta[axis] = targetRelative*parentRectTransform.rect.size[axis];
                }
            }   

            // Set the size delta.
            rectTransform.sizeDelta = sizeDelta;
        }

        private void SetDirty()
        {
            if (!gameObject.activeSelf)
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

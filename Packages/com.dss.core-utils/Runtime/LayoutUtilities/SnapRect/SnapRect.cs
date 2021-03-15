using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSS.CoreUtils.LayoutUtilities
{
    // @brief Snaps a RectTransform to 100% of its parent width (or height)
    // if its width (or height) becomes more than a certain percent of its
    // parent width (or height).
    // Think of it as a CSS media-query type of thing.
    [AddComponentMenu("DSS/Layout Utilities/Snap Rect")]	
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform))]
    public class SnapRect : MonoBehaviour
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

        private RectTransform rect;
        private RectTransform parentRect;

        private void Update()
        {
            if (rect == null)
            {
                rect = GetComponent<RectTransform>();
            }
            if (parentRect == null)
            {
                parentRect = transform.parent.GetComponent<RectTransform>();
            }

            if (snapWidth)
            {
                Vector2 sizeDelta = rect.sizeDelta;
                
                if (widthMode == Mode.Absolute)
                {
                    if (targetWidthAbsolute > snapAtWidthRelative*parentRect.rect.size.x)
                    {
                        sizeDelta.x = parentRect.rect.size.x;
                    }
                    else
                    {
                        sizeDelta.x = targetWidthAbsolute;
                    }
                }
                else if (widthMode == Mode.Relative)
                {
                    if (targetWidthRelative*parentRect.rect.size.x > snapAtWidthAbsolute)
                    {
                        sizeDelta.x = parentRect.rect.size.x;
                    }
                    else
                    {
                        sizeDelta.x = targetWidthRelative*parentRect.rect.size.x;
                    }
                }

                rect.sizeDelta = sizeDelta;
            }


            if (snapHeight)
            {
                Vector2 sizeDelta = rect.sizeDelta;
                
                if (heightMode == Mode.Absolute)
                {
                    if (targetHeightAbsolute > snapAtHeightRelative*parentRect.rect.size.y)
                    {
                        sizeDelta.y = parentRect.rect.size.y;
                    }
                    else
                    {
                        sizeDelta.y = targetHeightAbsolute;
                    }
                }
                else if (heightMode == Mode.Relative)
                {
                    if (targetHeightRelative*parentRect.rect.size.y > snapAtHeightAbsolute)
                    {
                        sizeDelta.y = parentRect.rect.size.y;
                    }
                    else
                    {
                        sizeDelta.y = targetHeightRelative*parentRect.rect.size.y;
                    }
                }

                rect.sizeDelta = sizeDelta;
            }
        }
    }
}

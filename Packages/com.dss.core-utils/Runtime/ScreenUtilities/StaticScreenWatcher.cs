using System;
using UnityEngine;

namespace DSS.CoreUtils.ScreenUtilities
{
    public class StaticScreenWatcher
    {
        // @brief The most recently cached screen safe area.
        public Rect SafeArea
        {
            get { return cachedSafeArea; }
        }

        // @brief The most recently cached screen aspect ratio.
        public float AspectRatio
        {
            get { return cachedAspectRatio; }
        }

        // @brief The most recently cached screen size.
        public Vector2 ScreenSize
        {
            get { return new Vector2(cachedWidth, cachedHeight); }
        }

        private float cachedWidth = 0f;
        private float cachedHeight = 0f;
        private float cachedAspectRatio = 0f;
        private Rect cachedSafeArea = new Rect();
        
        public StaticScreenWatcher()
        {
            // Cache the initial values.
            cachedWidth = Screen.width;
            cachedHeight = Screen.height;
            cachedAspectRatio = cachedWidth/cachedHeight;
            cachedSafeArea = Screen.safeArea;
        }

        public bool CheckForChange()
        {
            bool changed = false;

            if (cachedWidth != Screen.width || cachedHeight != Screen.height)
            {
                cachedWidth = Screen.width;
                cachedHeight = Screen.height;
                changed = true;
            }

            if (cachedWidth/cachedHeight!= cachedAspectRatio)
            {
                cachedAspectRatio = cachedWidth/cachedHeight;
                changed = true;                
            }

            if (cachedSafeArea != Screen.safeArea)
            {
                cachedSafeArea = Screen.safeArea;
                changed = true;
            }

            return changed;
        }
    }
}
using UnityEngine;
using UnityEngine.Events;

namespace DSS.CoreUtils
{
    // @brief Listens for changes in the screen properties.
    // (Useful for UI stuff).
    public class ScreenWatcher : MonoBehaviour
    {
        public class SafeAreaChangeEvent : UnityEvent<Rect> { };
        public class AspectRatioChangeEvent : UnityEvent<float> { };
        public class ScreenSizeChangeEvent : UnityEvent<Vector2> { };

        // @brief Invoked when the safe area changes.
        public SafeAreaChangeEvent onSafeAreaChange = new SafeAreaChangeEvent();

        // @brief Invoked when the aspect ratio changes.
        public AspectRatioChangeEvent onAspectRatioChange = new AspectRatioChangeEvent();

        // @brief Invoked when the screen size changes.
        public ScreenSizeChangeEvent onScreenSizeChange = new ScreenSizeChangeEvent();

        // @brief The most recently cached screen safe area.
        public Rect SafeArea
        {
            get
            {
                return cachedSafeArea;
            }
        }

        // @brief The most recently cached screen aspect ratio.
        public float AspectRatio
        {
            get
            {
                return cachedAspectRatio;
            }
        }

        // @brief The most recently cached screen size.
        public Vector2 ScreenSize
        {
            get
            {
                return new Vector2(cachedWidth, cachedHeight);
            }
        }


        private float cachedWidth = 0f;
        private float cachedHeight = 0f;
        private float cachedAspectRatio = 0f;
        private Rect cachedSafeArea = new Rect();
        
        private void Awake()
        {
            // Cache the initial values.
            cachedWidth = Screen.width;
            cachedHeight = Screen.height;
            cachedAspectRatio = cachedWidth/cachedHeight;
            cachedSafeArea = Screen.safeArea;
        }

        private void Update()
        {
            // Check if any of them have changed, and if so, fire the appropriate event(s).
            if (cachedWidth != Screen.width || cachedHeight != Screen.height)
            {
                cachedWidth = Screen.width;
                cachedHeight = Screen.height;
                onScreenSizeChange.Invoke(new Vector2(cachedWidth, cachedHeight));
            }

            if (cachedWidth/cachedHeight!= cachedAspectRatio)
            {
                cachedAspectRatio = cachedWidth/cachedHeight;
                onAspectRatioChange.Invoke(cachedAspectRatio);
            }

            if (cachedSafeArea != Screen.safeArea)
            {
                cachedSafeArea = Screen.safeArea;
                onSafeAreaChange.Invoke(cachedSafeArea);
            }
        }
    }
}
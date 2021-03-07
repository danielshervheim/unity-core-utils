using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

using static DSS.CoreUtils.Extensions.RectTransformExtensions;
using static DSS.CoreUtils.Extensions.TransformExtensions;
using DSS.CoreUtils.ScreenUtilities;
using DSS.CoreUtils;
using DSS.CoreUtils.Tweening;

namespace DSS.SceneLoader
{
    public class LoadingScreen : MonoBehaviour
    {
        [Header("Required References")]
        [SerializeField] CanvasGroupTweener background;
        [SerializeField] MatchSafeArea safeAreaMatcher;
        [SerializeField] RectTransform loadingBarContainer;
        [SerializeField] RectTransform loadingBar;

        [Header("Options")]
        [SerializeField] float loadingBarContainerScaleDuration = 0.125f;

        void Awake()
        {
            if (safeAreaMatcher != null)
            {
                safeAreaMatcher.UseThisRectTransform();
                safeAreaMatcher.UseThisCanvas();
            }

            loadingBar.localScale = new Vector3(0f, 1f, 1f);

            RectTransform rt = GetComponent<RectTransform>();
            if (rt != null)
            {
                rt.Expand(0f);
            }
        }

        public IEnumerator Setup()
        {
            // Set the initial loading bar dimensions.
            loadingBar.SetLocalScaleX(0f);
            loadingBarContainer.SetLocalScaleY(0f);

            // Wait for the background to show.
            background.Show();
            yield return background.GetUnderlyingCoroutine();

            // Scale up the loading bar container.
            float t = 0f;
            while (t <= 1f)
            {
                loadingBarContainer.SetLocalScaleY(t);
                t += Time.deltaTime / loadingBarContainerScaleDuration;
                yield return null;
            }
            loadingBarContainer.SetLocalScaleY(1f);
        }

        public IEnumerator Teardown()
        {
            float t = 1f;
            while (t >= 1f)
            {
                loadingBarContainer.SetLocalScaleY(t);
                t -= Time.deltaTime / loadingBarContainerScaleDuration;
                yield return null;
            }
            loadingBarContainer.SetLocalScaleY(0f);

            /*
            // Set the initial loading bar dimensions.
            loadingBar.SetLocalScaleX(0f);
            loadingBarContainer.SetLocalScaleY(0f);

            // Wait for the background to show.
            background.Show();
            yield return background.GetUnderlyingCoroutine();

            // Scale up the loading bar container.
            float t = 0f;
            while (t <= 1f)
            {
                loadingBarContainer.SetLocalScaleY(t);
                t += Time.deltaTime / loadingBarContainerScaleDuration;
                yield return null;
            }
            loadingBarContainer.SetLocalScaleY(1f);
            */
        }

        public void SetLoadingBarProgress(float t)
        {
            loadingBar.SetLocalScaleX(t);
        }

        public void Show()
        {
            background.Show();
        }

        public void Hide()
        {
            background.Hide();
        }
    }
}
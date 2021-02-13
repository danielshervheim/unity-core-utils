using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DSS.SceneLoader
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] LoadingScreen loadingScreenPrefab = default;
        [SerializeField] RectTransform loadingScreenContainer = default;

        [SerializeField] bool lockCursorOnLoad = false;
        [SerializeField] bool unlockCursorOnLoad = false;
        
        [SerializeField] bool fakeLoading = false;
        [SerializeField] float fakeLoadingDuration = 2f;

        bool loading = false;

        public void LoadScene(string sceneName)
        {
            if (loading)
            {
                return;
            }
            StartCoroutine(LoadSceneRoutine(sceneName));
        }

        IEnumerator LoadSceneRoutine(string sceneName)
        {
            loading = true;

            if (lockCursorOnLoad)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            LoadingScreen loadingScreen = Instantiate(loadingScreenPrefab, loadingScreenContainer);
            yield return loadingScreen.Setup();
        
            AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneName);

            if (fakeLoading)
            {
                sceneLoad.allowSceneActivation = false;
                float t = 0f;
                while (t <= 1f)
                {
                    loadingScreen.SetLoadingBarProgress(t);
                    t += Time.deltaTime / fakeLoadingDuration;
                    yield return null;
                }
                loadingScreen.SetLoadingBarProgress(1f);
                
                sceneLoad.allowSceneActivation = true;
                while (!sceneLoad.isDone)
                {
                    yield return null;
                }
            }
            else
            {
                while (!sceneLoad.isDone)
                {
                    loadingScreen.SetLoadingBarProgress(sceneLoad.progress);
                    yield return null;
                }
            }

            // TODO: this doesn't work???
            yield return loadingScreen.Teardown();

            if (unlockCursorOnLoad)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            loading = false;
        }
    }
}
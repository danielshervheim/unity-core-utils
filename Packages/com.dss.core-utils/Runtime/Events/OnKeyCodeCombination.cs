using UnityEngine;
using UnityEngine.Events;

namespace DSS.CoreUtils.Events
{
    // @brief A helper class that exposes an event to the editor that runs on scene load.
    [AddComponentMenu("DSS/Events/On KeyCode Combination")]	
    public class OnKeyCodeCombination : MonoBehaviour
    {
        [SerializeField] private KeyCode[] combination;
        [SerializeField] private float maxDelay = 1f;
        [SerializeField][HideInInspector] private int listeningFor = 0;

        public UnityEvent onKeyCodeCombination = default;

        private float timer = 0f;

        void Update()
        {
            if (combination.Length == 0)
            {
                return;
            }

            if (Input.GetKeyDown(combination[listeningFor]))
            {
                listeningFor += 1;
                if (listeningFor == combination.Length)
                {
                    onKeyCodeCombination.Invoke();
                    listeningFor = 0;
                }
                timer = 0f;
            }

            timer += Time.deltaTime;
            if (timer > maxDelay)
            {
                listeningFor = 0;
            }
        }
    }
}
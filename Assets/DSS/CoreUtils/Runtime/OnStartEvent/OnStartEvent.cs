using UnityEngine;
using UnityEngine.Events;

namespace DSS.OnStartEvent
{
    // @brief A helper class that exposes an event to the editor that runs on scene load.
    public class OnStartEvent : MonoBehaviour
    {
        [SerializeField] UnityEvent onStart = default;

        void Start()
        {
            onStart.Invoke();
        }
    }
}
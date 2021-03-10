using UnityEngine;
using UnityEngine.Events;

namespace DSS.CoreUtils.Events
{
    // @brief A helper class that exposes an event to the editor that runs on scene load.
    public class OnStart : MonoBehaviour
    {
        [SerializeField] UnityEvent onStart = default;

        void Start()
        {
            onStart.Invoke();
        }
    }
}
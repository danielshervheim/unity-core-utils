using UnityEngine;
using UnityEngine.Events;

namespace DSS.CoreUtils.Events
{

// @brief A helper class that exposes an event to the editor that runs on scene load.
[AddComponentMenu("DSS/Events/On Start")]	
public class OnStart : MonoBehaviour
{
    [SerializeField] private UnityEvent onStart = default;

    void Start()
    {
        onStart.Invoke();
    }
}

}  // namespace DSS.CoreUtils.Events
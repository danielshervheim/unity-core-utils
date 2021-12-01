using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DSS.CoreUtils.Events
{

// @brief A helper class that exposes events for trigger objects.
[AddComponentMenu("DSS/Events/On Trigger")]
[RequireComponent(typeof(Collider))]
public class OnTrigger : MonoBehaviour
{
    // ------- //
    // CLASSES //
    // ------- //

    [System.Serializable]
    public class TriggerEvent : UnityEvent<Collider> { }

    // --------- //
    // VARIABLES //
    // --------- //

    [Header("Options")]
    [SerializeField] private List<Collider> m_ignoreColliders = new List<Collider>();

    [Header("Events")]
    public TriggerEvent onTriggerEnter = new TriggerEvent();
    public TriggerEvent onTriggerStay = new TriggerEvent();
    public TriggerEvent onTriggerExit = new TriggerEvent();

    // ------- //
    // METHODS //
    // ------- //

    private void OnTriggerEnter(Collider collider)
    {
        if (!m_ignoreColliders.Contains(collider))
        {
            onTriggerEnter.Invoke(collider);
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (!m_ignoreColliders.Contains(collider))
        {
            onTriggerStay.Invoke(collider);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!m_ignoreColliders.Contains(collider))
        {
            onTriggerExit.Invoke(collider);
        }
    }
}

}  // namespace DSS.CoreUtils.Events
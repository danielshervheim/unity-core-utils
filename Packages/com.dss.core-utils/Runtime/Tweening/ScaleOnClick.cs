using UnityEngine;
using UnityEngine.EventSystems;

namespace DSS.CoreUtils.Tweening
{
    [AddComponentMenu("DSS/Tweening/Scale on Click")]	
    public class ScaleOnClick : Tweener, IPointerDownHandler, IPointerUpHandler
    {
        // A = unclicked, B = clicked.

        [SerializeField] Transform target = default;
        [SerializeField] float unclickedScale = 1f;
        [SerializeField] float clickedScale = 0.9f;

        protected override void Lerp(float t)
        {
            target.localScale = Vector3.one * Mathf.Lerp(unclickedScale, clickedScale, t);
        }

        protected override State GetInitialState()
        {
            // Start unclicked.
            return State.A;
        }

        protected override bool IsInteruptable()
        {
            // Must be interuptable, since someone might unclick
            // before the clicked transition finishes.
            return true;
        }

        protected override OnDisabledBehaviour BehaviourOnDisable()
        {
            // If this gameObject is disabled, just reset the
            // button to the unclicked state.
            return OnDisabledBehaviour.ToA;
        }

        public void OnPointerDown(PointerEventData data)
        {
            ToB();
        }

        public void OnPointerUp(PointerEventData data)
        {
            ToA();
        }
    }
}
using UnityEngine;
using UnityEngine.Events;

namespace DSS.CoreUtils.Tweening
{
    public class CanvasGroupTweener : Tweener
    {
        // A = hidden, B = visible.

        [SerializeField] bool visibleInitially = true;
        [SerializeField] bool interuptable = true;
        
        [SerializeField] CanvasGroup target = default;

        public UnityEvent onShown = new UnityEvent();
        public UnityEvent onHidden = new UnityEvent();
        
        new void Awake()
        {
            onReachedA.AddListener(Hidden);
            onReachedB.AddListener(Shown);

            base.Awake();
        }

        public void Show()
        {
            ToB();
        }

        public void Hide()
        {
            ToA();
        }

        protected override void Lerp(float t)
        {
            target.alpha = t;
        }

        protected override State GetInitialState()
        {
            return visibleInitially ? State.B : State.A;
        }

        protected override bool IsInteruptable()
        {
            return interuptable;
        }

        void Shown()
        {
            target.interactable = true;
            target.blocksRaycasts = true;
            onShown.Invoke();
        }

        void Hidden()
        {
            target.interactable = false;
            target.blocksRaycasts = false;
            onHidden.Invoke();
        }
    }
}
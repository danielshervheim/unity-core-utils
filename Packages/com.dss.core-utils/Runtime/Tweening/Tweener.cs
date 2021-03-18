using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DSS.CoreUtils.Tweening
{
    // @brief An abstract class that handles the boilerplate of
    // tweening an object between two states (A, and B) over time.
    public abstract class Tweener : MonoBehaviour
    {
        public enum State { A, B };

        public enum OnDisabledBehaviour { ToA, ToB, ToTarget };

        // @brief How long it takes to tween between states.
        [SerializeField] private float duration = 0.25f;

        // @brief The easing curve to use while tweening towards A.
        [SerializeField] private AnimationCurve aCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        
        // @brief The easing curve to use while tweening towards B.
        [SerializeField] private AnimationCurve bCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        // @brief Called when we start tweening towards A.
        protected UnityEvent onTowardsA = new UnityEvent();

        // @brief Called when we reach A.
        protected UnityEvent onReachedA = new UnityEvent();

        // @brief Called when we start tweening towards B.
        protected UnityEvent onTowardsB = new UnityEvent();

        // @brief Called when we reach B.
        protected UnityEvent onReachedB = new UnityEvent();

        // Private vars.
        private State state = State.A;  // Current state
        private float t = 0f;  // Lerp parameter
        private bool transition = false;  // Wether we are mid-transition or not
        private Coroutine routine;  // The transition coroutine
        private AnimationCurve curve;  // The curve to use

        // @brief Returns the underlying coroutine object.
        // (This should only be used if you know what you're doing).
        // TODO: make this protected?
        public Coroutine GetUnderlyingCoroutine()
        {
            return routine;
        }

        // @brief Start tweening towards A.
        protected void ToA()
        {
            if (transition)
            {
                if (IsInteruptable())
                {
                    StopCoroutine(routine);
                }
                else
                {
                    return;
                }
            }
            else if (state == State.A)
            {
                return;
            }

            curve = aCurve;
            routine = StartCoroutine(ToARoutine());
        }

        // @brief Start tweening towards B.
        protected void ToB()
        {
            if (transition)
            {
                if (IsInteruptable())
                {
                    StopCoroutine(routine);
                }
                else
                {
                    return;
                }
            }
            else if (state == State.B)
            {
                return;
            }

            curve = bCurve;
            routine = StartCoroutine(ToBRoutine());
        }

        // @brief Which state to start in.
        protected abstract State GetInitialState();

        // @brief Whether a tween can be interupted or not.
        protected abstract bool IsInteruptable();

        // @brief Lerps the the object between A (t = 0), and B (t = 1).
        protected abstract void Lerp(float t);

        // @brief What to do if the gameObject is disabled mid-tween. 
        protected virtual OnDisabledBehaviour BehaviourOnDisable()
        {
            return OnDisabledBehaviour.ToTarget;
        }

        protected void Awake()
        {
            state = GetInitialState();
            t = state==State.A ? 0f : 1f;
            curve = state==State.A ? aCurve : bCurve;
        }

        protected void Start()
        {
            Lerp(curve.Evaluate(t));

            if (state == State.A)
            {
                onReachedA.Invoke();
            }
            else if (state == State.B)
            {
                onReachedB.Invoke();
            }
        }

        protected void OnDisable()
        {
            if (!transition)
            {
                return;
            }

            if (BehaviourOnDisable() == OnDisabledBehaviour.ToA)
            {
                SetImmediateState(State.A);
            }
            else if (BehaviourOnDisable() == OnDisabledBehaviour.ToB)
            {
                SetImmediateState(State.B);
            }
            else if (BehaviourOnDisable() == OnDisabledBehaviour.ToTarget)
            {
                SetImmediateState(state);
            }
        }

        private IEnumerator ToARoutine()
        {
            transition = true;
            onTowardsA.Invoke();

            while (t >= 0f)
            {
                Lerp(curve.Evaluate(t));
                t -= Time.deltaTime / duration;
                yield return null;
            }
            Lerp(curve.Evaluate(0f));

            state = State.A;
            onReachedA.Invoke();
            transition = false;
        }

        private IEnumerator ToBRoutine()
        {
            transition = true;
            onTowardsB.Invoke();

            while (t <= 1f)
            {
                Lerp(curve.Evaluate(t));
                t += Time.deltaTime / duration;
                yield return null;
            }
            Lerp(curve.Evaluate(1f));

            state = State.B;
            onReachedB.Invoke();
            transition = false;
        }

        // Cancels the current tween (if mid-tween).
        private void CancelTween()
        {
            if (!transition)
            {
                return;
            }

            StopCoroutine(routine);
            transition = false;
        }

        // Cancel any current tween and immediately jump to a given state.
        private void SetImmediateState(State newState)
        {
            // Cancel current tween (if any)
            CancelTween();

            // Save the new state.
            state = newState;

            // And lerp towards it, as well as invoking the appropriate event.
            if (state == State.A)
            {
                Lerp(0f);
                onReachedA.Invoke();
            }
            else if (state == State.B)
            {
                Lerp(1f);
                onReachedB.Invoke();
            }
        }
    }
}
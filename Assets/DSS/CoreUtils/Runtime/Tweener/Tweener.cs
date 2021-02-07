using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DSS.CoreUtils
{
    // @brief An abstract class that handles the boilerplate of
    // tweening an object between two states (A, and B) over time.
    public abstract class Tweener : MonoBehaviour
    {
        public enum State { A, B };

        // @brief How long it takes to tween between states.
        [SerializeField] float duration = 0.25f;

        // @brief The easing curve to use while tweening towards A.
        [SerializeField] AnimationCurve aCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        
        // @brief The easing curve to use while tweening towards B.
        [SerializeField] AnimationCurve bCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        // @brief Called when we start tweening towards A.
        protected UnityEvent onTowardsA = new UnityEvent();

        // @brief Called when we reach A.
        protected UnityEvent onReachedA = new UnityEvent();

        // @brief Called when we start tweening towards B.
        protected UnityEvent onTowardsB = new UnityEvent();

        // @brief Called when we reach B.
        protected UnityEvent onReachedB = new UnityEvent();

        State state = State.A;  // Current state
        float t = 0f;  // Lerp parameter
        bool transition = false;  // Wether we are mid-transition or not
        Coroutine routine;  // The transition coroutine
        AnimationCurve curve;  // The curve to use

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

        // Setup the 
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

        IEnumerator ToARoutine()
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

        IEnumerator ToBRoutine()
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
    }
}
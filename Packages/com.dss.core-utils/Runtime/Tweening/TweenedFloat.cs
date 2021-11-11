// Daniel Shervheim
// danielshervheim@gmail.com, 2021

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DSS.CoreUtils.Tweening
{

// ------------------------------------------------------------------------ //
// @brief A helper object to tween a float between two predefined extremes. //
// ------------------------------------------------------------------------ //
public class TweenedFloat
{
    // --------------- //
    // CLASSES & ENUMS //
    // --------------- //

    // @brief An event that passes a float value when invoked.
    public class TweenEvent : UnityEvent<float> { }

    private enum State { TowardsMin, TowardsMax, AtMin, AtMax };

    // --------- //
    // VARIABLES //
    // --------- //

    // @brief Event that fires when the value moves towards the minimum bound.
    public TweenEvent onTowardsMin = new TweenEvent();

    // @brief Event that fires when the value moves towards the maximum bound.
    public TweenEvent onTowardsMax = new TweenEvent();

    // @brief Event that fires once the value reaches the minimum bound.
    public UnityEvent onReachedMin = new UnityEvent();

    // @brief Event that fires once the value reaches the maximum bound.
    public UnityEvent onReachedMax = new UnityEvent();

    // @brief Event that fires when the value leaves the minimum bound.
    public UnityEvent onLeaveMin = new UnityEvent();

    // @brief Event that fires when the value leaves the maximum bound.
    public UnityEvent onLeaveMax = new UnityEvent();

    private MonoBehaviour host;
    private float min;
    private float max;
    private float value;

    private float duration;
    private AnimationCurve curve;
    
    private Coroutine transitionRoutine = null;
    private State transitionState;

    // ------- //
    // METHODS //
    // ------- //

    // @brief Constructs a new TweenedFloat instance.
    public TweenedFloat(MonoBehaviour host, float min, float max, bool startAtMin, float duration, AnimationCurve curve)
    {
        this.host = host;
        this.min = min;
        this.max = max;
        this.value = startAtMin ? min : max;
        this.duration = duration;
        this.curve = curve;
        this.transitionState = startAtMin ? State.AtMin : State.AtMax;
    }

    // @brief Wether or not the value is at the minimum.
    public bool AtMin()
    {
        return transitionState == State.AtMin;
    }

    // @brief Wether or not the value is at or moving towards the minimum.
    public bool AtOrTowardsMin()
    {
        return AtMin() || transitionState == State.TowardsMin;
    }

    // @brief Wether or not the value is at the maximum.
    public bool AtMax()
    {
        return transitionState == State.AtMax;
    }

    // @brief Wether or not the value is at or moving towards the maximum.
    public bool AtOrTowardsMax()
    {
        return AtMax() || transitionState == State.TowardsMax;
    }

    // @brief Starts moving the value towards the minimum.
    public void TowardsMin()
    {
        if (AtOrTowardsMin())
        {
            return;
        }
        else if (transitionRoutine != null)
        {
            host.StopCoroutine(transitionRoutine);
        }
        transitionRoutine = host.StartCoroutine(TowardsMinRoutine());
    }

    // @brief Starts moving the value towards the maximum.
    public void TowardsMax()
    {
        if (AtOrTowardsMax())
        {
            return;
        }
        else if (transitionRoutine != null)
        {
            host.StopCoroutine(transitionRoutine);
        }
        transitionRoutine = host.StartCoroutine(TowardsMaxRoutine());
    }

    // Internally moves the value towards the minimum and fires the necessary events along the way.
    private IEnumerator TowardsMinRoutine()
    {
        if (AtMax())
        {
            onLeaveMax.Invoke();
        }

        transitionState = State.TowardsMin;

        if (!Mathf.Approximately(duration, 0f))
        {
            while (value >= min)
            {
                value -= Time.deltaTime / duration;
                onTowardsMin.Invoke(curve.Evaluate(value));
                yield return null;
            }
        }
        
        value = min;
        onTowardsMin.Invoke(curve.Evaluate(value));
        onReachedMin.Invoke();

        transitionState = State.AtMin;
        transitionRoutine = null;
    }

    // Internally moves the value towards the maximum and fires the necessary events along the way.
    private IEnumerator TowardsMaxRoutine()
    {
        if (AtMin())
        {
            onLeaveMin.Invoke();
        }

        transitionState = State.TowardsMax;

        if (!Mathf.Approximately(duration, 0f))
        {
            while (value <= max)
            {
                value += Time.deltaTime / duration;
                onTowardsMax.Invoke(curve.Evaluate(value));
                yield return null;
            }
        }
        
        value = max;
        onTowardsMax.Invoke(curve.Evaluate(value));
        onReachedMax.Invoke();

        transitionState = State.AtMax;
        transitionRoutine = null;
    }
}

}  // namespace DSS.CoreUtils.Tweening
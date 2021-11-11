using UnityEngine;
using UnityEngine.EventSystems;

namespace DSS.CoreUtils.Tweening
{

[AddComponentMenu("DSS/Tweening/Scale on Click")]	
// --------------------------------------------- //
// @brief Scales a transform when it is clicked. //
// --------------------------------------------- //
public class ScaleOnClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // --------- //
    // VARIABLES //
    // --------- //

    [SerializeField] Transform target = default;
    [SerializeField] float unclickedScale = 1f;
    [SerializeField] float clickedScale = 0.9f;

    [SerializeField] private float duration = 0.25f;
    [SerializeField] private AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    private TweenedFloat tween;

    // ------- //
    // METHODS //
    // ------- //

    public void OnPointerDown(PointerEventData data)
    {
        tween.TowardsMax();
    }

    public void OnPointerUp(PointerEventData data)
    {
        tween.TowardsMin();
    }

    private void Start()
    {
        tween = new TweenedFloat(
            CoroutineHost.Instance.gameObject.GetComponent<MonoBehaviour>(),
            0f,
            1f,
            true,
            duration,
            curve
        );

        tween.onTowardsMin.AddListener(UpdateScale);
        tween.onTowardsMax.AddListener(UpdateScale);
    }

    private void UpdateScale(float clickAmount)
    {
        target.localScale = Vector3.one * Mathf.Lerp(unclickedScale, clickedScale, clickAmount);
    }
}

}  // namespace DSS.CoreUtils.Tweening
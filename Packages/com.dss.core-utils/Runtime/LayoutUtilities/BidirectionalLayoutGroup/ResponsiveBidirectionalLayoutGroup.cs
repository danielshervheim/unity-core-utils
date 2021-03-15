using UnityEngine;
using UnityEngine.UI;

using Direction = DSS.CoreUtils.LayoutUtilities.BidirectionalLayoutGroup.LayoutDirection;

namespace DSS.CoreUtils.LayoutUtilities
{
    // @brief Overrides a BidirectionalLayoutGroup's direction property
    // in response to the device's aspect ratio.
    [AddComponentMenu("DSS/Layout Utilities/Responsive Bidirectional Layout Group")]	
    [ExecuteInEditMode]
    [RequireComponent(typeof(BidirectionalLayoutGroup))]
    public class ResponsiveBidirectionalLayoutGroup : MonoBehaviour
    {   
        // @brief Which layout direction to follow in portrait mode.
        [SerializeField] Direction portraitDirection = Direction.Vertical;

        // @brief Which layout direction to follow in landscape mode.
        [SerializeField] Direction landscapeDirection = Direction.Horizontal;

        int m_width = 0;
        int m_height = 0;
        BidirectionalLayoutGroup target = null;

        void Update()
        {
            if (target == null)
            {
                target = GetComponent<BidirectionalLayoutGroup>();
            }

            if (Screen.width != m_width || Screen.height != m_height)
            {   
                m_width = Screen.width;
                m_height = Screen.height;

                float aspectRatio = (float)m_width / (float)m_height;

                target.SetDirection((aspectRatio < 1f) ? portraitDirection : landscapeDirection);
            }
        }
    }
}
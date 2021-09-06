using UnityEngine;
using UnityEngine.UI;

namespace DSS.CoreUtils.LayoutUtilities
{
    // @brief A layout group that mimics both a horizontal and a
    // vertical layout group, depending on the specified direction.
    [AddComponentMenu("DSS/Layout Utilities/Bidirectional Layout Group")]	
    public class BidirectionalLayoutGroup : HorizontalOrVerticalLayoutGroup
    {
        public enum LayoutDirection { Horizontal, Vertical };
        
        // @brief Which layout direction to follow.
        [SerializeField] LayoutDirection direction = LayoutDirection.Horizontal;

        // @brief Returns the current layout direction.
        public LayoutDirection GetDirection()
        {
            return direction;
        }

        // @brief Sets the current layout direction and marks the layout for rebuilding.
        public void SetDirection(LayoutDirection newDirection)
        {
            direction = newDirection;
            SetDirty();
        }

        // @brief Returns wether the current layout direction is horizontal.
        public bool IsHorizontal()
        {
            return direction == LayoutDirection.Horizontal;
        }

        // @brief Returns wether the current layout direction is vertical.
        public bool IsVertical()
        {
            return direction == LayoutDirection.Vertical;
        }

        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();
            CalcAlongAxis(0, direction != LayoutDirection.Horizontal);
        }

        public override void CalculateLayoutInputVertical()
        {
            CalcAlongAxis(1, direction != LayoutDirection.Horizontal);
        }

        public override void SetLayoutHorizontal()
        {
            SetChildrenAlongAxis(0, direction != LayoutDirection.Horizontal);
        }

        public override void SetLayoutVertical()
        {
            SetChildrenAlongAxis(1, direction != LayoutDirection.Horizontal);
        }


        // Prevents errant constructor use.
        protected BidirectionalLayoutGroup() { }
    }
}
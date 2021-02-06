using UnityEngine;
using UnityEngine.UI;

namespace DSS.ResponsiveGridLayoutGroup
{
    // @brief Lays out elements in a grid with specific column and row counts.
    public class ResponsiveGridLayoutGroup : GridLayoutGroup
    {
        public int rows = 4;
        public int columns = 4;

        public override void SetLayoutHorizontal()
        {
            UpdateCellSize();
            base.SetLayoutHorizontal();
        }

        public override void SetLayoutVertical()
        {
            UpdateCellSize();
            base.SetLayoutVertical();
        }

        private void UpdateCellSize()
        {
            rows = (int)Mathf.Max(rows, 1);
            columns = (int)Mathf.Max(columns, 1);

            float x = (rectTransform.rect.size.x - padding.horizontal - spacing.x*(columns - 1)) / columns;
            float y = (rectTransform.rect.size.y - padding.vertical - spacing.y * (rows - 1)) / rows;
            this.constraint = Constraint.FixedColumnCount;
            this.constraintCount = columns;
            this.cellSize = new Vector2(x,y);
        }
    }

    // Source(s)
    // ---------
    // Unity Answers user "nicloay"
    // https://forum.unity.com/threads/flexible-grid-layout.296074/
}
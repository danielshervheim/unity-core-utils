using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace DSS.ColorPalettes
{
    [CustomEditor(typeof(ColorPaletteContainer))]
    public class ColorPaletteContainerEditor : Editor
    {
        private SerializedProperty m_palettes;
        private SerializedProperty m_index;
        private ReorderableList m_ReorderableList;

        private void OnEnable()
        {
            // Find the list in our ScriptableObject script.
            m_palettes = serializedObject.FindProperty("palettes");
            m_index = serializedObject.FindProperty("index");

            // Create an instance of our reorderable list.
            m_ReorderableList = new ReorderableList(
                serializedObject: serializedObject,
                elements: m_palettes,
                draggable: true,
                displayHeader: true,
                displayAddButton: true,
                displayRemoveButton: true
            );

            m_ReorderableList.drawHeaderCallback = DrawHeaderCallback;
            m_ReorderableList.drawElementCallback = DrawElementCallback;
            m_ReorderableList.elementHeightCallback += ElementHeightCallback;
            m_ReorderableList.onAddCallback += OnAddCallback;
            m_ReorderableList.onReorderCallbackWithDetails += OnReorderCallback;
        }

        // @brief Draws the header for the reorderable list
        private void DrawHeaderCallback(Rect rect)
        {
            EditorGUI.LabelField(rect, "Color Palettes");
        }

        // @brief This methods decides how to draw each element in the list
        private void DrawElementCallback(Rect rect, int index, bool isactive, bool isfocused)
        {
            // Get the element we want to draw from the list.
            SerializedProperty element = m_ReorderableList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            // Draw a toggle to select a new active preset.
            int toggleWidth = 20;
            if (EditorGUI.Toggle(
                position: new Rect(
                    rect.x,
                    rect.y,
                    toggleWidth,
                    EditorGUIUtility.singleLineHeight
                ),
                value: m_index.intValue == index
            ))
            {
                m_index.intValue = index;
            }

            // Draw the list item as a property field, just like Unity does internally.
            EditorGUI.PropertyField(
                position: new Rect(
                    rect.x+toggleWidth,
                    rect.y,
                    rect.width-toggleWidth,
                    EditorGUIUtility.singleLineHeight
                ),
                property: element,
                label: GUIContent.none,
                includeChildren: true
            );
        }

        // @brief Calculates the height of a single element in the list.
        // This is extremely useful when displaying list-items with nested data.
        private float ElementHeightCallback(int index)
        {
            // Gets the height of the element. This also accounts for properties that can be expanded, like structs.
            float propertyHeight = EditorGUI.GetPropertyHeight(m_ReorderableList.serializedProperty.GetArrayElementAtIndex(index), true);
            float spacing = EditorGUIUtility.singleLineHeight / 2;
            return propertyHeight + spacing;
        }

        // @brief Defines how a new list element should be created and added to our list.
        private void OnAddCallback(ReorderableList list)
        {
            var index = list.serializedProperty.arraySize;
            list.serializedProperty.arraySize++;
            list.index = index;
            var element = list.serializedProperty.GetArrayElementAtIndex(index);
        }

        // @brief Called when the list order changes.
        private void OnReorderCallback(ReorderableList list, int oldIndex, int newIndex)
        {
            // If we dragged the active index, set it to the new index.
            if (m_index.intValue == oldIndex)
            {
                m_index.intValue = newIndex;
            }
            // Otherwise, shift the active index down if needed...
            else if (oldIndex <= m_index.intValue && newIndex >= m_index.intValue)
            {
                m_index.intValue--;
            }
            // ...Or up if needed.
            else if (oldIndex >= m_index.intValue && newIndex <= m_index.intValue)
            {
                m_index.intValue++;
            }
        }

        // @brief Draw the Inspector Window
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            m_ReorderableList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }

    // Source(s)
    // ---------
    // https://sandordaemen.nl/blog/unity-3d-extending-the-editor-part-3/
}
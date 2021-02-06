using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace DSS.ColorPalettes
{
    [CustomEditor(typeof(ColorPalette))]
    public class ColorPaletteEditor : Editor
    {
        private SerializedProperty m_entries;
        private ReorderableList m_ReorderableList;

        private void OnEnable()
        {
            // Find the list in our ScriptableObject script.
            m_entries = serializedObject.FindProperty("entries");

            // Create an instance of our reorderable list.
            m_ReorderableList = new ReorderableList(
                serializedObject: serializedObject,
                elements: m_entries,
                draggable: true,
                displayHeader: true,
                displayAddButton: true,
                displayRemoveButton: true
            );

            m_ReorderableList.drawHeaderCallback = DrawHeaderCallback;
            m_ReorderableList.drawElementCallback = DrawElementCallback;
            m_ReorderableList.elementHeightCallback += ElementHeightCallback;
            m_ReorderableList.onAddCallback += OnAddCallback;
        }

        // @brief Draws the header for the reorderable list
        private void DrawHeaderCallback(Rect rect)
        {
            EditorGUI.LabelField(rect, "Entries");
        }

        // @brief This methods decides how to draw each element in the list
        private void DrawElementCallback(Rect rect, int index, bool isactive, bool isfocused)
        {
            // Get the element we want to draw from the list.
            SerializedProperty element = m_ReorderableList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            // We get the name property of our element so we can display this in our list.
            SerializedProperty elementName = element.FindPropertyRelative("name");
            string elementTitle = string.IsNullOrEmpty(elementName.stringValue) ? "New Entry" : elementName.stringValue;

            // Draw the list item as a property field, just like Unity does internally.
            int leftPadding = 15;
            EditorGUI.PropertyField(
                // position: new Rect(rect.x += 10, rect.y, Screen.width * 0.8f, height: EditorGUIUtility.singleLineHeight),
                position: new Rect(
                    rect.x+leftPadding,
                    rect.y,
                    rect.width-leftPadding,
                    EditorGUIUtility.singleLineHeight
                ),
                property: element,
                label: new GUIContent(elementTitle),
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
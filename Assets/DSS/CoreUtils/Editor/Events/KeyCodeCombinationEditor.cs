using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace DSS.CoreUtils
{
    [CustomEditor(typeof(OnKeyCodeCombination), true)]
    public class OnKeyCodeCombinationEditor : Editor
    {
        SerializedProperty combination;
        ReorderableList combinationList;

        SerializedProperty maxDelay;
        SerializedProperty onKeyCodeCombination;
        SerializedProperty listeningFor;

        protected virtual void OnEnable()
        {
            combination = serializedObject.FindProperty("combination");
            combinationList = new ReorderableList(
                serializedObject: serializedObject,
                elements: combination,
                draggable: true,
                displayHeader: true,
                displayAddButton: true,
                displayRemoveButton: true
            );
            combinationList.drawHeaderCallback = DrawHeaderCallback;
            combinationList.drawElementCallback = DrawElementCallback;
            combinationList.elementHeightCallback += ElementHeightCallback;
            combinationList.onAddCallback += OnAddCallback;

            maxDelay = serializedObject.FindProperty("maxDelay");
            onKeyCodeCombination = serializedObject.FindProperty("onKeyCodeCombination");
            listeningFor = serializedObject.FindProperty("listeningFor");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            combinationList.DoLayoutList();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Behaviour", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(maxDelay);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Event", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(onKeyCodeCombination);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("State", EditorStyles.boldLabel);
            if (Application.isPlaying)
            {
                SerializedProperty target = combinationList.serializedProperty.GetArrayElementAtIndex(listeningFor.intValue);
                string targetTitle = target.enumDisplayNames[target.enumValueIndex];
                EditorGUILayout.LabelField($"Listening For [{listeningFor.intValue}] {targetTitle}");
            }
            else
            {
                EditorGUILayout.HelpBox("Enter Play Mode to see the combination listener state.", MessageType.Info);
            }

            serializedObject.ApplyModifiedProperties();
        }

        // @brief Draws the header for the reorderable list
        private void DrawHeaderCallback(Rect rect)
        {
            EditorGUI.LabelField(rect, "Combination");
        }

        // @brief This methods decides how to draw each element in the list
        private void DrawElementCallback(Rect rect, int index, bool isactive, bool isfocused)
        {
            // Get the element we want to draw from the list.
            SerializedProperty element = combinationList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            // We get the name property of our element so we can display this in our list.
            string elementTitle = element.enumDisplayNames[element.enumValueIndex];
            
            // Draw the list item as a property field, just like Unity does internally.
            int leftPadding = 0;
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
            float propertyHeight = EditorGUI.GetPropertyHeight(combinationList.serializedProperty.GetArrayElementAtIndex(index), true);
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
    }
}
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

namespace DSS.CoreUtils.LayoutUtilities
{
    [CustomEditor(typeof(SnapRect), true)]
    [CanEditMultipleObjects]
    public class SnapRectEditor : Editor
    {
        SerializedProperty snapWidth;
        SerializedProperty widthMode;
        SerializedProperty targetWidthRelative;
        SerializedProperty snapAtWidthAbsolute;
        SerializedProperty targetWidthAbsolute;
        SerializedProperty snapAtWidthRelative;

        SerializedProperty snapHeight;
        SerializedProperty heightMode;
        SerializedProperty targetHeightRelative;
        SerializedProperty snapAtHeightAbsolute;
        SerializedProperty targetHeightAbsolute;
        SerializedProperty snapAtHeightRelative;

        private void OnEnable()
        {
            snapWidth = serializedObject.FindProperty("snapWidth");
            widthMode = serializedObject.FindProperty("widthMode");
            targetWidthRelative = serializedObject.FindProperty("targetWidthRelative");
            snapAtWidthAbsolute = serializedObject.FindProperty("snapAtWidthAbsolute");
            targetWidthAbsolute = serializedObject.FindProperty("targetWidthAbsolute");
            snapAtWidthRelative = serializedObject.FindProperty("snapAtWidthRelative");

            snapHeight = serializedObject.FindProperty("snapHeight");
            heightMode = serializedObject.FindProperty("heightMode");
            targetHeightRelative = serializedObject.FindProperty("targetHeightRelative");
            snapAtHeightAbsolute = serializedObject.FindProperty("snapAtHeightAbsolute");
            targetHeightAbsolute = serializedObject.FindProperty("targetHeightAbsolute");
            snapAtHeightRelative = serializedObject.FindProperty("snapAtHeightRelative");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Width", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(snapWidth, new GUIContent("Enabled"));
            if (snapWidth.boolValue)
            {
                EditorGUILayout.PropertyField(widthMode, new GUIContent("Mode"));
                if ((SnapRect.Mode)widthMode.enumValueIndex == SnapRect.Mode.Absolute)
                {
                    EditorGUILayout.PropertyField(targetWidthAbsolute, new GUIContent("Width"));
                    EditorGUILayout.PropertyField(snapAtWidthRelative, new GUIContent("Snap At"));
                }
                else if ((SnapRect.Mode)widthMode.enumValueIndex == SnapRect.Mode.Relative)
                {
                    EditorGUILayout.PropertyField(targetWidthRelative, new GUIContent("Width"));
                    EditorGUILayout.PropertyField(snapAtWidthAbsolute, new GUIContent("Snap At"));
                }
            }

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Height", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(snapHeight, new GUIContent("Enabled"));
            if (snapHeight.boolValue)
            {
                EditorGUILayout.PropertyField(heightMode, new GUIContent("Mode"));
                if ((SnapRect.Mode)heightMode.enumValueIndex == SnapRect.Mode.Absolute)
                {
                    EditorGUILayout.PropertyField(targetHeightAbsolute, new GUIContent("Height"));
                    EditorGUILayout.PropertyField(snapAtHeightRelative, new GUIContent("Snap At"));
                }
                else if ((SnapRect.Mode)heightMode.enumValueIndex == SnapRect.Mode.Relative)
                {
                    EditorGUILayout.PropertyField(targetHeightRelative, new GUIContent("Height"));
                    EditorGUILayout.PropertyField(snapAtHeightAbsolute, new GUIContent("Snap At"));
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
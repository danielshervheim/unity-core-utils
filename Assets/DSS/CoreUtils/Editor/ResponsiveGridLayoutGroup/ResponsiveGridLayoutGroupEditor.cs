using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DSS.ResponsiveGridLayoutGroup
{
    [CustomEditor(typeof(ResponsiveGridLayoutGroup), true)]
    [CanEditMultipleObjects]
    public class ResponsiveGridLayoutGroupEditor : Editor
    {
        SerializedProperty m_Padding;
        SerializedProperty m_Spacing;
        SerializedProperty m_StartCorner;
        SerializedProperty m_StartAxis;
        SerializedProperty m_ChildAlignment;
        SerializedProperty m_ColumnCount;
        SerializedProperty m_RowCount;

        protected virtual void OnEnable()
        {
            m_Padding = serializedObject.FindProperty("m_Padding");
            m_Spacing = serializedObject.FindProperty("m_Spacing");
            m_StartCorner = serializedObject.FindProperty("m_StartCorner");
            m_StartAxis = serializedObject.FindProperty("m_StartAxis");
            m_ChildAlignment = serializedObject.FindProperty("m_ChildAlignment");
            m_ColumnCount = serializedObject.FindProperty("columns");
            m_RowCount = serializedObject.FindProperty("rows");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_Padding, true);
            EditorGUILayout.PropertyField(m_Spacing, true);
            EditorGUILayout.PropertyField(m_StartCorner, true);
            EditorGUILayout.PropertyField(m_StartAxis, true);
            EditorGUILayout.PropertyField(m_ChildAlignment, true);
            EditorGUILayout.PropertyField(m_RowCount, true);
            EditorGUILayout.PropertyField(m_ColumnCount, true);
            serializedObject.ApplyModifiedProperties();
        }
    }

    // Source(s)
    // ---------
    // Unity Answers user "nicloay"
    // https://forum.unity.com/threads/flexible-grid-layout.296074/
}
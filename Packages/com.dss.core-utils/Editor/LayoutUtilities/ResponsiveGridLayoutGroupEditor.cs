using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.CoreUtils.LayoutUtilities
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

        Section(string.Empty, () =>
        {
            Title("Responsive Grid Layout Group");
        });

        Section("Spacing Options", () =>
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(m_Padding, true);
            EditorGUI.indentLevel--;
            EditorGUILayout.PropertyField(m_Spacing, true);
        });

        Section("Alignment Options", () =>
        {
            EditorGUILayout.PropertyField(m_StartCorner, true);
            EditorGUILayout.PropertyField(m_StartAxis, true);
            EditorGUILayout.PropertyField(m_ChildAlignment, true);
        });

        Section("Layout Options", () =>
        {
            EditorGUILayout.PropertyField(m_RowCount, true);
            EditorGUILayout.PropertyField(m_ColumnCount, true);
        });

        serializedObject.ApplyModifiedProperties();
    }
}

// Source(s)
// ---------
// Unity Answers user "nicloay"
// https://forum.unity.com/threads/flexible-grid-layout.296074/

}  // namespace DSS.CoreUtils.LayoutUtilities
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.CoreUtils.LayoutUtilities
{

[CustomEditor(typeof(ResponsiveBidirectionalLayoutGroup), true)]
[CanEditMultipleObjects]
public class ResponsiveBidirectionalLayoutGroupEditor : Editor
{
    SerializedProperty portraitDirection;
    SerializedProperty landscapeDirection;

    protected virtual void OnEnable()
    {
        portraitDirection = serializedObject.FindProperty("portraitDirection");
        landscapeDirection = serializedObject.FindProperty("landscapeDirection");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Section(string.Empty, () =>
        {
            Title("Responsive Bidirectional Layout Group");
        });

        Section("Responsive Options", () =>
        {
            EditorGUILayout.PropertyField(portraitDirection, true);
            EditorGUILayout.PropertyField(landscapeDirection, true);
        });

        serializedObject.ApplyModifiedProperties();
    }
}

}  // namespace DSS.CoreUtils.LayoutUtilities
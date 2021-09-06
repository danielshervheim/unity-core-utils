using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.CoreUtils.ApplicationUtilities
{

[CustomEditor(typeof(OpenURL), true)]
[CanEditMultipleObjects]
public class OpenURLEditor : Editor
{
    SerializedProperty url;

    public virtual void OnEnable()
    {
        url = serializedObject.FindProperty("url");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Section(string.Empty, () =>
        {
            Title("Open URL");
        });

        Section("Options", () =>
        {
            EditorGUILayout.PropertyField(url);
        }, spaceAfter: true);

        serializedObject.ApplyModifiedProperties();
    }
}

}  // namespace DSS.CoreUtils.LayoutUtilities
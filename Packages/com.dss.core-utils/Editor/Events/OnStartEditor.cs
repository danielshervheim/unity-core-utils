using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.CoreUtils.Events
{

[CustomEditor(typeof(OnStart), true)]
[CanEditMultipleObjects]
public class OnStartEditor : Editor
{
    SerializedProperty onStart;

    protected virtual void OnEnable()
    {
        onStart = serializedObject.FindProperty("onStart");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Section(string.Empty, () =>
        {
            Title("On Start");
        });

        Section("Events", () =>
        {
            EditorGUILayout.PropertyField(onStart);
        }, spaceAfter: true);

        serializedObject.ApplyModifiedProperties();
    }
}

}  // namespace DSS.CoreUtils.Events
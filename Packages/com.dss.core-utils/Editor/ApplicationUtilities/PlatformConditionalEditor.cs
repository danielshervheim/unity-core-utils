using UnityEditor;
using UnityEngine;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.CoreUtils.ApplicationUtilities
{

[CustomEditor(typeof(PlatformConditional), true)]
public class PlatformConditionalEditor : Editor
{
    SerializedProperty platforms;
    SerializedProperty behaviour;

    private void OnEnable()
    {
        platforms = serializedObject.FindProperty("platforms");
        behaviour = serializedObject.FindProperty("behaviour");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Section(string.Empty, () =>
        {
            Title("Platform Conditional");
        });

        Section("Options", () =>
        {
            EditorGUILayout.PropertyField(behaviour);

            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(platforms, new GUIContent("Platforms"));
            EditorGUI.indentLevel--;
        }, spaceAfter: true);

        serializedObject.ApplyModifiedProperties();
    }
}

}  // namespace DSS.CoreUtils.ApplicationUtilities
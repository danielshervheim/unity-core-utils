using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.CoreUtils.Events
{

[CustomEditor(typeof(OnKeyCodeCombination), true)]
public class OnKeyCodeCombinationEditor : Editor
{
    SerializedProperty combination;
    SerializedProperty maxDelay;
    SerializedProperty listeningFor;
    SerializedProperty onKeyCodeCombination;

    protected virtual void OnEnable()
    {
        combination = serializedObject.FindProperty("combination");
        maxDelay = serializedObject.FindProperty("maxDelay");
        listeningFor = serializedObject.FindProperty("listeningFor");
        onKeyCodeCombination = serializedObject.FindProperty("onKeyCodeCombination");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Section(string.Empty, () =>
        {
            Title("On KeyCode Combination");
        });

        Section("Options", () =>
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(combination);
            EditorGUI.indentLevel--;
            EditorGUILayout.PropertyField(maxDelay);
        });

        Section("Events", () =>
        {
            EditorGUILayout.PropertyField(onKeyCodeCombination);
        });

        Section("State", () =>
        {
            EditorGUILayout.PropertyField(listeningFor);
        }, enabled: false, spaceAfter: true);

        serializedObject.ApplyModifiedProperties();
    }
}

}  // namespace DSS.CoreUtils.Events

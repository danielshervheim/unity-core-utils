using UnityEngine;
using UnityEditor;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.CoreUtils.ScreenUtilities
{

[CustomEditor(typeof(ScreenWatcher), true)]
public class ScreenWatcherEditor : Editor
{

    SerializedProperty onSafeAreaChange;
    SerializedProperty onAspectRatioChange;
    SerializedProperty onPortrait;
    SerializedProperty onLandscape;
    SerializedProperty onScreenSizeChange;
    
    protected virtual void OnEnable()
    { 
        onSafeAreaChange = serializedObject.FindProperty("onSafeAreaChange");
        onAspectRatioChange = serializedObject.FindProperty("onAspectRatioChange");
        onPortrait = serializedObject.FindProperty("onPortrait");
        onLandscape = serializedObject.FindProperty("onLandscape");
        onScreenSizeChange = serializedObject.FindProperty("onScreenSizeChange");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Section(string.Empty, () =>
        {
            Title("Screen Watcher");
        });

        Section("Safe Area Events", () =>
        {

            EditorGUILayout.PropertyField(onSafeAreaChange, true);
        });

        Section("Aspect Ratio Events", () =>
        {

            EditorGUILayout.PropertyField(onAspectRatioChange, true);
            EditorGUILayout.PropertyField(onPortrait, true);
            EditorGUILayout.PropertyField(onLandscape, true);
        });

        Section("Screen Size Events", () =>
        {

            EditorGUILayout.PropertyField(onScreenSizeChange, true);
        }, spaceAfter: true);
        
        serializedObject.ApplyModifiedProperties();
    }
}

}  // namespace DSS.CoreUtils.ScreenUtilities
using UnityEngine;
using UnityEditor;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.CoreUtils.ApplicationUtilities
{

[CustomEditor(typeof(SetTargetFrameRate), true)]
public class SetTargetFrameRateEditor : Editor
{
    SerializedProperty targetFrameRate;
    SerializedProperty destroyAfterSetting;
    SerializedProperty preventInWebGL;
    
    public virtual void OnEnable()
    {
        targetFrameRate = serializedObject.FindProperty("targetFrameRate");
        destroyAfterSetting = serializedObject.FindProperty("destroyAfterSetting");
        preventInWebGL = serializedObject.FindProperty("preventInWebGL");
    }
    
    public override void OnInspectorGUI()
    {
        Section(string.Empty, () =>
        {
            Title("Set Target Frame Rate");
        });

        Section("Options", () =>
        {
            EditorGUILayout.PropertyField(targetFrameRate);
            EditorGUILayout.PropertyField(destroyAfterSetting);
            EditorGUILayout.PropertyField(preventInWebGL);
        }, spaceAfter: QualitySettings.vSyncCount == 0);

        if (QualitySettings.vSyncCount != 0)
        {
            Section("VSync", () =>
            {
                EditorGUILayout.HelpBox("VSync is enabled. This component will have no effect.", MessageType.Warning);

                if (GUILayout.Button("Turn off VSync"))
                {
                    QualitySettings.vSyncCount = 0;
                }
            }, spaceAfter: true);
        }
    }
}

}  // namespace DSS.CoreUtils.ApplicationUtilities
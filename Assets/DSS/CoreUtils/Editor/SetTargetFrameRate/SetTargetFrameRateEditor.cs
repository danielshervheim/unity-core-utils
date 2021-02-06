// QualitySettings.vSyncCount = 1;

using UnityEngine;
using UnityEditor;

namespace DSS.SetTargetFrameRate
{
    [CustomEditor(typeof(SetTargetFrameRate), true)]
    public class SetTargetFrameRateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (QualitySettings.vSyncCount != 0)
            {
                EditorGUILayout.HelpBox("VSync is enabled. This component will have no effect.", MessageType.Warning);

                if (GUILayout.Button("Turn off VSync"))
                {
                    QualitySettings.vSyncCount = 0;
                }
            }
        }
    }
}
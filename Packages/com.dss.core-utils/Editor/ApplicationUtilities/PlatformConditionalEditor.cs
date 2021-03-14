using UnityEditor;
using UnityEngine;

namespace DSS.CoreUtils.ApplicationUtilities
{
    [CustomEditor(typeof(PlatformConditional), true)]
    public class PlatformConditionalEditor : Editor
    {
        SerializedProperty disableOnPlatforms;

        private void OnEnable()
        {
            disableOnPlatforms = serializedObject.FindProperty("disableOnPlatforms");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.LabelField("Disable On", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(disableOnPlatforms, new GUIContent("Platforms"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}
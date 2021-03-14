using UnityEditor;
using UnityEngine;

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
            // EditorGUILayout.LabelField("Behaviour", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(behaviour);
            EditorGUILayout.PropertyField(platforms, new GUIContent("Platforms"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}
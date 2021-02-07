using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace DSS.ColorPalettes
{
    [CustomEditor(typeof(ApplyColorPalette))]
    public class ApplyColorPaletteEditor : Editor
    {
        private SerializedProperty m_preset;
        private SerializedProperty m_entryName;

        private void OnEnable()
        {
            m_preset = serializedObject.FindProperty("preset");
            m_entryName = serializedObject.FindProperty("entryName");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_preset);
            EditorGUILayout.PropertyField(m_entryName, new GUIContent("Name"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}
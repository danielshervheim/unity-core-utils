using UnityEngine;
using UnityEditor;

namespace DSS.CoreUtils
{
    [CustomEditor(typeof(CanvasGroupTweener), true)]
    public class CanvasGroupTweenerEditor : Editor
    {
        SerializedProperty m_duration;
        SerializedProperty m_aCurve;
        SerializedProperty m_bCurve;

        SerializedProperty m_target;

        SerializedProperty m_visibleInitially;
        SerializedProperty m_isInteruptable;
        
        protected virtual void OnEnable()
        {
            m_duration = serializedObject.FindProperty("duration");    
            m_aCurve = serializedObject.FindProperty("aCurve");    
            m_bCurve = serializedObject.FindProperty("bCurve");

            m_target = serializedObject.FindProperty("target");  

            m_visibleInitially = serializedObject.FindProperty("visibleInitially");
            m_isInteruptable = serializedObject.FindProperty("interuptable");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Target", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(m_target, new GUIContent("Canvas Group"), true);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Options", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(m_visibleInitially, true);
            EditorGUILayout.PropertyField(m_isInteruptable, true);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Transition", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(m_duration, true);
            EditorGUILayout.PropertyField(m_aCurve, new GUIContent("Hide"), true);
            EditorGUILayout.PropertyField(m_bCurve, new GUIContent("Show"), true);
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}
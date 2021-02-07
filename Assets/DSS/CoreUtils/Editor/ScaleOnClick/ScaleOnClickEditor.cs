using UnityEngine;
using UnityEditor;

namespace DSS.CoreUtils
{
    [CustomEditor(typeof(ScaleOnClick), true)]
    public class ScaleOnClickEditor : Editor
    {
        SerializedProperty m_duration;
        SerializedProperty m_aCurve;
        SerializedProperty m_bCurve;

       SerializedProperty m_target;
       SerializedProperty m_unclickedScale;
       SerializedProperty m_clickedScale;
        
        protected virtual void OnEnable()
        {
            m_duration = serializedObject.FindProperty("duration");    
            m_aCurve = serializedObject.FindProperty("aCurve");    
            m_bCurve = serializedObject.FindProperty("bCurve");   

            m_target = serializedObject.FindProperty("target");
            m_unclickedScale = serializedObject.FindProperty("unclickedScale");
            m_clickedScale = serializedObject.FindProperty("clickedScale"); 
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Target", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(m_target, new GUIContent("RectTransform"), true);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Appearance", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(m_unclickedScale, true);
            EditorGUILayout.PropertyField(m_clickedScale, true);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Transition", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(m_duration, true);
            EditorGUILayout.PropertyField(m_aCurve, new GUIContent("Click"), true);
            EditorGUILayout.PropertyField(m_bCurve, new GUIContent("Unclick"), true);
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}
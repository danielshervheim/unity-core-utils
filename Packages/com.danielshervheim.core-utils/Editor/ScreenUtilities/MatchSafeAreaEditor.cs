using UnityEngine;
using UnityEditor;

namespace DSS.CoreUtils.ScreenUtilities
{
    [CustomEditor(typeof(MatchSafeArea), true)]
    public class MatchSafeAreaEditor : Editor
    {
        SerializedProperty m_target;
        SerializedProperty m_targetCanvas;

        protected virtual void OnEnable()
        {
            m_target = serializedObject.FindProperty("target");
            m_targetCanvas = serializedObject.FindProperty("targetCanvas");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(m_target);
            if (m_target.objectReferenceValue == null)
            {
                EditorGUILayout.HelpBox("The target RectTransform has not been assigned. Please assign it manually, or click the button below.", MessageType.Warning);

                if (GUILayout.Button("Use this RectTransform"))
                {
                    ((MatchSafeArea)target).UseThisRectTransform();
                }
            }

            EditorGUILayout.PropertyField(m_targetCanvas);
            if (m_targetCanvas.objectReferenceValue == null)
            {
                EditorGUILayout.HelpBox("The target Canvas has not been assigned. Please assign it manually, or click the button below.", MessageType.Warning);

                if (GUILayout.Button("Use this Canvas"))
                {
                    ((MatchSafeArea)target).UseThisCanvas();
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
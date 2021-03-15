using UnityEngine;
using UnityEditor;

namespace DSS.CoreUtils.ScreenUtilities
{
    [CustomEditor(typeof(CropToSafeArea), true)]
    public class CropToSafeAreaEditor : Editor
    {
        SerializedProperty m_target;

        protected virtual void OnEnable()
        {
            m_target = serializedObject.FindProperty("target");
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
                    ((CropToSafeArea)target).UseThisRectTransform();
                }
            }
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}
// using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

namespace DSS.CoreUtils

{
    [CustomEditor(typeof(BidirectionalLayoutGroup), true)]
    [CanEditMultipleObjects]
    public class BidirectionalLayoutGroupEditor : HorizontalOrVerticalLayoutGroupEditor
    {
        SerializedProperty m_direction;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_direction = serializedObject.FindProperty("direction");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();

            EditorGUILayout.LabelField("Direction", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(m_direction, true);
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}
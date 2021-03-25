using UnityEditor;
using UnityEngine;

namespace DSS.CoreUtils.Attributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyRuntimeAttribute))]
    public class ReadOnlyRuntimeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginDisabledGroup(Application.isPlaying);
            EditorGUI.PropertyField(position, property, label, true);
            EditorGUI.EndDisabledGroup();
        }
    }
}
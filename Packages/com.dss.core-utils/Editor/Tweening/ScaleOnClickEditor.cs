using UnityEngine;
using UnityEditor;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.CoreUtils.Tweening
{

[CustomEditor(typeof(ScaleOnClick), true)]
public class ScaleOnClickEditor : Editor
{
    SerializedProperty m_target;

    SerializedProperty m_unclickedScale;
    SerializedProperty m_clickedScale;

    SerializedProperty m_duration;
    SerializedProperty m_curve;

    
    protected virtual void OnEnable()
    { 
        m_target = serializedObject.FindProperty("target");
        m_unclickedScale = serializedObject.FindProperty("unclickedScale");
        m_clickedScale = serializedObject.FindProperty("clickedScale");

        m_duration = serializedObject.FindProperty("duration");    
        m_curve = serializedObject.FindProperty("curve");    
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Section(string.Empty, () =>
        {
            Title("Scale on Click");
        });

        Section("Required References", () =>
        {
            EditorGUILayout.PropertyField(m_target, new GUIContent("Target"), true);
        });

        Section("Scale Options", () =>
        {

            EditorGUILayout.PropertyField(m_unclickedScale, true);
            EditorGUILayout.PropertyField(m_clickedScale, true);
        });

        Section("Transition Options", () =>
        {
            EditorGUILayout.PropertyField(m_duration, new GUIContent("Transition Duration"), true);
            EditorGUILayout.PropertyField(m_curve, new GUIContent("Transition Curve"), true);
        }, spaceAfter: true);
        
        serializedObject.ApplyModifiedProperties();
    }
}

}  // namespace DSS.CoreUtils.Tweening
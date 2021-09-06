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
    SerializedProperty m_aCurve;
    SerializedProperty m_bCurve;

    
    protected virtual void OnEnable()
    { 
        m_target = serializedObject.FindProperty("target");
        m_unclickedScale = serializedObject.FindProperty("unclickedScale");
        m_clickedScale = serializedObject.FindProperty("clickedScale");

        m_duration = serializedObject.FindProperty("duration");    

        m_aCurve = serializedObject.FindProperty("aCurve");    
        m_bCurve = serializedObject.FindProperty("bCurve");  
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
            EditorGUILayout.PropertyField(m_aCurve, new GUIContent("On Click Curve"), true);
            EditorGUILayout.PropertyField(m_bCurve, new GUIContent("On Unclick Curve"), true);
        }, spaceAfter: true);
        
        serializedObject.ApplyModifiedProperties();
    }
}

}  // namespace DSS.CoreUtils.Tweening
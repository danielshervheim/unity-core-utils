// using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.CoreUtils.LayoutUtilities
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
        serializedObject.Update();

        Section(string.Empty, () =>
        {
            Title("Bidirectional Layout Group");
        });

        Section("Options", () =>
        {
            // TODO: draw these properties individually, so we dont have to indent them all :/
            EditorGUI.indentLevel++;
            base.OnInspectorGUI();
            EditorGUI.indentLevel--;
            EditorGUILayout.PropertyField(m_direction, true);
        }, spaceAfter: true);
        
        serializedObject.ApplyModifiedProperties();
    }
}

}  // namespace DSS.CoreUtils.LayoutUtilities
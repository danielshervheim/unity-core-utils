using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace DSS.CoreUtils.EditorUtilities
{

public static class GUIUtilities
{
    public static void Space(int howMany = 1)
    {
        for (int i = 0; i < howMany; i++)
        {
            EditorGUILayout.Space();
        }
    }
    
    public static void Section(string label, UnityAction DrawContents, bool spaceBefore = true, bool spaceAfter = false, bool enabled = true)
    {
        if (spaceBefore)
        {
            Space();
        }

        if (label != null && !label.Equals(string.Empty))
        {
            BoldLabel(label);
        }

        GUIStyle style = new GUIStyle(EditorStyles.helpBox);
        style.padding = new RectOffset(10, 10, 10, 10);
        
        EditorGUILayout.BeginVertical(style);
        EditorGUI.BeginDisabledGroup(!enabled);
        DrawContents();
        EditorGUI.EndDisabledGroup();
        EditorGUILayout.EndVertical();

        if (spaceAfter)
        {
            Space();
        }
    }

    public static void HorizontalLine()
    {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
    }

    public static void BoldLabel(string label)
    {
        EditorGUILayout.LabelField(label, EditorStyles.boldLabel);
    }

    public static void Title(string title)
    {
        GUIStyle style = new GUIStyle(EditorStyles.boldLabel);
        style.alignment = TextAnchor.MiddleCenter;
        EditorGUILayout.LabelField(title, style);
    }

    public static void Subtitle(string subtitle, bool center = true)
    {
        GUIStyle style = new GUIStyle(EditorStyles.label);
        if (center)
        {
            style.alignment = TextAnchor.MiddleCenter;
        }
        style.wordWrap = true;
        EditorGUILayout.LabelField(subtitle, style);
    }
}

}  // DSS.CoreUtils.EditorUtilities
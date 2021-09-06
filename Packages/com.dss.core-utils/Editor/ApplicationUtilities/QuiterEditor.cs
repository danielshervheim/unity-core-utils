using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.CoreUtils.ApplicationUtilities
{

[CustomEditor(typeof(Quiter), true)]
[CanEditMultipleObjects]
public class QuiterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        Section(string.Empty, () =>
        {
            Title("Quiter");
        }, spaceAfter: true);
        serializedObject.ApplyModifiedProperties();
    }
}

}  // namespace DSS.CoreUtils.ApplicationUtilities
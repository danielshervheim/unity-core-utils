using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.CoreUtils.LayoutUtilities
{

[CustomEditor(typeof(CropToSafeArea), true)]
[CanEditMultipleObjects]
public class CropToSafeAreaEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        Section(string.Empty, () =>
        {
            Title("Crop To Safe Area");
        }, spaceAfter: true);
        serializedObject.ApplyModifiedProperties();
    }
}

}  // namespace DSS.CoreUtils.LayoutUtilities
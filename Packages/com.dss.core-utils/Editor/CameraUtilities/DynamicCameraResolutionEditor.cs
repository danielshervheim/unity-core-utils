using DSS.CoreUtils.EditorUtilities;
using UnityEditor;
using UnityEngine;

namespace DSS.CoreUtils.CameraUtilities
{
    [CustomEditor(typeof(DynamicCameraResolution), true)]
    public class DynamicCameraResolutionEditor : Editor
    {
        SerializedPropertyContainer props;

        private void OnEnable()
        {
            props = new SerializedPropertyContainer(serializedObject, new string[]
            {
                "resolutionScale",
                "defaultDepthBufferResolution",
                "renderTextureTarget"
            });
        }

        public override void OnInspectorGUI()
        {
            DynamicCameraResolution dcr = (DynamicCameraResolution)target;

            serializedObject.Update();
            EditorGUILayout.LabelField("Camera", EditorStyles.boldLabel);
            
            EditorGUI.BeginChangeCheck();
            {
                EditorGUILayout.PropertyField(props["resolutionScale"], new GUIContent("Scale"));
            }
            if (EditorGUI.EndChangeCheck() && Application.isPlaying)
            {
                dcr.SetResolutionScale(dcr.GetResolutionScale());
            }

            EditorGUI.BeginDisabledGroup(true);
            {
                int width = (int)Mathf.Max(1f, dcr.GetResolutionScale()*Screen.width);
                int height = (int)Mathf.Max(1f, dcr.GetResolutionScale()*Screen.height);
                EditorGUILayout.Vector2Field("Resolution", new Vector2(width, height));
            }
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.PropertyField(props["defaultDepthBufferResolution"], new GUIContent("Depth Buffer"));

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Render Target", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(props["renderTextureTarget"], new GUIContent("Target"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
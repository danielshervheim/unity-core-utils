using UnityEditor;
using UnityEngine;

namespace DSS.CoreUtils.CameraUtilities
{
    [CustomEditor(typeof(DynamicCameraResolution), true)]
    public class DynamicCameraResolutionEditor : Editor
    {
        SerializedProperty resolutionScale;
        SerializedProperty defaultDepthBufferResolution;
        SerializedProperty renderTextureTarget;

        private void OnEnable()
        {
            resolutionScale = serializedObject.FindProperty("resolutionScale");
            defaultDepthBufferResolution = serializedObject.FindProperty("defaultDepthBufferResolution");
            renderTextureTarget = serializedObject.FindProperty("renderTextureTarget");
        }

        public override void OnInspectorGUI()
        {
            DynamicCameraResolution dcr = (DynamicCameraResolution)target;

            serializedObject.Update();
            EditorGUILayout.LabelField("Camera", EditorStyles.boldLabel);
            
            EditorGUI.BeginChangeCheck();
            {
                EditorGUILayout.PropertyField(resolutionScale, new GUIContent("Scale"));
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
            EditorGUILayout.PropertyField(defaultDepthBufferResolution, new GUIContent("Depth Buffer"));

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Render Target", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(renderTextureTarget, new GUIContent("Target"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
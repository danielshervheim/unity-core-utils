using UnityEngine;
using UnityEditor;

namespace DSS.SceneLoader
{
    [CustomEditor(typeof(SceneLoader), true)]
    public class SceneLoaderEditor : Editor
    {
        SerializedProperty m_loadingScreenPrefab;
        SerializedProperty m_loadingScreenContainer;
        
        SerializedProperty m_lockCursorOnLoad;
        SerializedProperty m_unlockCursorOnLoad;

        SerializedProperty m_fakeLoading;
        SerializedProperty m_fakeLoadingDuration;

        protected virtual void OnEnable()
        {
            m_loadingScreenPrefab = serializedObject.FindProperty("loadingScreenPrefab");    
            m_loadingScreenContainer = serializedObject.FindProperty("loadingScreenContainer");   

            m_lockCursorOnLoad = serializedObject.FindProperty("lockCursorOnLoad");
            m_unlockCursorOnLoad = serializedObject.FindProperty("unlockCursorOnLoad");

            m_fakeLoading = serializedObject.FindProperty("fakeLoading");
            m_fakeLoadingDuration = serializedObject.FindProperty("fakeLoadingDuration");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Loading Screen", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(m_loadingScreenPrefab, new GUIContent("Prefab"), true);
            EditorGUILayout.PropertyField(m_loadingScreenContainer, new GUIContent("Container"), true);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Cursor", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(m_lockCursorOnLoad, new GUIContent("Lock on Load"), true);
            EditorGUILayout.PropertyField(m_unlockCursorOnLoad, new GUIContent("Unlock on Load"), true);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Fake Loading", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(m_fakeLoading, new GUIContent("Enabled"), true);
            if (m_fakeLoading.boolValue)
            {
                EditorGUILayout.PropertyField(m_fakeLoadingDuration, new GUIContent("Duration"), true);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
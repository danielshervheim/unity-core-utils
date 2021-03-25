using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DSS.CoreUtils.EditorUtilities
{
    public class SerializedPropertyContainer
    {
        private SerializedObject _serializedObject;
        private Dictionary<string, SerializedProperty> _properties;

        public SerializedPropertyContainer(SerializedObject serializedObject, params string[] propertyNames)
        {
            _properties = new Dictionary<string, SerializedProperty>();
            
            _serializedObject = serializedObject;
            foreach (string propertyName in propertyNames)
            {
                _properties[propertyName] = serializedObject.FindProperty(propertyName);
            }
        }

        public SerializedProperty this[string propertyName]
        {
            get
            {
                if (_properties.ContainsKey(propertyName))
                {
                    return _properties[propertyName];
                }
                else
                {
                    Debug.LogError($"This SerializedPropertyContainer does not contain a property named '{propertyName}'.");
                    return null;
                }
            }
        }
    }
    // Usage.
    /*

    private SerializedPropertyContainer props;

    void OnEnable()
    {
        props = new SerializedPropertyContainer(serializedObject, new string[]
        {
            "propertyName1",
            "propertyName2",
            ... etc
        });
    }

    void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(props["propertyName1"]);
        EditorGUILayout.PropertyField(props["propertyName1"]);
    }

    */
}
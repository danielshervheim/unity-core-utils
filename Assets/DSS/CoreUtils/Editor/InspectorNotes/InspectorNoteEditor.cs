using UnityEngine;
using UnityEditor;

namespace DSS.CoreUtils.InspectorNotes
{
    [CustomEditor(typeof(InspectorNote), true)]
    public class InspectorNoteEditor : Editor
    {
        SerializedProperty note;
        SerializedProperty type;

        private bool editing = false;
        
        protected virtual void OnEnable()
        {
            note = serializedObject.FindProperty("note");
            type = serializedObject.FindProperty("type");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
           if (editing)
           {
               DrawNoteEditor();
           }
           else
           {
               DrawNote();
           }
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawNote()
        {
            EditorGUILayout.HelpBox(note.stringValue, FromNoteType((InspectorNote.NoteType)type.enumValueIndex));
            if (GUILayout.Button("Edit"))
            {
                editing = true;
            }
        }

        private MessageType FromNoteType(InspectorNote.NoteType type)
        {
            if (type == InspectorNote.NoteType.Error)
            {
                return MessageType.Error;
            }
            else if (type == InspectorNote.NoteType.Warning)
            {
                return MessageType.Warning;
            }
            else if (type == InspectorNote.NoteType.Info)
            {
                return MessageType.Info;
            }
            else
            {
                return MessageType.None;
            }
        }

        private void DrawNoteEditor()
        {
            GUIStyle textAreaStyle = new GUIStyle(EditorStyles.textArea);
            textAreaStyle.wordWrap = true;
            note.stringValue = EditorGUILayout.TextArea(note.stringValue, textAreaStyle);
            EditorGUILayout.PropertyField(type);

            if (GUILayout.Button("Save"))
            {
                editing = false;
            }
        }
    }
}
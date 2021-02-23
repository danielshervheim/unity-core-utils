using UnityEditor;
using UnityEngine;

using static DSS.Extensions.TerrainExtensions;

namespace DSS.CoreUtils
{
    public class UpdateTerrainHeightEditorWindow : EditorWindow
    {
        // The terrain to modify.
        Terrain terrain = default;

        // The new terrain height.
        float heighten = 0f;

        // The terrain offset.
        float deepen = 0f;

        [MenuItem("DSS/Terrain/Heighten and Deepen")]
        static void Window()
        {
            EditorUtility.DisplayDialog("Warning", "This tool has not been tested extensively and may result in " + 
                "loss of Terrain-related data. Please back-up your project before using it.", "I Understand");

            UpdateTerrainHeightEditorWindow window  = (UpdateTerrainHeightEditorWindow)EditorWindow.GetWindow(typeof(UpdateTerrainHeightEditorWindow), true, "Heighten and Deepen Terrain");
            window.ShowUtility();

            // UpdateTerrainHeightEditorWindow window = CreateInstance(typeof(UpdateTerrainHeightEditorWindow)) as UpdateTerrainHeightEditorWindow;
            // window.ShowUtility();
        }

        void OnGUI()
        {
            terrain = EditorGUILayout.ObjectField(new GUIContent("Terrain"), terrain, typeof(Terrain), true) as Terrain;

            if (terrain == null)
            {
                string msg = "Please assign a Terrain component from the scene.";
                EditorGUILayout.HelpBox(msg, MessageType.Info);
            }
            else
            {
                heighten = EditorGUILayout.FloatField(new GUIContent("Raise By"), heighten);
                if (heighten < 0f)
                {
                    string msg = "Heightening by a negative amount. The top of the current terrain will be clipped.";
                    EditorGUILayout.HelpBox(msg, MessageType.Warning);
                }
                GUI.enabled = !Mathf.Approximately(heighten, 0f);
                if (GUILayout.Button("Raise Height Limit"))
                {
                    string msg = "It is recommended that you backup your project before continuing. Are you sure you want to proceed?";
                    
                    if (EditorUtility.DisplayDialog("Raise Height Limit?", msg, "Ok", "Cancel"))
                    {
                        Undo.RegisterCompleteObjectUndo(terrain.terrainData, "Heightened Terrain Data");   
                        Undo.RegisterCompleteObjectUndo(terrain.transform, "Heightened Terrain Transform");
  

                        terrain.RaiseTerrainHeightLimit(heighten);
                    }
                }
                GUI.enabled = true;

                deepen = EditorGUILayout.FloatField(new GUIContent("Lower By"), deepen);
                if (deepen < 0f)
                {
                    string msg = "Deepening by a negative amount. The bottom of the current terrain will be clipped.";
                    EditorGUILayout.HelpBox(msg, MessageType.Warning);
                }

                GUI.enabled = !Mathf.Approximately(deepen, 0f);
                if (GUILayout.Button("Lower Floor Limit"))
                {
                    string msg = "It is recommended that you backup your project before continuing. Are you sure you want to proceed?";
                    
                    if (EditorUtility.DisplayDialog("Lower Floor Limit?", msg, "Ok", "Cancel"))
                    {
                        Undo.RegisterCompleteObjectUndo(terrain.terrainData, "Deepened Terrain Data");   
                        Undo.RegisterCompleteObjectUndo(terrain.transform, "Deepened Terrain Transform");
  
                        terrain.LowerTerrainFloorLimit(deepen);
                    }
                }
                GUI.enabled = true;
            }
        }
    }
}

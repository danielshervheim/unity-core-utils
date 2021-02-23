using UnityEngine;
using UnityEditor;

// using System.IO;
// using UnityEditor.Formats.Fbx.Exporter;

using static DSS.Extensions.TerrainExtensions;

namespace DSS.CoreUtils
{
    public class TerrainToMeshWindow : EditorWindow
    {
        Terrain terrain = default;
        int downsizeFactor = 1;

        // [MenuItem("DSS/Terrain/Terrain To Mesh")]
        static void Window()
        {
            TerrainToMeshWindow window  = (TerrainToMeshWindow)EditorWindow.GetWindow(typeof(TerrainToMeshWindow), true, "Terrain To Mesh");
            window.ShowUtility();
        }

        void OnGUI()
        {
            EditorGUILayout.HelpBox("This doesn't work yet :(", MessageType.Info);

            /*
            terrain = EditorGUILayout.ObjectField(new GUIContent("Terrain"), terrain, typeof(Terrain), true) as Terrain;

            if (terrain == null)
            {
                string msg = "Please assign a Terrain component from the scene.";
                EditorGUILayout.HelpBox(msg, MessageType.Info);
            }
            else
            {
                EditorGUILayout.Space();

                downsizeFactor = EditorGUILayout.IntField("Downsize Factor", downsizeFactor);
                downsizeFactor = (int)Mathf.Max(downsizeFactor, 1f);

                if (GUILayout.Button("Convert"))
                {
                    string savePath = EditorUtility.SaveFilePanel(
                        "Save mesh as FBX",
                        "",
                        "mesh.fbx",
                        "fbx"
                    );
                    if (savePath.Length != 0)
                    {
                        Mesh m = terrain.ToMesh(downsizeFactor);
                        ModelExporter.ExportObject(savePath, m);
                    }
                }
            }
            */
        }
    }
}

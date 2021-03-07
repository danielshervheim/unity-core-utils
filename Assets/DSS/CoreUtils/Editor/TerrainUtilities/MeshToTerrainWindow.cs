using UnityEditor;
using UnityEngine;

using static DSS.Extensions.TerrainExtensions;

namespace DSS.CoreUtils
{
    public class MeshToTerrainWindow : EditorWindow
    {
        Terrain terrain = default;
        MeshCollider collider = default;

        [MenuItem("DSS/Terrain/Mesh To Terrain")]
        static void Window()
        {
            MeshToTerrainWindow window  = (MeshToTerrainWindow)EditorWindow.GetWindow(typeof(MeshToTerrainWindow), true, "Mesh To Terrain");
            window.ShowUtility();
        }

        void OnGUI()
        {
            terrain = EditorGUILayout.ObjectField(new GUIContent("Terrain"), terrain, typeof(Terrain), true) as Terrain;
            if (terrain == null)
            {
                string msg = "Please assign a Terrain component from the scene.";
                EditorGUILayout.HelpBox(msg, MessageType.Info);
            }
            EditorGUILayout.Space();

            collider = EditorGUILayout.ObjectField(new GUIContent("Mesh Collider"), collider, typeof(MeshCollider), true) as MeshCollider;
            if (collider == null)
            {
                string msg = "Please assign a MeshCollider component from the scene.";
                EditorGUILayout.HelpBox(msg, MessageType.Info);
            }

            if (!(terrain == null || collider == null))
            {
                EditorGUILayout.Space();

                if (GUILayout.Button("Convert"))
                {
                    Undo.RegisterCompleteObjectUndo(terrain.terrainData, "Deepened Terrain Data");
                    terrain.FromMesh(collider);
                }
            }
        }
    }
}

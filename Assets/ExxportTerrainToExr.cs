using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static DSS.CoreUtils.Extensions.TerrainExtensions;

public class ExxportTerrainToExr : MonoBehaviour
{
    public string path = "Assets/out.exr";
    public Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        Texture2D t = terrain.ToTexture2D(true);
        byte[] bytes = ImageConversion.EncodeToEXR(t, Texture2D.EXRFlags.OutputAsFloat);
        System.IO.File.WriteAllBytes(path, bytes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

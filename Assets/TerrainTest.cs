using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static DSS.Extensions.TerrainExtensions;

public class TerrainTest : MonoBehaviour
{
    public Terrain t;
    public int downsizeFactor = 0;

    public Terrain t2;

    // Start is called before the first frame update
    void Start()
    {
        Mesh m = t.ToMesh(downsizeFactor);

        MeshFilter mf = this.gameObject.AddComponent<MeshFilter>();
        mf.mesh = m;

        MeshCollider mc = this.gameObject.AddComponent<MeshCollider>();
        mc.sharedMesh = m;

        m.RecalculateBounds();

        // MeshRenderer mr = this.gameObject.AddComponent<MeshRenderer>();
        t2.FromMesh(mc);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

namespace DSS.CoreUtils.Extensions
{
    // @brief A collection of Terrain extension methods.
    public static class TerrainExtensions
    {
        public static Mesh ToMesh(this Terrain terrainObject, int downsizeFactor=1)
        {
            if (downsizeFactor < 1)
            {
                throw new System.ArgumentException($"downsizeFactor '{downsizeFactor}' must be > 0");
            }
            if (terrainObject.terrainData == null)
            {
                throw new System.ArgumentException($"null Terrain.terrainData component");
            }

            TerrainData terrain = terrainObject.terrainData;

            int w = terrain.heightmapResolution;
            int h = terrain.heightmapResolution;
            
            Vector3 meshScale = terrain.size;
            int tRes = (int)Mathf.Pow(2, (int)downsizeFactor);
            meshScale = new Vector3(meshScale.x / (w - 1) * tRes, meshScale.y, meshScale.z / (h - 1) * tRes);
            
            Vector2 uvScale = new Vector2(1.0f / (w - 1), 1.0f / (h - 1));
            
            float[,] tData = terrain.GetHeights(0, 0, w, h);

            w = (w - 1) / tRes + 1;
            h = (h - 1) / tRes + 1;

            Vector3[] tVertices = new Vector3[w * h];
            Vector2[] tUV = new Vector2[w * h];

            int[] tPolys = new int[(w - 1) * (h - 1) * 6];

            // Build vertices and UVs
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    tVertices[y * w + x] = Vector3.Scale(meshScale, new Vector3(y, tData[x * tRes, y * tRes], x));  // + terrainObject.transform.position;
                    tUV[y * w + x] = Vector2.Scale( new Vector2(x * tRes, y * tRes), uvScale);
                }
            }

            // Build triangle indices: 3 indices into vertex array for each triangle
            int index = 0;
            for (int y = 0; y < h - 1; y++)
            {
                for (int x = 0; x < w - 1; x++)
                {
                    tPolys[index] = (y * w) + x + 1;
                    index++;
                    tPolys[index] = ((y + 1) * w) + x + 1;
                    index++;
                    tPolys[index] = ((y + 1) * w) + x;
                    index++;

                    tPolys[index] = (y * w) + x + 1;
                    index++;
                    tPolys[index] = ((y + 1) * w) + x;
                    index++;
                    tPolys[index] = (y * w) + x;
                    index++;
                }
            }

            Mesh m = new Mesh();
            m.SetVertices(tVertices);
            m.SetUVs(0, tUV);
            m.SetTriangles(tPolys, 0);
            m.RecalculateBounds();
            m.RecalculateNormals();
            m.RecalculateTangents();

            return m;
        }

        public static void FromMesh(this Terrain terrainObject, MeshCollider collider, bool bottomUp = false)
        {
            if (terrainObject.terrainData == null)
            {
                throw new System.ArgumentException($"null Terrain.terrainData component");
            }

            TerrainData terrain = terrainObject.terrainData;

            Bounds bounds = collider.bounds;
            float sizeFactor = collider.bounds.size.y / (collider.bounds.size.y);
            terrain.size = collider.bounds.size;
            bounds.size = new Vector3(terrain.size.x, collider.bounds.size.y, terrain.size.z);

            // Do raycasting samples over the object to see what terrain heights should be
            float[,] heights = new float[terrain.heightmapResolution, terrain.heightmapResolution];
            Ray ray = new Ray(new Vector3(bounds.min.x, bounds.max.y + bounds.size.y, bounds.min.z), -Vector3.up);
            RaycastHit hit = new RaycastHit();
            float meshHeightInverse = 1 / bounds.size.y;
            Vector3 rayOrigin = ray.origin;

            int maxHeight = heights.GetLength(0);
            int maxLength = heights.GetLength(1);

            Vector2 stepXZ = new Vector2(bounds.size.x / maxLength, bounds.size.z / maxHeight);

            for(int zCount = 0; zCount < maxHeight; zCount++)
            {
                for(int xCount = 0; xCount < maxLength; xCount++)
                {

                    float height = 0.0f;

                    if(collider.Raycast(ray, out hit, bounds.size.y * 3))
                    {
                        height = (hit.point.y - bounds.min.y) * meshHeightInverse;

                        // bottom up
                        if (bottomUp)
                        {

                            height *= sizeFactor;
                        }

                        // clamp
                        if (height < 0)
                        {
                            height = 0;
                        }
                    }

                    heights[zCount, xCount] = height;
                    rayOrigin.x += stepXZ[0];
                    ray.origin = rayOrigin;
                }

                rayOrigin.z += stepXZ[1];
                rayOrigin.x = bounds.min.x;
                ray.origin = rayOrigin;
            }

            terrain.SetHeights(0, 0, heights);
        }

        // @brief Raises the Terrain height limit by the specified amount.
        // If the amount is negative, the terrain height is reduced (and any
        // terrain above the new height is clipped).
        public static void RaiseTerrainHeightLimit(this Terrain t, float raiseBy)
        {
            int width = t.terrainData.heightmapTexture.width;
            int height = t.terrainData.heightmapTexture.height;

            float[,] heights = t.terrainData.GetHeights(0, 0, width, height);

            float oldHeight = t.terrainData.size.y;
            float newHeight = oldHeight + raiseBy;
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float h = heights[x, y];

                    h *= oldHeight;
                    h /= newHeight;
                    h = Mathf.Clamp01(h);
                    
                    heights[x, y] = h;
                }
            }

            t.terrainData.SetHeights(0, 0, heights);
            t.terrainData.size = new Vector3(t.terrainData.size.x, newHeight, t.terrainData.size.z);
        }

        public static void LowerTerrainFloorLimit(this Terrain t, float lowerBy)
        {
            // If we are lowering the terrain floor, we need to raise the ceiling
            // to accomodate the upwards-shifted heights.
            if (lowerBy > 0f)
            {
                t.RaiseTerrainHeightLimit(lowerBy);
            }

            int width = t.terrainData.heightmapTexture.width;
            int height = t.terrainData.heightmapTexture.height;

            float[,] heights = t.terrainData.GetHeights(0, 0, width, height);

            float terrainHeight = t.terrainData.size.y;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float h = heights[x, y];

                    h *= terrainHeight;
                    h += lowerBy;
                    h /= terrainHeight;
                    h = Mathf.Clamp01(h);
                    
                    heights[x, y] = h;
                }
            }

            t.terrainData.SetHeights(0, 0, heights);
            t.transform.position -= Vector3.up*lowerBy;

            // Otherwise, if we are raising the terrain floor, we need to adjust the
            // ceiling AFTER lowering the heights. This has the effect of clipping
            // the bottom of the terrain, rather than the top (which is what we would
            // expect when raising the floor limit).
            if (lowerBy < 0f)
            {
                t.RaiseTerrainHeightLimit(lowerBy);
            }
        }
    }

    // Source(s)
    // ---------
    // ToMesh() adapted from code by Mike Hergaarden, and Yun Kyu Choi
    // https://wiki.unity3d.com/index.php/TerrainObjExporter
    // FromMesh() adapted from code by Eric Haines
    // https://wiki.unity3d.com/index.php/Object2Terrain
}
using UnityEngine;

namespace DSS.Extensions
{
    // @brief A collection of Terrain extension methods.
    public static class TerrainExtensions
    {
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
}
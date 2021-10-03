using UnityEngine;

namespace DSS.CoreUtils.Extensions
{

// @brief A collection of Terrain extension methods.
public static class TerrainExtensions
{
    public static Texture2D ToTexture2D(this Terrain terrain, bool normalize = false)
    {
        int width = terrain.terrainData.heightmapTexture.width;
        int height = terrain.terrainData.heightmapTexture.height;
        float[,] data = terrain.terrainData.GetHeights(0, 0, width, height);

        Texture2D tex = new Texture2D(width, height, TextureFormat.RGBAFloat, true);
        Color[] pixels = tex.GetPixels(0);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float dataSample = data[y, x];
                if (!normalize)
                {
                    dataSample *= terrain.terrainData.heightmapScale.y;
                    dataSample += terrain.transform.position.y;
                }
                pixels[y*width + x] = new Color(dataSample, dataSample, dataSample, 1f);
            }
        }

        tex.SetPixels(pixels, 0);
        tex.Apply();

        return tex;
    }
}

}  // namespace DSS.CoreUtils.Extensions
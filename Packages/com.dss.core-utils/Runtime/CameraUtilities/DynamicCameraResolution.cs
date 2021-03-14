using UnityEngine;
using UnityEngine.UI;

namespace DSS.CoreUtils.CameraUtilities
{
    // @brief Scales the camera render resolution.
    [RequireComponent(typeof(Camera))]
    public class DynamicCameraResolution : MonoBehaviour
    {
        public enum DepthBufferResolution { NoDepthBuffer = 0, HalfPrecision = 16, FullPrecision = 32 };

        [SerializeField][Range(0f,1f)] private float resolutionScale = 1f;
        [SerializeField] private DepthBufferResolution defaultDepthBufferResolution = DepthBufferResolution.HalfPrecision;
        [SerializeField] private RawImage renderTextureTarget = default;

        private Camera cam;

        // @brief Getter for the dynamic texture.
        public RenderTexture CameraTexture
        {
            get
            {
                if (cam == null || cam.targetTexture == null)
                {
                    Setup();
                }
                return cam.targetTexture;
            }
        }
        
        // @brief Sets the current render resolution scale and generates a new texture.
        public void SetResolutionScale(float newScale)
        {
            resolutionScale = Mathf.Clamp01(newScale);
            UpdateResolution();
        }
        
        // @brief Returns the current render resolution scale.
        public float GetResolutionScale()
        {
            return resolutionScale;
        }

        private void Awake()
        {
            Setup();
        }

        // Caches camera reference and generates the first texture.
        private void Setup()
        {
            cam = GetComponent<Camera>();
            UpdateResolution();
        }

        // Generates a new texture, if needed.
        private void UpdateResolution()
        {
            int depth = (int)defaultDepthBufferResolution;
            int width = (int)Mathf.Max(1f, Screen.width * resolutionScale);
            int height = (int)Mathf.Max(1f, Screen.height * resolutionScale);

            // Only reallocate new texture if the texture size has changed. 
            if (cam.targetTexture != null &&
                cam.targetTexture.width == width &&
                cam.targetTexture.height == height)
            {
                return;
            }

            // Save the current camera texture depth, and then free it.
            if (cam.targetTexture != null)
            {
                depth = cam.targetTexture.depth;
                cam.targetTexture.Release();
            }

            // Generate a new texture with the given width, height, and depth.
            RenderTexture camTexture = new RenderTexture(width, height, depth);
            camTexture.Create();

            // Set it to the camera, and a target if one is specified.
            cam.targetTexture = camTexture;
            if (renderTextureTarget != null)
            {
                renderTextureTarget.texture = camTexture;
            }
        }
    }
}
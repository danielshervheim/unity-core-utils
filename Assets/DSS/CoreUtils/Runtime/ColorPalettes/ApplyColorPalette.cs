using UnityEngine;
using UnityEngine.UI;

namespace DSS.ColorPalettes
{
    [RequireComponent(typeof(Graphic))]
    [ExecuteInEditMode]
    public class ApplyColorPalette : MonoBehaviour
    {
        [SerializeField] ColorPalette preset = default;
        [SerializeField] string entryName = default;

        Graphic target = null;

        void Update()
        {
            if (preset == null)
            {
                return;
            }

            if (target == null)
            {
                target = GetComponent<Graphic>();
            }

            target.color = preset.GetColor(entryName);
        }
    }
}
using UnityEngine;

namespace GameCore.Colors
{
    public class Palette : MonoBehaviour
    {
        [SerializeField] private Color[] palette =
        {
            Color.black,
            Color.blue,
            Color.cyan,
            Color.gray,
            Color.green,
            Color.magenta,
            Color.red,
            Color.yellow
        };
        
        public Color RandomColorFromPalette()
        {
            return palette[Random.Range(0, palette.Length)];
        }
    }
}
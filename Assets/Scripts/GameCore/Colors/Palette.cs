using UnityEngine;

namespace GameCore.Colors
{
    public class Palette : MonoBehaviour, IPalette
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

        public Color GetRandomColor()
        {
            return palette[Random.Range(0, palette.Length)];
        }
    }
}
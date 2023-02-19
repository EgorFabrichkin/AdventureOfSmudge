using UnityEngine;

namespace GameCore.Colors
{
    public class ChangeColor
    {
        private readonly Palette palette;
        private readonly Color previousColor;

        public ChangeColor(Palette palette, Color previousColor)
        {
            this.palette = palette;
            this.previousColor = previousColor;
        }

        public Color GetRandomColor()
        {
            var currentColor = palette.RandomColorFromPalette();
            
            while (previousColor == currentColor)
            {
                currentColor = palette.RandomColorFromPalette();
            }

            return currentColor;
        }
    }
}
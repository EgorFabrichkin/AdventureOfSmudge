using UnityEngine;

namespace GameCore.Colors
{
    public class RandomColor
    {
        private readonly Palette palette;
        private readonly Color previousColor;

        public RandomColor(Palette palette, Color previousColor)
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
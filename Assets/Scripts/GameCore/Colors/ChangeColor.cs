using UnityEngine;

namespace GameCore.Colors
{
    public class ChangeColor
    {
        private Palette palette = null!;

        public ChangeColor(SpriteRenderer spriteRenderer)
        {
            spriteRenderer.color = GetColor(spriteRenderer.color);
        }

        private Color GetColor(Color previousColor)
        {
            var currentColor = palette.GetRandomColor();
            
            while (previousColor == currentColor)
            {
                currentColor = palette.GetRandomColor();
            }

            return currentColor;
        }
    }
}
using UnityEngine;

namespace GameCore.Colors
{
    public interface IColor
    {
        public void SetColor(Color color);

        public Color GetColor();
    }
}
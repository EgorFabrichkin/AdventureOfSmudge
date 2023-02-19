using GameCore.Colors;
using UnityEngine;

namespace GameCore.Platforms
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(PlatformEffector2D))]
    public class Platform : MonoBehaviour, IColor
    {
        [SerializeField] private SpriteRenderer spriteRenderer = null!;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>()!;
        }
        
        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }
        
        public Color GetColor()
        {
            return spriteRenderer.color;
        }
    }
}
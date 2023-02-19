using GameCore.Colors;
using UnityEngine;
using UnityEngine.Events;

namespace GameCore.Platforms
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(PlatformEffector2D))]
    public class Platform : MonoBehaviour, IColor
    {
        public UnityEvent spawned = new();
        
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
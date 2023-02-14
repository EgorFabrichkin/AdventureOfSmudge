using UnityEngine;

namespace GameCore.Platforms
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(PlatformEffector2D))]
    public class Platform : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer = null!;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>()!;
        }

        public Color SetColor()
        {
            return spriteRenderer.color;
        }
    }
}
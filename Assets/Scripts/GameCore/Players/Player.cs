using GameCore.Colors;
using GameCore.Platforms;
using GameCore.Players.Inputs;
using GamePlayFlow;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace GameCore.Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Player : MonoBehaviour, IColor, IPause
    {
        public UnityEvent jumped = new();

        [SerializeField] private SpriteRenderer spriteRenderer = null!;
        [SerializeField] private float speed;
        [SerializeField] private float jumpPower;
        [Header("Dependencies")] 
        [SerializeField] private PlayerInputBehavior playerInput = null!;
        
        private new Rigidbody2D rigidbody2D = null!;
        
        private void Awake()
        {
            playerInput.EnsureNotNull("Input not specified");
            rigidbody2D = GetComponent<Rigidbody2D>()!;
            spriteRenderer = GetComponent<SpriteRenderer>()!;
        }

        private void Update()
        {
            rigidbody2D.AddForce(
                playerInput.Direction().Flat()
                * speed
            );
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.collider.TryGetComponent(out Platform platform)) return;
            if (spriteRenderer.color == platform.GetColor())
            {
                //rigidbody2D.isKinematic = true;
            }
            rigidbody2D.AddForce(Vector2.up * jumpPower);
            jumped.Invoke();
        }

        public void SetColor(Color color) => spriteRenderer.color = color;

        public Color GetColor()
        {
            return spriteRenderer.color;
        }

        public void Paused(bool value) => rigidbody2D.simulated = !value;
    }
}
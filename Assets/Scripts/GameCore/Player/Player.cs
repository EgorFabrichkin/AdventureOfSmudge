using GameCore.Player.Inputs;
using GameCore.SpawnsObjects.Platforms;
using GameCore.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace GameCore.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Player : MonoBehaviour
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeSpriteColor();
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.collider.TryGetComponent(out Platform platform)) return;
            if (spriteRenderer.color == platform.SetColor())
            {
                //Crash();
            }
            Jump();
        }

        private void Crash() => rigidbody2D.isKinematic = true;

        private void Jump()
        {
            rigidbody2D.AddForce(Vector2.up * jumpPower);
            jumped.Invoke();
            //ChangeSpriteColor();
        }
        
        private void ChangeSpriteColor()
        {
            //var changeColor = new ChangeColor(spriteRenderer);
        }
    }
}
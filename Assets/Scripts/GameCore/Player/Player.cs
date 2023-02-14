using GameCore.Colors;
using GameCore.Platforms;
using GameCore.Player.Inputs;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace GameCore.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Player : MonoBehaviour
    {
        public UnityEvent jumped = new();
        public UnityEvent boosted = new();

        [SerializeField] private SpriteRenderer spriteRenderer = null!;
        [SerializeField] private float speed;
        [Header("Dependencies")] 
        [SerializeField] private PlayerInputBehavior playerInput = null!;
        
        private new Rigidbody2D rigidbody2D = null!;
        private new Collider2D collider2D = null!;

        private void Awake()
        {
            playerInput.EnsureNotNull("Input not specified");
            
            rigidbody2D = GetComponent<Rigidbody2D>()!;
            collider2D = GetComponent<Collider2D>()!;
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
        
        //РАЗДЕЛИТЬ НА 2 СКРИПТА?

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.collider.TryGetComponent(out Platform platform)) return;
            if (spriteRenderer.color == platform.SetColor())
            {
                Crash();
            }
            Jump();
        }

        private void Crash() => collider2D.enabled = false;

        private void Jump()
        {
            rigidbody2D.isKinematic = true;
            jumped.Invoke();
            //ChangeSpriteColor();
        }
        
        private void ChangeSpriteColor()
        {
            //var changeColor = new ChangeColor(spriteRenderer);
        }
    }
}
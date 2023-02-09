using GameCore.Player.Inputs;
using UnityEngine;
using Utils;

namespace GameCore.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed;
        [Header("Dependencies")] 
        [SerializeField] private PlayerInputBehavior playerInput = null!;
        
        private new Rigidbody2D rigidbody = null!;

        private void Awake()
        {
            playerInput.EnsureNotNull("Input not specified");
            rigidbody = GetComponent<Rigidbody2D>()!;
        }

        private void Update()
        {
            rigidbody.AddForce(
                playerInput.Direction().Flat()
                * speed
            );
        }
    }
}
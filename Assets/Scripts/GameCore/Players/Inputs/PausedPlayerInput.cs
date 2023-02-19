using GamePlayFlow;
using UnityEngine;
using Utils;

namespace GameCore.Players.Inputs
{
    public class PausedPlayerInput : PlayerInputBehavior, IPause
    {
        [SerializeField] private PlayerInputBehavior origin = null!;
        [SerializeField] private bool pause = false;

        private void Awake()
        {
            origin.EnsureNotNull("origin input not specified");
        }

        public void Paused(bool value)
        {
            pause = value;
        }
        
        public override Vector2 Direction()
        {
            return pause ? Vector2.zero : origin.Direction();
        }
    }
}
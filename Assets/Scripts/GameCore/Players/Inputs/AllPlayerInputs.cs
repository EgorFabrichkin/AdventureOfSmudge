using System;
using UnityEngine;

namespace GameCore.Players.Inputs
{
    public class AllPlayerInputs : PlayerInputBehavior
    {
        [SerializeField] private PlayerInputBehavior[] playerInputs = Array.Empty<PlayerInputBehavior>();
        
        public override Vector2 Direction()
        {
            var direction = Vector2.zero;

            foreach (var input in playerInputs)
            {
                direction += input.Direction();
            }
            
            return direction;
        }
    }
}
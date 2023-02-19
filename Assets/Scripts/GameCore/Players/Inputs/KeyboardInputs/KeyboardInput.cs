using UnityEngine;

namespace GameCore.Players.Inputs.KeyboardInputs
{
    public class KeyboardInput : PlayerInputBehavior
    {
        public override Vector2 Direction()
        {
            return new Vector2(Input.GetAxis("Horizontal"), 0);
        }
    }
}
using UnityEngine;

namespace GameCore.Player.Inputs
{
    public abstract class PlayerInputBehavior : MonoBehaviour, IPlayerInput
    {
        public abstract Vector2 Direction();
    }
}
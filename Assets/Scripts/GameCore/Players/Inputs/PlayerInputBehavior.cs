using UnityEngine;

namespace GameCore.Players.Inputs
{
    public abstract class PlayerInputBehavior : MonoBehaviour, IPlayerInput
    {
        public abstract Vector2 Direction();
    }
}
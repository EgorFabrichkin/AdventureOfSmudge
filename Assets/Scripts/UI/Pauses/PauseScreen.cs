using GameCore.Players;
using UnityEngine;
using Utils;

namespace UI.Pauses
{
    public class PauseScreen : MonoBehaviour
    {
        [SerializeField] private Canvas canvas = null!;

        private Player origin = null!;
        
        private void Start()
        {
            canvas.EnsureNotNull("pause canvas not specified").enabled = false;
        }

        private void OnPauseGame(bool value)
        {
            canvas.enabled = value;
            origin.PlayerPaused(value);
        }

        public void GetPausedObject(Player player) => origin = player;

        public void Pause()
        {
            OnPauseGame(true);
        }

        public void Continue()
        {
            OnPauseGame(false);
        }
    }
}
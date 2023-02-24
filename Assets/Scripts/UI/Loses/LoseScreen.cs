using GameCore.Players;
using UnityEngine;
using Utils;

namespace UI.Loses
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private Canvas canvas = null!;
        [SerializeField] private Canvas hud = null!;

        private Player origin = null!;
        
        private void Awake()
        {
            canvas.EnsureNotNull("Lose canvas not found").enabled = false;
        }

        private void Start()
        {
            origin.fail.AddListener(ShowLoseScreen);
        }

        private void ShowLoseScreen()
        {
            canvas.enabled = true;
            hud.enabled = false;
        }

        public void GetPlayer(Player player) => origin = player;
    }
}
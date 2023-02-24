using System.Collections.Generic;
using GameCore.Platforms;
using GameCore.Players;
using UnityEngine;
using Utils;

namespace GameCore.Colors
{
    public class ChangeColor : MonoBehaviour
    {
        [SerializeField] private Palette palette = null!;

        private List<Platform> actualPlatforms = null!;
        private Player origin = null!;

        private void Awake()
        {
            palette.EnsureNotNull("palette not found");
        }
        
        private void Start()
        {
            actualPlatforms.ForEach(
                p => p.SetColor(
                    new RandomColor(
                            palette,
                            p.GetColor()
                        )
                        .GetRandomColor()
                )
            );

            origin.jumped.AddListener(() =>
                origin.SetColor(
                    new RandomColor(
                            palette, 
                            origin.GetColor()
                        )
                        .GetRandomColor()
                )
            );
        }
        
        public void ActualPlatforms(List<Platform> platforms) => actualPlatforms = platforms;

        public void GetPlayer(Player player) => origin = player;
    }
}
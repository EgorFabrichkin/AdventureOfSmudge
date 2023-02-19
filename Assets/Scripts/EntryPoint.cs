using System.Collections.Generic;
using GameCore.Boosters.BoostersSpawns;
using GameCore.Colors;
using GameCore.Platforms.PlatformsSpawns;
using GameCore.Players;
using GameCore.Players.Inputs;
using GameCore.Players.Jumps;
using GamePlayFlow;
using UI;
using UnityEngine;
using Utils;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player player = null!;
    [SerializeField] private PausedPlayerInput pausedPlayerInput = null!;
    [SerializeField] private PlatformsSpawn platformsSpawn = null!;
    [SerializeField] private BoostersSpawn boostersSpawn = null!;
    [SerializeField] private Palette palette = null!;
    [Header("View")] 
    [SerializeField] private JumpCountView jumpCountView = null!;
    [SerializeField] private PauseScreen pauseScreen = null!;

    private List<IPause> pausedObjects = new(3);

    private void Awake()
    {
        player.EnsureNotNull("player not found");
        pausedPlayerInput.EnsureNotNull("paused player input not found");
        platformsSpawn.EnsureNotNull("platformsSpawn not found");
        boostersSpawn.EnsureNotNull("boostersSpawn not found");
        palette.EnsureNotNull("palette not found");
        pauseScreen.EnsureNotNull("pause screen not found");
        
        pausedObjects.Add(player);
        pausedObjects.Add(pausedPlayerInput);
        pausedObjects.Add(boostersSpawn);

        jumpCountView.EnsureNotNull("jumpCountView not found")
            .CountView(
                new JumpCount(player).MaxValue
            );
    }
    
    private void Start()
    {
        pauseScreen.PausedObjects(pausedObjects);
        
        foreach (var platform in platformsSpawn.ActualPlatforms())
        {
            platform.SetColor(
                new ChangeColor(
                    palette, 
                    platform.GetColor()
                    )
                    .GetRandomColor()
            );
        }

        player.jumped.AddListener(() =>
            player.SetColor(
                new ChangeColor(
                    palette, 
                    player.GetColor()
                    )
                    .GetRandomColor()
            )
        );
    }
    
    private void Update()
    {
        platformsSpawn.GetPlayerPosition(player.transform.position);
        boostersSpawn.PoolPlatforms(platformsSpawn.ActualPlatforms());
    }
}

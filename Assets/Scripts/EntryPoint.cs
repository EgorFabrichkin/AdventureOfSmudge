using GameCore.Boosters.BoostersSpawns;
using GameCore.Colors;
using GameCore.Platforms.PlatformsSpawns;
using GameCore.Players;
using GameCore.Players.Jumps;
using UI;
using UnityEngine;
using Utils;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player player = null!;
    [SerializeField] private PlatformsSpawn platformsSpawn = null!;
    [SerializeField] private BoostersSpawn boostersSpawn = null!;
    [SerializeField] private Palette palette = null!;
    [Header("View")] 
    [SerializeField] private JumpCountView jumpCountView = null!;

    private void Awake()
    {
        player.EnsureNotNull("player not found");
        platformsSpawn.EnsureNotNull("platformsSpawn not found");
        boostersSpawn.EnsureNotNull("boostersSpawn not found");
        palette.EnsureNotNull("palette not found");
        
        jumpCountView.EnsureNotNull("jumpCountView not found")
            .CountView(
                new JumpCount(player).MaxValue
            );

        foreach (var platform in platformsSpawn.ActualPlatforms())
        {
            platform.spawned.AddListener(() =>
                platform.SetColor(
                    new ChangeColor(
                            palette, 
                            platform.GetColor()
                        )
                        .GetRandomColor()
                    )
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

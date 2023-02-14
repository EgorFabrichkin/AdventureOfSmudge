using GameCore.Boosters;
using GameCore.Player;
using GameCore.Player.Jumps;
using GameCore.Spawns.BoostersSpawns;
using GameCore.Spawns.PlatformsSpawns;
using UI;
using UnityEngine;
using Utils;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player player = null!;
    [SerializeField] private PlatformsSpawn platformsSpawn = null!;
    [SerializeField] private BoostersSpawn boostersSpawn = null!;
    [Header("View")] 
    [SerializeField] private JumpCountView jumpCountView = null!;
    
    private void Awake()
    {
        player.EnsureNotNull("player not found");
        platformsSpawn.EnsureNotNull("platformsSpawn not found");
        boostersSpawn.EnsureNotNull("boostersSpawn not found");
        
        jumpCountView.EnsureNotNull("jumpCountView not found")
            .CountView(
                new JumpCount(player).MaxValue
            );
    }

    private void Update()
    {
        platformsSpawn.GetPlayerPosition(player.transform.position);
        boostersSpawn.PoolPlatforms(platformsSpawn.ActualPlatforms());
    }
}

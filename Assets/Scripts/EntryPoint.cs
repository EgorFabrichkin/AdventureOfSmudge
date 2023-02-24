using GameCore.Boosters.BoostersSpawns;
using GameCore.Colors;
using GameCore.Platforms.PlatformsSpawns;
using GameCore.Players;
using GameCore.Players.Distances;
using GameCore.Players.Jumps;
using UI.CountsView;
using UI.Loses;
using UI.Pauses;
using UnityEngine;
using Utils;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player player = null!;
    [SerializeField] private PlatformsSpawn platformsSpawn = null!;
    [SerializeField] private BoostersSpawn boostersSpawn = null!;
    [SerializeField] private ChangeColor changeColor = null!;
    [SerializeField] private JumpsCount jumpsCount = null!;
    [SerializeField] private DistanceCount distanceCount = null!;
    [Header("View")] 
    [SerializeField] private PauseScreen pauseScreen = null!;
    [SerializeField] private LoseScreen loseScreen = null!;
    [SerializeField] private CountView jumpsCountView = null!;
    [SerializeField] private CountView distanceCountView = null!;
    [SerializeField] private HighScoreView highScoreView = null!;
    
    private void Awake()
    {
        player.EnsureNotNull("player not found");
        platformsSpawn.EnsureNotNull("platformsSpawn not found");
        boostersSpawn.EnsureNotNull("boostersSpawn not found");
        
        changeColor.EnsureNotNull("changeColor not found")
            .GetPlayer(player);
        jumpsCount.EnsureNotNull("jumpCount not found")
            .GetPlayer(player);
        distanceCount.EnsureNotNull("distanceCount not found")
            .GetPlayer(player);
        pauseScreen.EnsureNotNull("pauseScreen not found")
            .GetPausedObject(player);
        loseScreen.EnsureNotNull("loseScreen not found")
            .GetPlayer(player);
        
        jumpsCountView.EnsureNotNull("jumpCountView not found")
            .ValueView(
                jumpsCount.Count
            );
        distanceCountView.EnsureNotNull("distanceCountView not found")
            .ValueView(
                distanceCount.CurrentScore
            );
        highScoreView.EnsureNotNull("highScoreView not found")
            .ValueView(
                distanceCount.HighScore
            );
        
        changeColor.ActualPlatforms(platformsSpawn.ActualPlatforms());
    }

    private void Update()
    {
        platformsSpawn.GetPlayerPosition(player.transform.position);
        boostersSpawn.PoolPlatforms(platformsSpawn.ActualPlatforms());
    }
}

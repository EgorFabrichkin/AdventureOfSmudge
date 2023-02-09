using GameCore.Player;
using UnityEngine;
using Utils;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player player = null!;

    private void Awake()
    {
        player.EnsureNotNull("player not found");
    }
}

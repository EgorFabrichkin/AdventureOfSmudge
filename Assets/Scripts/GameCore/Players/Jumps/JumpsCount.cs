using GameCore.Boosters;
using UniRx;
using UnityEngine;

namespace GameCore.Players.Jumps
{
    public class JumpsCount : MonoBehaviour
    {
        [SerializeField] private IntReactiveProperty maxValue = new (20);
        [Header("Boosters")]
        [SerializeField] private Booster[] boosters = {  };
        [SerializeField] private int boostValue;

        private Player origin = null!;
        
        private void Start()
        {
            origin.jumped.AddListener(() => maxValue.Value--);
        }

        private void Update()
        {
            boosters = FindObjectsOfType<Booster>()!;
            foreach (var booster in boosters)
            {
                booster.collected.AddListener(
                    () => maxValue.Value = boostValue
                );
            }

            if (maxValue.Value <= 0)
            {
                StartCoroutine(origin.PlayerFailed());
            }
        }
        
        public ReactiveProperty<int> Count => maxValue;

        public void GetPlayer(Player player) => origin = player;
    }
}
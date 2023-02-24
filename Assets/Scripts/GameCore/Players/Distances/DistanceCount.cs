using UniRx;
using UnityEngine;

namespace GameCore.Players.Distances
{
    public class DistanceCount : MonoBehaviour
    {
        private readonly IntReactiveProperty maxValue = new ();
        private readonly IntReactiveProperty currentValue = new ();
        
        private const string Key = "Score";
        private float startPoint;
        
        private Player origin = null!;

        private void Start()
        {
            startPoint = origin.transform.position.y;
            maxValue.Value = PlayerPrefs.GetInt(Key, 0);
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetInt(Key, maxValue.Value);
        }

        private void Update()
        {
            currentValue.Value = (int)Mathf.Abs(origin.transform.position.y - startPoint);
            
            if (currentValue.Value >= maxValue.Value)
            {
                maxValue.Value = currentValue.Value;
            }
        }

        public IReadOnlyReactiveProperty<int> HighScore => maxValue;
        public IReadOnlyReactiveProperty<int> CurrentScore => currentValue;
        
        public void GetPlayer(Player player) => origin = player;
    }
}
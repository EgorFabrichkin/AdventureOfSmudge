using UnityEngine;

namespace GameCore.Boosters
{
    [RequireComponent(typeof(Booster))]
    public class CollectedBooster : MonoBehaviour
    {
        [SerializeField] private float delay;
        private void Awake()
        {
            GetComponent<Booster>()!.collected.AddListener(() => Destroy(gameObject, delay));
        }
    }
}
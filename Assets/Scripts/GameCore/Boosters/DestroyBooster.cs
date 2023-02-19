using UnityEngine;

namespace GameCore.Boosters
{
    [RequireComponent(typeof(Booster))]
    public class DestroyBooster : MonoBehaviour
    {
        [SerializeField] private float delay;

        private void Awake()
        {
            GetComponent<Booster>()!.destroyed.AddListener(() => Destroy(gameObject, delay));
        }
    }
}
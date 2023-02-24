using UnityEngine;

namespace GameCore.Boosters
{
    [RequireComponent(typeof(Booster))]
    public class DestroyedBooster : MonoBehaviour
    {
        [SerializeField] private float delay;

        private void Awake()
        {
            GetComponent<Booster>()!.destroyed.AddListener(() => Destroy(gameObject, delay));
        }
    }
}
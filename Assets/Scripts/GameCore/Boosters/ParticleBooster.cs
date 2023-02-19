using UnityEngine;
using Utils;

namespace GameCore.Boosters
{
    [RequireComponent(typeof(Booster))]
    public class ParticleBooster : MonoBehaviour
    {
        [SerializeField] private new ParticleSystem particleSystem = null!;
        
        private void Awake()
        {
            particleSystem.EnsureNotNull("Particle System not specified");

            GetComponent<Booster>()!.destroyed.AddListener(() =>
            {
                particleSystem.transform.SetParent(null!);
                particleSystem.Play();
            });
        }
    }
}
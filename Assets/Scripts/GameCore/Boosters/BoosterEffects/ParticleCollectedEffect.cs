using UnityEngine;
using Utils;

namespace GameCore.Boosters.BoosterEffects
{
    [RequireComponent(typeof(Booster))]
    public class ParticleCollectedEffect : MonoBehaviour
    {
        [SerializeField] private new ParticleSystem particleSystem = null!;
        
        private void Awake()
        {
            particleSystem.EnsureNotNull("Particle System not specified");

            GetComponent<Booster>()!.collected.AddListener(() =>
            {
                particleSystem.transform.SetParent(null!);
                particleSystem.Play();
            });
        }
    }
}
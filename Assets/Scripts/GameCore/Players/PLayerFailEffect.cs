using UnityEngine;
using Utils;

namespace GameCore.Players
{
    [RequireComponent(typeof(Player))]
    public class PLayerFailEffect : MonoBehaviour
    {
        [SerializeField] private new ParticleSystem particleSystem = null!;
        
        private void Awake()
        {
            particleSystem.EnsureNotNull("particleSystem player not specified");
            
            GetComponent<Player>()!.fail.AddListener(
                () =>
                {
                    particleSystem.transform.SetParent(null!);
                    particleSystem.Play();
                } 
            );
        }
    }
}
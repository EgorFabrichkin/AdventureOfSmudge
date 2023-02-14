using System.Collections;
using System.Collections.Generic;
using GameCore.Platforms;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace GameCore.Spawns.BoostersSpawns
{
    public class BoostersSpawn : SimpleSpawn
    {
        [SerializeField] private Booster boosterPrefabs = null!;
        [SerializeField] private int countBooster;
        [SerializeField] private float lifeTimeBooster;
        [SerializeField] private int minStep;
        [SerializeField] private int maxStep;
        
        private ObjectPool<Booster> boostersPool = null!;
        private IReadOnlyList<Platform> actualPlatforms = null!;

        private readonly Vector3 distance = new (0, 1, 0);
        
        private void Awake()
        {
            boostersPool = new ObjectPool<Booster>(
                boosterPrefabs.EnsureNotNull("platform not specified"),
                countBooster
            );
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(Spawn());
            }
        }

        public override IEnumerator Spawn()
        {
            var newBooster = boostersPool.TryGetObject();

            newBooster.transform.SetPositionAndRotation(
                actualPlatforms[Random.Range(
                                    minStep, 
                                    maxStep)]
                    .transform.position 
                + distance,
                Quaternion.identity
            );
            
            yield return new WaitForSeconds(lifeTimeBooster);
            
            boostersPool.ReturnToPool(newBooster);
        }

        public void PoolPlatforms(IReadOnlyList<Platform> platforms) => actualPlatforms = platforms;
    }
}
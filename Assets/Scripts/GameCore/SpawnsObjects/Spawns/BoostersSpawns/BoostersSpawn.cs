using System.Collections;
using System.Collections.Generic;
using GameCore.SpawnsObjects.Boosters;
using GameCore.SpawnsObjects.Platforms;
using GameCore.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameCore.SpawnsObjects.Spawns.BoostersSpawns
{
    public class BoostersSpawn : SimpleSpawn
    {
        [SerializeField] private Booster boosterPrefabs = null!;
        [SerializeField] private int countBooster;
        [SerializeField] private int minStep;
        [SerializeField] private int maxStep;
        [Header("Timers")]
        [SerializeField] private float lifeTimeBooster;
        [SerializeField] private float firstBoosterSpawn;
        [SerializeField] private Delay delay = null!;
        
        private ObjectPool<Booster> boostersPool = null!;
        private IReadOnlyList<Platform> actualPlatforms = null!;

        private void Awake()
        {
            boostersPool = new ObjectPool<Booster>(
                boosterPrefabs.EnsureNotNull("platform not specified"),
                countBooster
            );
        }

        private void Update()
        {
            if (Time.time >= firstBoosterSpawn && delay.TryReset())
            {
                StartCoroutine(Spawn());
            }
        }

        public override IEnumerator Spawn()
        {
            var newBooster = boostersPool.TryGetObject();

            var distanceOverPlatform = new Vector3(0, 1, 0);
            
            newBooster.transform.SetPositionAndRotation(
                actualPlatforms[Random.Range(
                                    minStep, 
                                    maxStep)]
                    .transform.position 
                + distanceOverPlatform,
                Quaternion.identity
            );
            
            newBooster.collected.AddListener(() => boostersPool.ReturnToPool(newBooster));
            
            yield return new WaitForSeconds(lifeTimeBooster);
            
            boostersPool.ReturnToPool(newBooster);
        }

        public void PoolPlatforms(IReadOnlyList<Platform> platforms) => actualPlatforms = platforms;
    }
}
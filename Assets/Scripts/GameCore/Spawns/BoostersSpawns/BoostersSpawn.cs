using System.Collections;
using System.Collections.Generic;
using GameCore.Boosters;
using GameCore.Platforms;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace GameCore.Spawns.BoostersSpawns
{
    public class BoostersSpawn : SimpleSpawn
    {
        [SerializeField] private Booster boosterPrefabs = null!;
        [SerializeField] private int countBooster = 10;
        [SerializeField] private float lifeTimeBooster = 5f;
        [SerializeField] private int minStep;
        [SerializeField] private int maxStep;
        
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
            //Debug:
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(Spawn());
            }
        }

        public override IEnumerator Spawn()
        {
            var newBooster = boostersPool.TryGetObject();

            var distance = new Vector3(0, 1, 0);
            
            newBooster.transform.SetPositionAndRotation(
                actualPlatforms[Random.Range(
                                    minStep, 
                                    maxStep)]
                    .transform.position 
                + distance,
                Quaternion.identity
            );
            
            newBooster.collected.AddListener(() => boostersPool.ReturnToPool(newBooster));
            
            yield return new WaitForSeconds(lifeTimeBooster);
            
            boostersPool.ReturnToPool(newBooster);
        }

        public void PoolPlatforms(IReadOnlyList<Platform> platforms) => actualPlatforms = platforms;
    }
}
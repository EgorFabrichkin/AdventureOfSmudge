using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameCore.SpawnsObjects.Platforms;
using GameCore.Utils;
using UnityEngine;

namespace GameCore.SpawnsObjects.Spawns.PlatformsSpawns
{
    public class PlatformsSpawn : SimpleSpawn
    {
        [SerializeField] private Platform platformPrefabs = null!;
        [SerializeField] private int countPlatform;
        [SerializeField] private int countPlatformToStart;
        [SerializeField] private float maxCountPlatformPerLevel;
        [Header("Spawn Area")] 
        [SerializeField] private float previousSpawnPoint;
        [SerializeField] private float minX;
        [SerializeField] private float maxX;
        [SerializeField] private float nextSpawnPoint;
        [SerializeField] private float preSpawnDistance;
        
        private ObjectPool<Platform> platformPool = null!;
        private List<Platform> actualplatform = new();

        private Vector3 playerPosition;
        
        private void Awake()
        {
            platformPool = new ObjectPool<Platform>(
                platformPrefabs.EnsureNotNull("platform not specified"),
                countPlatform
            );

            for (var i = 0; i < countPlatformToStart; i++)
            {
                StartCoroutine(Spawn());
            }
        }
        
        private void Update()
        {
            if (playerPosition.y + preSpawnDistance >= previousSpawnPoint)
            {
                StartCoroutine(Spawn());
            }
        }

        public override IEnumerator Spawn()
        {
            var newPlatform = platformPool.TryGetObject();
            actualplatform.Add(newPlatform);
            
            var minDistanceBetweenPlatforms = 1f;

            newPlatform.transform.SetPositionAndRotation(
                new Vector3(
                    Random.Range(
                        playerPosition.x - minX,
                        playerPosition.x + maxX),
                    Random.Range(
                        previousSpawnPoint + minDistanceBetweenPlatforms, 
                        previousSpawnPoint + nextSpawnPoint), 
                    0),
                Quaternion.identity
            );
            
            previousSpawnPoint = newPlatform.transform.position.y;

            yield return new WaitUntil(() => actualplatform.Count >= maxCountPlatformPerLevel);
            
            platformPool.ReturnToPool(actualplatform.ElementAt(0));
            actualplatform.RemoveAt(0);
        }

        public void GetPlayerPosition(Vector3 position) => playerPosition = position;

        public List<Platform> ActualPlatforms() => actualplatform;
    }
}
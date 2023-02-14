using System.Collections;
using System.Collections.Generic;
using GameCore.Platforms;
using UnityEngine;
using Utils;

namespace GameCore.Spawns.PlatformsSpawns
{
    public class PlatformsSpawn : SimpleSpawn
    {
        [SerializeField] private Platform platformPrefabs = null!;
        [SerializeField] private int countPlatform;
        [Header("Spawn Area")] 
        [SerializeField] private float minX;
        [SerializeField] private float maxX;
        [SerializeField] private float nextSpawnPoint;
        [SerializeField] private float preSpawnDistance;
        
        private ObjectPool<Platform> platformPool = null!;
        private List<Platform> actualplatform = new();

        private Vector3 playerPosition;
        private float previousSpawnPoint;
        
        private void Awake()
        {
            platformPool = new ObjectPool<Platform>(
                platformPrefabs.EnsureNotNull("platform not specified"),
                countPlatform
            );
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
            
            var distance = 1f;

            newPlatform.transform.SetPositionAndRotation(
                new Vector3(
                    Random.Range(
                        playerPosition.x - minX,
                        playerPosition.x + maxX),
                    Random.Range(
                        previousSpawnPoint + distance, 
                        previousSpawnPoint + nextSpawnPoint), 
                    0),
                Quaternion.identity
            );
            
            previousSpawnPoint = newPlatform.transform.position.y;

            yield return new WaitForSeconds(50);
            //yield return new WaitUntil(() => playerPosition.y >= previousSpawnPoint);

            platformPool.ReturnToPool(newPlatform);
            actualplatform.Remove(newPlatform);
        }

        public void GetPlayerPosition(Vector3 position) => playerPosition = position;

        public List<Platform> ActualPlatforms()
        {
            return actualplatform;
        }
    }
}
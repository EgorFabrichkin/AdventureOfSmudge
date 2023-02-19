using System.Collections;
using System.Collections.Generic;
using GameCore.Platforms;
using GamePlayFlow;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace GameCore.Boosters.BoostersSpawns
{
    public class BoostersSpawn : MonoBehaviour, IPause
    {
        [SerializeField] private Booster boosterPrefabs = null!;
        [SerializeField] private int minStep;
        [SerializeField] private int maxStep;
        [Header("Timers")]
        [SerializeField] private float lifeTimeBooster;
        [SerializeField] private float firstBoosterSpawn;
        [SerializeField] private Delay delay = null!;
        [Header("Debug")] [SerializeField] private bool pause = false;
        
        private IReadOnlyList<Platform> actualPlatforms = null!;

        private void Update()
        {
            if (Time.time >= firstBoosterSpawn && delay.TryReset() && pause == false)
            {
                StartCoroutine(Spawn());
            }
        }

        private IEnumerator Spawn()
        {
            var newBooster = Instantiate(boosterPrefabs);

            var distanceOverPlatform = new Vector3(0, 0.5f, 0);

            newBooster.transform.SetPositionAndRotation(
                actualPlatforms[Random.Range(
                                    minStep, 
                                    maxStep)]
                    .transform.position 
                + distanceOverPlatform,
                Quaternion.identity
            );

            yield return new WaitForSeconds(lifeTimeBooster);
            
            newBooster.destroyed.Invoke();
        }

        public void PoolPlatforms(IReadOnlyList<Platform> platforms) => actualPlatforms = platforms;
        
        public void Paused(bool value) => pause = value;
    }
}
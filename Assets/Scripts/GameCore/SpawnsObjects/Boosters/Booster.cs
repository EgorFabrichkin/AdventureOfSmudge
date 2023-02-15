using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameCore.SpawnsObjects.Boosters
{
    [RequireComponent(typeof(Collider2D))]
    public class Booster : MonoBehaviour
    {
        public UnityEvent collected = new();
        
        private void Awake()
        {
            if (GetComponent<Collider2D>()!.isTrigger == false)
            {
                throw new Exception("Must be trigger");
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("is trigger");
            collected.Invoke();
        }
    }
}
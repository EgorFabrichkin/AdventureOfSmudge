using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameCore.Boosters
{
    [RequireComponent(typeof(Collider2D))]
    public class Booster : MonoBehaviour
    {
        public UnityEvent collected = new();
        public UnityEvent destroyed = new();
        
        private void Awake()
        {
            if (GetComponent<Collider2D>()!.isTrigger == false)
            {
                throw new Exception("Must be trigger");
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            collected.Invoke();
        }
    }
}
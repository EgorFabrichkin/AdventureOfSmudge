using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameCore
{
    [RequireComponent(typeof(Collider2D))]
    public class Booster : MonoBehaviour
    {
        public UnityEvent collected = new();
        
        private void Awake()
        {
            if (GetComponent<Collider>()!.isTrigger == false)
            {
                throw new Exception("Must be trigger");
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            collected.Invoke();
        }
    }
}
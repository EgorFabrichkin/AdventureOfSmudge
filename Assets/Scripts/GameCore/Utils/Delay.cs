using System;
using UnityEngine;

namespace GameCore.Utils
{
    [Serializable]
    public class Delay
    {
        [SerializeField] private float value;
        
        private float timesUp;
        
        public bool TryReset()
        {
            if (IsReady)
            {
                timesUp = Time.time + value;
                return true;
            }

            return false;
        }
        public bool IsReady => timesUp <= Time.time; 
    }
}
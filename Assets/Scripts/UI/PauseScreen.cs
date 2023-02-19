using System.Collections.Generic;
using GamePlayFlow;
using UnityEngine;
using Utils;

namespace UI
{
    public class PauseScreen : MonoBehaviour
    {
        [SerializeField] private Canvas canvas = null!;

        private List<IPause> array = null!;

        private void Start()
        {
            canvas.EnsureNotNull("pause canvas not specified").enabled = false;
        }

        public void Paused()
        {
            PausedObject(true);
        }

        public void Continue()
        {
            PausedObject(false);
        }
        
        private void PausedObject(bool value)
        {
            canvas.enabled = value;
            foreach (var obj in array)
            {
                obj.Paused(value);
            }
        }
        
        public void PausedObjects(List<IPause> objectArray) => array = objectArray;
    }
}
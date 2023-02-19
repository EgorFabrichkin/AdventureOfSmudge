using System.Collections;
using GamePlayFlow;
using UnityEngine;
using Utils;

namespace UI
{
    public class PauseScreen : MonoBehaviour
    {
        [SerializeField] private Canvas canvas = null!;

        private void Awake()
        {
            canvas.EnsureNotNull("canvas not specified").enabled = false;
        }

        public void Paused()
        {
            StartCoroutine(Pause());
        }

        private IEnumerator Pause()
        {
            canvas.enabled = true;

            foreach (var item in GetComponents<IPause>())
            {
                item.Paused(true);
            }

            yield return new WaitForSeconds(10);
            
            canvas.enabled = false;
        }
    }
}
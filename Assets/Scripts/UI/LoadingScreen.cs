using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Canvas canvas = null!;
        [SerializeField] private Slider slider = null!;
        [SerializeField] private float artificialDelay = 0.2f;
        private const float FullLoad = 1;


        private void Awake()
        {
            slider.EnsureNotNull("slider not specified");
            canvas.EnsureNotNull("canvas not specified").enabled = false;
            DontDestroyOnLoad(gameObject);
        }


        public void LoadScene(int sceneId)
        {
            StartCoroutine(Load(sceneId));
        }


        private IEnumerator Load(int sceneId)
        {
            canvas.enabled = true;
            var operation = SceneManager.LoadSceneAsync(sceneId)!;
            while (operation.isDone == false)
            {
                slider.value = operation.progress;
                yield return null;
            }

            slider.value = FullLoad;
            yield return new WaitForSecondsRealtime(artificialDelay);
            canvas.enabled = false;
        }
    }
}
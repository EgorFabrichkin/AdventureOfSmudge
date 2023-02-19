using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class JumpCountView : MonoBehaviour
    {
        [SerializeField] private Text text = null!;

        private void Awake()
        {
            text.EnsureNotNull("Text not specified");
        }

        public void CountView(IReadOnlyReactiveProperty<int> jumpCount) => jumpCount.Subscribe(Render);
        private void Render(int value) => text.text = $"{value}";
    }
}
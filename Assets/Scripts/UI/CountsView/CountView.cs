using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.CountsView
{
    public class CountView : MonoBehaviour
    {
        [SerializeField] private Text text = null!;

        private void Awake()
        {
            text.EnsureNotNull("Text distance count not specified");
        }

        public void ValueView(IReadOnlyReactiveProperty<int> value) => value.Subscribe(Render);

        private void Render(int value) => text.text = $"{value}";
    }
}
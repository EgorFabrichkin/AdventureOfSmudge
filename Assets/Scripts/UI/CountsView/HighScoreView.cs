using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.CountsView
{
    public class HighScoreView : MonoBehaviour
    {
        [SerializeField] private Text text = null!;

        private void Awake()
        {
            text.EnsureNotNull("Text high score not specified");
        }

        public void ValueView(IReadOnlyReactiveProperty<int> value) => value.Subscribe(Render);

        private void Render(int value) => text.text = $"Best Score: {value}";
    }
}
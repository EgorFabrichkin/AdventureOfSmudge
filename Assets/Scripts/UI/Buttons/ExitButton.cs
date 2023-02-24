using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ExitButton : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>()!.EnsureNotNull("Restart button not specified")
                .onClick.AddListener(
                    Application.Quit
                );
        }
    }
}
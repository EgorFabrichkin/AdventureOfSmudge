using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;

namespace GameCore.Player.Inputs.AndroidInputs
{
    [RequireComponent(typeof(RectTransform))]
    public class SwipeInput : PlayerInputBehavior, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private Image knob = null!;
        [SerializeField] private float maxDistance;
        [Header("Debug")] 
        [SerializeField] private Vector2 startPosition;
        [SerializeField] private Vector2 output;

        private void Awake()
        {
            knob.EnsureNotNull("knob not specified");
        }

        public override Vector2 Direction()
        {
            return output;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            knob.enabled = true;
            startPosition = eventData.position;
            output = Vector2.zero;
            knob.transform.position = startPosition;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            knob.enabled = false;
            output = Vector2.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var raw = eventData.position - startPosition;
            var rawNormalize = raw.normalized;
            var magnitude = raw.magnitude;

            knob.transform.position =
                magnitude > maxDistance
                    ? startPosition + (rawNormalize * maxDistance) 
                    : eventData.position;

            output = (
                knob.transform.position - 
                new Vector3(
                    startPosition.x,
                    startPosition.y)
            ) / maxDistance;
        }
    }
}
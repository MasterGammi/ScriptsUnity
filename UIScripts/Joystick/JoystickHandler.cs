using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _joystickBackgraund;
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _joystickArea;

    private Vector2 _joystickPosition;

    protected Vector2 _joystickVector;

    [SerializeField] private Color[] _joystickColor = new Color[2];

    private void Start()
    {
        _joystickPosition = _joystickBackgraund.rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}

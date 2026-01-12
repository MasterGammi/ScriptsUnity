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
        Vector2 joystickPosition;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackgraund.rectTransform, eventData.position, null, out joystickPosition))
        {
            joystickPosition.x = (joystickPosition.x * 2 / _joystickBackgraund.rectTransform.sizeDelta.x);
            joystickPosition.y = (joystickPosition.y * 2 / _joystickBackgraund.rectTransform.sizeDelta.y);

            _joystickVector = new Vector2(joystickPosition.x, joystickPosition.y);

            _joystickVector = (_joystickVector.magnitude > 1f) ? _joystickVector.normalized : _joystickVector;

            _joystick.rectTransform.anchoredPosition = new Vector2(_joystickVector.x * (_joystickBackgraund.rectTransform.sizeDelta.x / 2), _joystickVector.y * (_joystickBackgraund.rectTransform.sizeDelta.y / 2));
        }
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

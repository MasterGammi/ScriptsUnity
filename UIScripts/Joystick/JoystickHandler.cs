using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _joystickBackgraund;
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _joystickArea;

    private Vector2 _joystickStartPosition;

    protected Vector2 _joystickVector;

    [SerializeField] private Color _joystickColor;

    private void Start()
    {
        _joystickStartPosition = _joystickBackgraund.rectTransform.anchoredPosition;
        _joystick.color = _joystickColor;
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
        Vector2 joystickBackgroundPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickArea.rectTransform, eventData.position, null, out joystickBackgroundPosition))
        {

            _joystickBackgraund.rectTransform.anchoredPosition = new Vector2(joystickBackgroundPosition.x, joystickBackgroundPosition.y);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _joystickBackgraund.rectTransform.anchoredPosition = _joystickStartPosition;

        _joystickVector = Vector2.zero;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

}

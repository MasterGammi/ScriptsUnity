using UnityEngine;
using UnityEngine.UI;

public class HealthbarOverhead : MonoBehaviour
{
    [Header("HP_Bar")]
    [SerializeField] private Image _barFilling;

    [Header("—сылка на Health")]
    [SerializeField] private Health _health;

    [Header("√радиент")]
    [SerializeField] private Gradient _gradient;


    private void Awake()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }
    private void OnHealthChanged(float value)
    {
        Debug.Log(value);
        _barFilling.fillAmount = value;
        _barFilling.color = _gradient.Evaluate(value);
    }
}

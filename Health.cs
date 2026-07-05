using System;
using System.IO;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Количество максимальных жизней")]
    [SerializeField] private float _maxHealth = 100.0f;
    private float _health;

    public event Action<float> HealthChanged;

    private void Start() => _health = _maxHealth;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) ChangeHealth(-10);
    }

    private void ChangeHealth(float value)
    {
        _health += value;
        if (_health < 0) Death();
        else HealthChanged?.Invoke(_health / _maxHealth);
    }

    private void Death() => HealthChanged?.Invoke(0);
}

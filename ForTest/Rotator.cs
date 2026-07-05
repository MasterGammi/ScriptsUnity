using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Header("Кординаты для ротации")]
    [SerializeField] private float _x = 0;
    [SerializeField] private float _y = 0;
    [SerializeField] private float _z = 0;

    private void Update() => transform.Rotate(_x, _y, _z);
}

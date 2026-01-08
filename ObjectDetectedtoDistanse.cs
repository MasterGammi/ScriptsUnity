using TMPro;
using UnityEngine;

public class ObjectDetectedtoDistanse : MonoBehaviour
{
    [Header("Обьект вычисления дистанции")]
    [SerializeField] private GameObject _enemyObject;
    private GameObject _object;

    [Space(1)]
    [Header("Обьект куда передается текст")]
    [SerializeField] private TextMeshProUGUI text;

    private float _dictanceToPlayer;

    private Vector3 _directionToPlayer;
    private Vector3 _enemyPositions;
    private void Start()
    {
        _object = gameObject;
        _enemyPositions = _enemyObject.transform.position;

        //Проверка на обьект
        if (_object == null) Debug.LogError("Rigidbody не найден!");
        
    }
    private void Update()
    {
        _directionToPlayer = _object.transform.position - _enemyPositions;
        _dictanceToPlayer = _directionToPlayer.magnitude;

        text.text = _dictanceToPlayer.ToString("0.0");
    }

}

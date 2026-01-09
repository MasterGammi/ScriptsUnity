using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Скорость персонажа")]
    [SerializeField] private float _move = 100;

    private CharacterController _characterController;

    private Vector3 _moveCharacter;

    private void Start() => _characterController = GetComponent<CharacterController>();

    private void Update()
    {

        _moveCharacter = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical")).normalized;

        _characterController.Move(_moveCharacter * Time.deltaTime * _move);
    }

}

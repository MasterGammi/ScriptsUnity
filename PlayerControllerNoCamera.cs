using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerControllerNoCamera : MonoBehaviour
{
    [Header("Скорость персонажа")]
    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private float _rotateSpeed = 2;

    [Header("Парамаетры гравитации")]
    [SerializeField] private float _graviryForce = 10;
    private float _currentAttractionCharacter = 0;


    private CharacterController _characterController;


    private void Start() => _characterController = GetComponent<CharacterController>();

    private void Update()
    {
        GravityHanding();

        var InputArrow = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        MoveCharacter(InputArrow);
        RotateCharacter(InputArrow);
    }

    public void MoveCharacter(Vector3 moveDirection)
    {
        moveDirection.y = _currentAttractionCharacter;
        _characterController.Move(moveDirection * Time.deltaTime * _moveSpeed);
    }
    public void RotateCharacter(Vector3 moveDirection)
    {
        if(_characterController.isGrounded)
            if(Vector3.Angle(transform.forward, moveDirection) > 0)
                transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0));

    }

    private void GravityHanding() =>
        _currentAttractionCharacter = _characterController.isGrounded
            ? 0
            : _currentAttractionCharacter - _graviryForce * Time.deltaTime;
}

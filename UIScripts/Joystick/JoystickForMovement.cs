using UnityEngine;

public class JoystickForMovement : JoystickHandler
{
    public Vector3 ReturnVectorDirection()
    {
        if (_joystickVector.x != 0 || _joystickVector.y != 0) return new Vector3(_joystickVector.x, 0, _joystickVector.y);
        else return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}

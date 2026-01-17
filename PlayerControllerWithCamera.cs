using UnityEngine;

public class PlayerControllerWithCamera : PlayerControllerNoCamera
{
    private void Update()
    {
        GravityHandling();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Создаём направление в локальной плоскости камеры
        Vector3 moveDirection = Vector3.zero;
        if (_mainCamera != null)
        {
            // Берём направление вперёд и вправо от камеры, но только по горизонтали (Y = 0)
            Vector3 forward = _mainCamera.transform.forward;
            Vector3 right = _mainCamera.transform.right;

            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            moveDirection = forward * vertical + right * horizontal;
        }
        else
        {
            // Если нет камеры — используем мировые оси (как у тебя было)
            moveDirection = new Vector3(horizontal, 0f, vertical);
        }

        moveDirection = moveDirection.normalized; // важно! иначе диагональ будет быстрее

        MoveCharacter(moveDirection);
        RotateCharacter(moveDirection);
    }
}

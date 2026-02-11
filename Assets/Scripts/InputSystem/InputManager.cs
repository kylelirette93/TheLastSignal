using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour, Input.IPlayerActions
{
    public event Action<Vector2> MoveInputEvent;
    public event Action<Vector2> LookInputEvent;

    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            LookInputEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MoveInputEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour, Input.IPlayerActions
{
    public event Action<Vector2> MoveInputEvent;
    public event Action<Vector2> LookInputEvent;
    public event Action<InputAction.CallbackContext> InteractEvent;

    public void OnLook(InputAction.CallbackContext context)
    {
        LookInputEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInputEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        InteractEvent?.Invoke(context);
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour, Input.IPlayerActions
{
    public event Action<Vector2> MoveInputEvent;
    public event Action<Vector2> LookInputEvent;

    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log($"Move phase: {context.phase} | Value: {context.ReadValue<Vector2>()}");
        if (context.started)
        {
            LookInputEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log($"Move phase: {context.phase} | Value: {context.ReadValue<Vector2>()}");
        if (context.started)
        {
            MoveInputEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }
}

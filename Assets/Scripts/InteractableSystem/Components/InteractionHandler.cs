using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] private float radius = 2f;
    [SerializeField] private LayerMask interactableLayers;
    [SerializeField] private InteractPrompt prompt;
    private Collider[] buffer = new Collider[32];
    private IInteractable focused;
    [SerializeField] private InputManager inputManager;

    private void OnEnable()
    {
        #region Setup Inputs
        if (inputManager == null)
        {
            inputManager = GetComponentInChildren<InputManager>();
            if (inputManager == null)
            {
                Debug.LogError("InputManager not found in children.");
                return;
            }
        }
        inputManager.InteractEvent += OnInteract;
        #endregion
    }
    private void Update()
    {
        IInteractable nearest = FindNearestInteractable();
        UpdateFocus(nearest);
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (focused != null)
            {
                if (focused.CanInteract()) focused.Interact();
            }
        }
    }

    private IInteractable FindNearestInteractable()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position, radius, buffer, interactableLayers, QueryTriggerInteraction.Collide);
        IInteractable nearest = null;
        float bestDistanceSq = float.MaxValue;

        for (int i = 0; i < count; i++)
        {
            Collider col = buffer[i];
            if (col == null) continue;
            IInteractable interactable = col.GetComponentInParent<IInteractable>();
            if (interactable == null) continue;
            if (!interactable.CanInteract()) continue;
            float distSq = (col.transform.position - transform.position).sqrMagnitude;
            if (distSq < bestDistanceSq)
            {
                bestDistanceSq = distSq;
                nearest = interactable;
            }
        }
        return nearest;
    }

    private void UpdateFocus(IInteractable nearest)
    {
        if (ReferenceEquals(focused, nearest)) return;
        focused?.OnLoseFocus();
        focused = nearest;
        if (focused != null)
        {
            focused?.OnFocus();
            prompt.Show(focused);
        }
        else
        {
            prompt.Hide();
        }
    }
}

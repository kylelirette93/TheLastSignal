using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private string displayName = "Interact"; // Default display name for the interactable object
    [SerializeField] private bool isEnabled = true;
    [SerializeField] private UnityEvent OnInteract;
    [SerializeField] private float outlineWidth = 2f;
    public string DisplayName => displayName;

    public bool CanInteract() => isEnabled;

    private Outline outline;

    private void Awake()
    {
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.green;
        outline.OutlineWidth = outlineWidth;
        outline.enabled = false;

    }

    public void Interact()
    {
        OnInteract?.Invoke();
    }

    public void OnFocus()
    {
        outline.enabled = true;
    }

    public void OnLoseFocus()
    {
        outline.enabled = false;
    }
}

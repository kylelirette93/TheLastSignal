using UnityEngine;
using UnityEngine.Events;

public class DialogueInteractable : MonoBehaviour, IInteractable
{
    public string DisplayName => "Tune in";
    [SerializeField] private UnityEvent OnInteract;
    [SerializeField] private float outlineWidth = 2f;
    private Outline outline;

    public bool CanInteract() => CanInteract();

    public void Interact() => OnInteract?.Invoke();

    private void Awake()
    {
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.green;
        outline.OutlineWidth = outlineWidth;
        outline.enabled = false;
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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractPrompt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Vector3 worldOffset = new(0f, 1f, 0f);
    [SerializeField] private string keyHint = "[E]";
    private Camera cam;
    private Transform target;
    private Canvas canvas;
    private RectTransform canvasRect;
    private RectTransform labelRect;

    private void Awake()
    {
        cam = Camera.main;
        labelRect = label.rectTransform;
        canvas = label.GetComponentInParent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();
        Hide();
    }

    private void LateUpdate()
    {
        if (target == null) return;
        Vector3 worldPos = target.position + worldOffset;
        Vector3 screenPos = cam.WorldToScreenPoint(worldPos);
        Camera uiCam = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : cam;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, uiCam, out Vector2 localPoint))
        {
            labelRect.anchoredPosition = localPoint;
        }
    }

    public void Show(IInteractable interactable)
    {
        if (interactable == null)
        {
            Hide();
            return;
        }
        target = interactable.transform;
        label.text = $"{keyHint}{interactable.DisplayName}";
        label.gameObject.SetActive(true);
    }

    public void Hide()
    {
        label.gameObject.SetActive(false);
        target = null;
    }
}

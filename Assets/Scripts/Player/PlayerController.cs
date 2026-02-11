using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region References
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform cameraHolder;
    #endregion

    [Header("Movement Settings")]
    [SerializeField] bool lookEnabled = true;
    [SerializeField] private float movementSpeed = 5f;
    private Vector2 movementInput;

    [Header("Look Settings")]
    [SerializeField] bool moveEnabled = true;
    [SerializeField] private float lookSensitivityX = 2f;
    [SerializeField] private float lookSensitivityY = 2f;
    private Vector2 lookInput;

    private void Start()
    {
        #region Setup Inputs
        if (inputManager == null)
        {
            inputManager = GetComponentInChildren<InputManager>();
            Input input = new Input();
            input.Player.Enable();
            input.Player.SetCallbacks(inputManager);
            if (inputManager != null)
            {
                inputManager.MoveInputEvent += OnMoveInput;
                inputManager.LookInputEvent += OnLookInput;
            }
            else
            {
                Debug.LogError("Input Manager not found in children.");
            }
        }
        #endregion
    }

    private void OnMoveInput(Vector2 input)
    {
        if (!moveEnabled) return;
        movementInput = input;
    }

    private void OnLookInput(Vector2 input)
    {
        if (!lookEnabled) return;
        lookInput = input;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (movementInput == Vector2.zero) return;

        Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
        moveDirection = transform.TransformDirection(moveDirection);
        transform.position += moveDirection * movementSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        HandleLook();
    }

    private void HandleLook()
    {
        float horizontalLook = lookInput.x * lookSensitivityX * Time.deltaTime;
        float verticalLook = lookInput.y * lookSensitivityY * Time.deltaTime;

        transform.Rotate(Vector3.up * horizontalLook);
        Vector3 angles = cameraHolder.localEulerAngles;
        float newRotX = angles.x - verticalLook;
        newRotX = (newRotX > 180) ? newRotX - 360 : newRotX;
        newRotX = Mathf.Clamp(newRotX, -60f, 60f);

        cameraHolder.localEulerAngles = new Vector3(newRotX, 0f, 0f);
    }
}

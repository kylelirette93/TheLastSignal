using UnityEngine;
using UnityEngine.InputSystem;

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
    [SerializeField] private float lookSmoothTime = 0.05f;
    private Vector2 lookInput;
    private Vector2 currentLook;
    private Vector2 lookVelocity;
    private float yaw;
    private float pitch;

    private Rigidbody rb;

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

        #region References
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody component not found on PlayerController.");
            }
        }
        #endregion
        if (Gamepad.current != null)
        {
            lookSensitivityX *= 10f;
            lookSensitivityY *= 10f;
        }
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

    private void FixedUpdate()
    {
        HandleMovement();
    }

    public void ToggleMovement(bool canMove)
    {
        moveEnabled = canMove;
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
        moveDirection = transform.TransformDirection(moveDirection);
        rb.MovePosition(rb.position + moveDirection * movementSpeed * Time.fixedDeltaTime);
        //transform.position += moveDirection * movementSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        HandleLook();
    }

    private void HandleLook()
    {
        currentLook = Vector2.SmoothDamp(
        currentLook,
        lookInput,
        ref lookVelocity,
        lookSmoothTime
    );
        yaw += currentLook.x * lookSensitivityX * Time.deltaTime;
        pitch -= currentLook.y * lookSensitivityY * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, -60f, 60f);

        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
        cameraHolder.localEulerAngles = new Vector3(pitch, 0f, 0f);
    }
}

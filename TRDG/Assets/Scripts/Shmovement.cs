using UnityEngine;
using UnityEngine.InputSystem;

public class Shmovement : MonoBehaviour
{
    public float playerSpeed = 6;
    public float lateralPlayerSpeed = 4;
    public float jumpForce = 5f;


    private PlayerControls controls; // Reference to the Input Action asset
    private Vector2 movementInput;
    private Rigidbody rb;

    private void Awake()
    {
        // Initialize and enable the controls
        controls = new PlayerControls();
        controls.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => movementInput = Vector2.zero;
        controls.Player.Jump.performed += ctx => Jump();
    }

    private void OnEnable()
    {
        // Enable the controls when the object is active
        controls.Enable();
    }

    private void OnDisable()
    {
        // Disable the controls when the object is inactive
        controls.Disable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Forward movement
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        // Lateral movement
        if (movementInput.x < 0) // Left
        {
            transform.Translate(Vector3.left * Time.deltaTime * lateralPlayerSpeed, Space.World);
        }
        if (movementInput.x > 0) // Right
        {
            transform.Translate(Vector3.right * Time.deltaTime * lateralPlayerSpeed, Space.World);
        }
    }

    private void Jump()
    {
        if(rb != null && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

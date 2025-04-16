using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterControllerFPS : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 6.5f;
    public float jumpForce = 10f; // Increased jump force for better height
    public float gravityScale = 1.5f; // Lowered gravity so jump lasts longer

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 2f;
    private Transform playerCamera;

    private Rigidbody rb;
    private bool isGrounded;
    private float cameraPitch = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        // Automatically find and assign the Main Camera
        if (Camera.main != null)
        {
            playerCamera = Camera.main.transform;
        }
        else
        {
            UnityEngine.Debug.LogError("No Main Camera found in the scene.");
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleMouseLook();
        HandleMovement();
        ApplyCustomGravity();
    }

    private void HandleMouseLook()
    {
        if (playerCamera == null) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -75f, 75f);
        playerCamera.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.linearVelocity = new Vector3(move.x * moveSpeed, rb.linearVelocity.y, move.z * moveSpeed);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // Reset Y velocity before jumping
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange); // More natural jump force
        }
    }

    private void ApplyCustomGravity()
    {
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * gravityScale * 9.81f, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

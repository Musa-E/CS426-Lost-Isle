using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterControllerFPS : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 6f;
    public float jumpForce = 10f; // Increased jump force for better height
    public float gravityScale = 0.4f; // Lowered gravity so jump lasts longer

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 2f;
    private Transform playerCamera;

    private Rigidbody rb;
    private bool isGrounded;
    private float cameraPitch = 0f;

    // References the oxygen manager's properties
    private OxygenCounter oxygenCounter;

    public int O2Tank_refill_Amount = 10;

    public AudioClip oxygen_Refill_Sound;


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

        GameObject oxygenManager = GameObject.Find("OxygenLevelManager");
        if (oxygenManager != null)
        {
            oxygenCounter = oxygenManager.GetComponent<OxygenCounter>();
            if (oxygenCounter == null)
                Debug.LogError("OxygenCounter script not found on OxygenLevelManager.");
        }
        else
        {
            Debug.LogError("OxygenLevelManager GameObject not found in the scene.");
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

        if (collision.gameObject.CompareTag("OxygenTank"))
        {
            Debug.Log("COLLISION WITH O2 TANK");
    
            // Handle updating values when contacting O2 tank
            handleO2Collisions();

            if (oxygen_Refill_Sound != null) {
                // AudioSource audio = GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(oxygen_Refill_Sound, collision.transform.position);
            }

            // Destroy the oxygen tank after pickup
            Destroy(collision.gameObject);

            /*
                Found an issue:
                If the amount the player gets back from an O2 tank is still below the critical amount,
                another O2 tank will not spawn.  This means the player only gets one O2 tank, and no more.
            */
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void handleO2Collisions() {
        
        if (oxygenCounter != null) {
            oxygenCounter.oxygenLevel += O2Tank_refill_Amount;

            if (oxygenCounter.oxygenLevel > 100)
                oxygenCounter.oxygenLevel = 100;

            oxygenCounter.setOxygen(oxygenCounter.oxygenLevel);
            // Since oxygenCounter.UpdateOxygenLevelText() is private, make sure to expose it if needed
            // oxygenCounter.UpdateOxygenLevelText(oxygenCounter.oxygenLevel); ← only if you make it public
        }
        else
        {
            Debug.LogWarning("oxygenCounter reference not set.");
        }
    }
}

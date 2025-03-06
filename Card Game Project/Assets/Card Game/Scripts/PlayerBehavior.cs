using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody myRigidbody;
    private Vector3 moveInput;
    private Transform body;
    private Transform cameraTransform;
    private bool isGrounded;

    void Start()
    {
        body = transform.Find("Body");

        if (body == null)
        {
            Debug.LogError("Body object not found! Make sure it's named correctly under Player.");
            return;
        }

        myRigidbody = body.GetComponent<Rigidbody>();

        if (myRigidbody == null)
        {
            Debug.LogError("Rigidbody not found on Body!");
        }

        myRigidbody.freezeRotation = true;
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        moveInput = cameraForward * moveZ + cameraRight * moveX;
        moveInput.Normalize();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (myRigidbody != null)
        {
            Vector3 targetVelocity = moveInput * moveSpeed;
            myRigidbody.velocity = Vector3.Lerp(myRigidbody.velocity, targetVelocity, 0.1f); 
        }
    }


    void Jump()
    {
        myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpForce, myRigidbody.velocity.z);
    }
}

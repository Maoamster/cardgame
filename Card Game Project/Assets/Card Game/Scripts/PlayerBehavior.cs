using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody myRigidbody;
    private Vector3 moveInput;
    private Transform body;
    private Transform cameraTransform;

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
    }

    void FixedUpdate()
    {
        if (myRigidbody != null)
        {
            myRigidbody.MovePosition(myRigidbody.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        }
    }
}

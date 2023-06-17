using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Input();

        SpeedControl();
    }

    private void FixedUpdate()
        => MovePlayer();

    private void Input()
    {
        verticalInput = 0;
        horizontalInput = 0;

        if (UnityEngine.Input.GetKey(KeyBinds.ForwardKey))
            verticalInput = 1;
        else if (UnityEngine.Input.GetKey(KeyBinds.BackwardKey))
            verticalInput = -1;

        if (UnityEngine.Input.GetKey(KeyBinds.LeftKey))
            horizontalInput = -1;
        else if (UnityEngine.Input.GetKey(KeyBinds.RightKey))
            horizontalInput = 1;
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput * 0.1f + orientation.right * horizontalInput * 0.1f;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
using UnityEngine;

public class PlayerMovementNoVr : MonoBehaviour
{

    //Move speed
    public CharacterController controller;
    public float movementSpeed = 5f;

    // Gravity check :v
    private Vector3 velocity;
    float gravity = -9.81f;

    // Jump
    public float jumpHeight = 3f;

    // Ground
    [SerializeField]
    private Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    private void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) { 
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}

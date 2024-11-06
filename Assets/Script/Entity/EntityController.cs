using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;           // Movement speed
    public float jumpHeight = 2f;      // Jump height
    public float gravity = -9.81f;     // Gravity strength

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is grounded using CharacterController's built-in isGrounded property
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = -2f; // Small negative value to keep the player grounded
            }

            // Jumping
            if (Input.GetButtonDown("Jump"))
            {
                // Calculate jump velocity
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calculate jump height
            }
        }

        // Get player input for movement along X and Z axes
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate the movement vector relative to the character's facing direction
        Vector3 move = transform.right * x + transform.forward * z;

        // If pressing down (negative vertical input), don't allow upward movement
        if (z < 0)
        {
            move.y = 0; // Prevent upward movement when pressing down
        }

        // Apply horizontal movement based on input
        controller.Move(move * speed * Time.deltaTime);

        // Apply gravity continuously
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical movement (gravity and jump)
        controller.Move(velocity * Time.deltaTime);

        // Lock Y position to a constant value (e.g., 0)
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, 0, position.y); // Ensure the Y position does not go below 0
        transform.position = position;
    }
}

using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;

public class JumpOnCollision : MonoBehaviour
{
    public float jumpForce = 10.0f;  // Force applied to the player for jumping
    private ExampleCharacterController characterController;

    void Start()
    {
        characterController = GetComponent<ExampleCharacterController>();

        if (characterController == null)
        {
            Debug.LogError("ExampleCharacterController component not found on player.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered with: " + other.gameObject.name);

        // Check if the player entered a jumper trigger
        if (other.CompareTag("Jumper"))
        {
            Debug.Log("Entered Jumper Trigger");

            // Get the current velocity
            Vector3 currentVelocity = characterController.Motor.Velocity;

            // Zero out the vertical component of the velocity
            currentVelocity.y = 0;

            // Apply an upward force to the player
            characterController.Motor.ForceUnground(); // Ensure the character is not grounded
            characterController.AddVelocity(Vector3.up * jumpForce - currentVelocity);
        }
    }
}

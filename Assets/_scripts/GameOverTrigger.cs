using KinematicCharacterController.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    private ExampleCharacterController characterController;

    void Start()
    {
        characterController = GetComponent<ExampleCharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("finish"))
        {
        GameOver();
        }
    }
    private void GameOver()
    {
        Debug.Log("Game Over!");
        // You can add additional game over logic here
        // For example, you might want to:
        // 1. Show a game over screen
        // 2. Play a sound effect
        // 3. Stop the player's movement
        // 4. Save high scores

        // For this example, we'll just reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
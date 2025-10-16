using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // To reload the scene

public class Move : MonoBehaviour
{
    private static float speed = 5f;  // Initial speed
    public static float maxSpeed = 12f;  // Maximum speed limit
    private static float acceleration = 0.05f;  // Slower acceleration for gradual speed increase

    void Update()
    {
        // Gradually increase speed over time, but don't exceed the maximum speed
        if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
        }

        // Move the object progressively faster, but now with capped speed
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for collision with "Destroy" tagged object
        if (other.gameObject.CompareTag("Destroy"))
        {
            Debug.Log($"Destroying {gameObject.name} due to collision with {other.gameObject.name}");
            Destroy(gameObject);
        }
    }

    // Optionally, you can expose the speed and acceleration through a getter if needed
    public static float GetSpeed()
    {
        return speed;
    }

    // Method to reset speed when restarting the game or scene
    public static void ResetSpeed()
    {
        speed = 5f; // Reset to initial value
    }

    // Call this method to reload the scene, for example, when the player presses a restart button
    public void RestartGame()
    {
        ResetSpeed();  // Reset speed
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}




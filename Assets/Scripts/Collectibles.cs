using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Rotation speed for the collectible object
    public float rotationSpeed = 45f;  // Degrees per second

    // This method will be called every frame to rotate the collectible
    private void Update()
    {
        // Rotate the collectible object continuously around the Y-axis (you can adjust the axis as needed)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

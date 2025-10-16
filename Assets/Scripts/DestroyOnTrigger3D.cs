using UnityEngine;

public class DestroyOnTrigger3D : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object we collided with has the "Destroy" tag
        if (other.CompareTag("Destroy"))
        {
            // Destroy this game object (the one carrying this script)
            Destroy(gameObject);
        }
    }
}

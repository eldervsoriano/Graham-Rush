using UnityEngine;

public class MagnetCollectible : MonoBehaviour
{
    public float rotationSpeed = 50f;  // Speed of the rotation

    void Update()
    {
        // Rotate the object
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

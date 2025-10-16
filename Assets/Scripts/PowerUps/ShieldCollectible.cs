using UnityEngine;

public class ShieldCollectible : MonoBehaviour
{
    public float rotationSpeed = 50f;  
    void Update()
    {
        
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);  
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

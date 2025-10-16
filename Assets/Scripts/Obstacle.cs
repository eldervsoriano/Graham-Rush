using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Obstacle collided with: " + other.gameObject.name);

       
        if (other.CompareTag("Shield"))
        {
            Debug.Log("Shield collided with obstacle!");

            
            Destroy(gameObject);
        }
    }
}

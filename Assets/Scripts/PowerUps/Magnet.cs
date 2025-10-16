////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;

////public class Magnet : MonoBehaviour
////{
////    [Header("Magnet Settings")]
////    public float magnetRange = 10f;  // Radius within which the magnet will affect objects
////    public float magnetForce = 5f;  // Force with which to pull objects toward the player
////    public bool isMagnetActive = false;  // Whether the magnet is active or not

////    private Transform playerTransform;  // The player's transform for position reference

////    void Start()
////    {
////        playerTransform = transform; // Assuming this script is on the player object
////    }

////    void Update()
////    {
////        if (isMagnetActive)
////        {
////            AttractGrahamObjects();  // Pull objects with the "Graham" tag toward the player
////        }
////    }

////    void AttractGrahamObjects()
////    {
////        // Find all colliders within the magnet range
////        Collider[] grahamObjects = Physics.OverlapSphere(transform.position, magnetRange);

////        foreach (Collider obj in grahamObjects)
////        {
////            if (obj.CompareTag("Graham"))
////            {
////                // Attract each "Graham" object toward the player
////                Vector3 direction = (transform.position - obj.transform.position).normalized;
////                float distance = Vector3.Distance(transform.position, obj.transform.position);

////                // Move the object toward the player (magnet effect)
////                if (distance > 0.5f) // Don't attract too close objects
////                {
////                    obj.transform.position += direction * magnetForce * Time.deltaTime;
////                }
////            }
////        }
////    }

////    // Optionally, you could use this function to activate/deactivate the magnet.
////    public void ToggleMagnet(bool state)
////    {
////        isMagnetActive = state;
////    }
////}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Magnet : MonoBehaviour
//{
//    [Header("Magnet Settings")]
//    public float magnetRange = 10f;  // Radius within which the magnet will affect objects
//    public float magnetForce = 5f;  // Force with which to pull objects toward the player
//    public bool isMagnetActive = false;  // Whether the magnet is active or not

//    [Header("Duration Settings")]
//    public float magnetDuration = 5f;  // Duration for the magnet to be active
//    public GameObject gameObjectToDeactivate;  // GameObject to deactivate after the duration

//    private Transform playerTransform;  // The player's transform for position reference
//    private float timer = 0f;  // Timer to track duration

//    void Start()
//    {
//        playerTransform = transform; // Assuming this script is on the player object
//    }

//    void Update()
//    {
//        if (isMagnetActive)
//        {
//            AttractGrahamObjects();  // Pull objects with the "Graham" tag toward the player

//            // Timer for deactivating the object after the duration
//            timer += Time.deltaTime;

//            if (timer >= magnetDuration && gameObjectToDeactivate != null)
//            {
//                gameObjectToDeactivate.SetActive(false);  // Deactivate the chosen GameObject
//                isMagnetActive = false;  // Optionally, deactivate the magnet effect as well
//            }
//        }
//    }

//    void AttractGrahamObjects()
//    {
//        // Find all colliders within the magnet range
//        Collider[] grahamObjects = Physics.OverlapSphere(transform.position, magnetRange);

//        foreach (Collider obj in grahamObjects)
//        {
//            if (obj.CompareTag("Graham"))
//            {
//                // Attract each "Graham" object toward the player
//                Vector3 direction = (transform.position - obj.transform.position).normalized;
//                float distance = Vector3.Distance(transform.position, obj.transform.position);

//                // Move the object toward the player (magnet effect)
//                if (distance > 0.5f) // Don't attract too close objects
//                {
//                    obj.transform.position += direction * magnetForce * Time.deltaTime;
//                }
//            }
//        }
//    }

//    // Optionally, you could use this function to activate/deactivate the magnet.
//    public void ToggleMagnet(bool state)
//    {
//        isMagnetActive = state;
//        timer = 0f;  // Reset the timer when magnet is toggled on
//    }
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Magnet : MonoBehaviour
//{
//    [Header("Magnet Settings")]
//    public float magnetRange = 10f;  // Radius within which the magnet will affect objects
//    public float magnetForce = 5f;  // Force with which to pull objects toward the player
//    public bool isMagnetActive = false;  // Whether the magnet is active or not

//    [Header("Duration Settings")]
//    public float magnetDuration = 5f;  // Duration for the magnet to be active
//    public GameObject gameObjectToDeactivate;  // GameObject to deactivate after the duration

//    private Transform playerTransform;  // The player's transform for position reference
//    private float timer = 0f;  // Timer to track duration

//    void Start()
//    {
//        playerTransform = transform; // Assuming this script is on the player object
//    }

//    void Update()
//    {
//        // If the magnet is active, apply the magnet effect and check the timer
//        if (isMagnetActive)
//        {
//            AttractGrahamObjects();  // Pull objects with the "Graham" tag toward the player

//            // Track the time for magnet duration
//            timer += Time.deltaTime;

//            // Deactivate the specified GameObject when the duration is over
//            if (timer >= magnetDuration)
//            {
//                DeactivateGameObject();
//            }
//        }
//    }

//    // Method to handle attraction of "Graham" objects
//    void AttractGrahamObjects()
//    {
//        // Find all colliders within the magnet range
//        Collider[] grahamObjects = Physics.OverlapSphere(transform.position, magnetRange);

//        foreach (Collider obj in grahamObjects)
//        {
//            if (obj.CompareTag("Graham"))
//            {
//                // Attract each "Graham" object toward the player
//                Vector3 direction = (transform.position - obj.transform.position).normalized;
//                float distance = Vector3.Distance(transform.position, obj.transform.position);

//                // Move the object toward the player (magnet effect)
//                if (distance > 0.5f) // Don't attract too close objects
//                {
//                    obj.transform.position += direction * magnetForce * Time.deltaTime;
//                }
//            }
//        }
//    }

//    // Method to deactivate the specified GameObject
//    void DeactivateGameObject()
//    {
//        if (gameObjectToDeactivate != null)
//        {
//            gameObjectToDeactivate.SetActive(false);  // Deactivate the GameObject
//            isMagnetActive = false;  // Optionally deactivate the magnet effect
//        }
//    }

//    // Method to activate or deactivate the magnet effect and reset the timer
//    public void ToggleMagnet(bool state)
//    {
//        isMagnetActive = state;
//        timer = 0f;  // Reset the timer whenever the magnet is toggled on
//    }
//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [Header("Magnet Settings")]
    public float magnetRange = 10f;  
    public float magnetForce = 5f;  
    public bool isMagnetActive = false;  

    private Transform playerTransform;  // The player's transform for position reference

    void Start()
    {
        playerTransform = transform; 
    }

    void Update()
    {
        // If the magnet is active, apply the magnet effect
        if (isMagnetActive)
        {
            AttractGrahamObjects();  // Pull objects with the "Graham" tag toward the player
        }
    }

    
    void AttractGrahamObjects()
    {
       
        Collider[] grahamObjects = Physics.OverlapSphere(transform.position, magnetRange);

        foreach (Collider obj in grahamObjects)
        {
            if (obj.CompareTag("Graham"))
            {
                // Attract each "Graham" 
                Vector3 direction = (transform.position - obj.transform.position).normalized;
                float distance = Vector3.Distance(transform.position, obj.transform.position);

                
                if (distance > 0.5f) // Don't attract close object
                {
                    obj.transform.position += direction * magnetForce * Time.deltaTime;
                }
            }
        }
    }

    // activate or deactivate the magnet effect
    public void ToggleMagnet(bool state)
    {
        isMagnetActive = state;
    }
}

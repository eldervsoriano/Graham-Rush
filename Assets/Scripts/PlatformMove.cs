//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlatformMove : MonoBehaviour
//{
//    public GameObject[] roadSection; // Array of prefabs to instantiate
//    public Vector3 spawnPosition = new Vector3(11, 0, 0); // Adjustable spawn position
//    public Vector3 spawnRotation = Vector3.zero; // Adjustable spawn rotation in degrees
//    bool isInstantiating = false;

//    // Update is called once per frame
//    void Update()
//    {
//        if (!isInstantiating)
//        {
//            // Create a random road section at the specified position and rotation
//            GameObject instance = Instantiate(
//                roadSection[Random.Range(0, roadSection.Length)],
//                spawnPosition,
//                Quaternion.Euler(spawnRotation) // Convert rotation to Quaternion
//            );

//            isInstantiating = true;
//            Invoke("ResetInstantiationFlag", 4.2f);
//        }
//    }

//    void ResetInstantiationFlag()
//    {
//        isInstantiating = false;
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public GameObject[] roadSection; // Array of prefabs to instantiate
    public Vector3 spawnPosition = new Vector3(11, 0, 0); // Adjustable spawn position
    public Vector3 spawnRotation = Vector3.zero; // Adjustable spawn rotation in degrees
    bool isInstantiating = false;

    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !isInstantiating)
        {
            
            GameObject instance = Instantiate(
                roadSection[Random.Range(0, roadSection.Length)],
                spawnPosition,
                Quaternion.Euler(spawnRotation) 
            );

            isInstantiating = true;
            
            Invoke("ResetInstantiationFlag", 4.2f);
        }
    }

    void ResetInstantiationFlag()
    {
        isInstantiating = false;
    }
}

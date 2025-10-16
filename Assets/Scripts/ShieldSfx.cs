using UnityEngine;

public class ShieldSfx : MonoBehaviour
{
    public AudioClip shieldSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            audioSource.PlayOneShot(shieldSound);
        }
    }
}

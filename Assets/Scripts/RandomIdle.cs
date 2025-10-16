using UnityEngine;

public class RandomIdle : MonoBehaviour
{
    private Animator animator;
    private float idleTimer = 0f;
    public float idleDuration = 3f;  

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       
        idleTimer += Time.deltaTime;

        
        if (idleTimer >= idleDuration)
        {
            SetRandomIdleAnimation();
            idleTimer = 0f;  
        }
    }

    void SetRandomIdleAnimation()
    {
        
        int randomIdle = Random.Range(1, 4);
        animator.SetInteger("IdleAnimationChoice", randomIdle);
    }
}

//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class PlayerController : MonoBehaviour
//{
//    private Vector2 startTouchPosition, endTouchPosition; // Touch positions
//    private Rigidbody rb; // Reference to Rigidbody

//    [Header("Movement Settings")]
//    public float jumpForce = 5f; // Jump force
//    public float slideDuration = 1f; // Duration of slide
//    public Vector3 slideScale = new Vector3(1, 0.5f, 1); // Scale during slide
//    public float fastFallMultiplier = 2f; // Multiplier for falling faster during mid-air slide

//    private Vector3 originalScale; // Original scale of the player
//    private bool isSliding = false;
//    private bool isGrounded = false; // Ground check using Raycast
//    public Animator animator; // Reference to Animator component

//    [Header("Score Settings")]
//    public int score = 0; // Player's score
//    public TMP_Text scoreText;

//    [Header("Game Over Settings")]
//    public GameObject gameOverPanel; // Reference to Game Over panel
//    public TMP_Text currentScoreText; // Text for current score on game over panel
//    public TMP_Text highScoreText; // Text for high score on game over panel

//    [Header("Audio Settings")]
//    public AudioSource collectSFX; // Sound effect for collecting "Graham"

//    [Header("Magnet Settings")]
//    public GameObject magnet; // Reference to Magnet game object
//    public float magnetDuration = 5f; // Duration for which magnet will be active
//    private bool isMagnetActive = false; // Track if magnet is active
//    private Coroutine magnetCoroutine; // Store the running coroutine for magnet effect

//    [Header("Shield Settings")]
//    public GameObject shield; // Reference to Shield game object
//    public float shieldDuration = 5f; // Duration for which shield will be active
//    private bool isShieldActive = false; // Track if shield is active
//    private Coroutine shieldCoroutine; // Store the running coroutine for shield effect

//    [Header("Magnet/Shield Duration UI")]
//    public Image magnetDurationIcon;  // Reference to the image representing the magnet's duration
//    public Image shieldDurationIcon;  // Reference to the image representing the shield's duration

//    private const string HighScoreKey = "HighScore"; // Key for storing high score in PlayerPrefs

//    void Start()
//    {
//        Application.targetFrameRate = 120;
//        rb = GetComponent<Rigidbody>();
//        originalScale = transform.localScale;
//        animator = GetComponent<Animator>();
//        UpdateScoreDisplay();


//        highScoreText.text = GetHighScore().ToString();
//    }

//    void Update()
//    {

//        CheckGrounded();


//        HandleSwipe();
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Graham"))
//        {
//            CollectGraham(other);
//        }
//        else if (other.CompareTag("Obstacle"))
//        {
//            if (isShieldActive) //shield is active?
//            {

//            }
//            else
//            {
//                GameOver();
//                Destroy(gameObject);
//            }
//        }
//        else if (other.CompareTag("Magnet"))
//        {
//            CollectMagnet(other); // Handle collecting the magnet
//        }
//        else if (other.CompareTag("Shield"))
//        {
//            CollectShield(other); // Handle collecting the shield
//        }
//    }

//    void CollectGraham(Collider graham)
//    {
//        score++;
//        UpdateScoreDisplay();

//        // Play the sound effect when collecting Graham
//        if (collectSFX != null)
//        {
//            collectSFX.Play(); // Play collection sound
//        }

//        Destroy(graham.gameObject); // Remove the collected item from the scene
//    }

//    void CollectMagnet(Collider magnetObject)
//    {
//        // If the magnet is already active, reset the duration
//        if (isMagnetActive)
//        {
//            if (magnetCoroutine != null)
//            {
//                StopCoroutine(magnetCoroutine); // Stop the previous coroutine
//            }
//        }

//        isMagnetActive = true;  // Activate the magnet effect
//        magnet.SetActive(true); // Activate the magnet object

//        // Start a new coroutine to manage the magnet duration
//        magnetCoroutine = StartCoroutine(DeactivateMagnetAfterDuration());

//        // Reset and update the magnet duration UI
//        if (magnetDurationIcon != null)
//        {
//            magnetDurationIcon.fillAmount = 1f; // Fill the icon initially
//        }

//        Destroy(magnetObject.gameObject); // Destroy the collected magnet object
//    }

//    void CollectShield(Collider shieldObject)
//    {
//        // If the shield is already active, reset the duration
//        if (isShieldActive)
//        {
//            if (shieldCoroutine != null)
//            {
//                StopCoroutine(shieldCoroutine); // Stop the previous coroutine
//            }
//        }

//        isShieldActive = true;  // Activate the shield effect
//        shield.SetActive(true); // Activate the shield object

//        //  manage the shield duration
//        shieldCoroutine = StartCoroutine(DeactivateShieldAfterDuration());

//        // Reset and update the shield duration ui
//        if (shieldDurationIcon != null)
//        {
//            shieldDurationIcon.fillAmount = 1f; // Fill the icon initially
//        }

//        Destroy(shieldObject.gameObject); // Destroy the collected shield object
//    }

//    IEnumerator DeactivateMagnetAfterDuration()
//    {
//        float timeElapsed = 0f;

//        while (timeElapsed < magnetDuration)
//        {
//            timeElapsed += Time.deltaTime; // Increase time elapsed

//            // Update the magnet duration UI
//            if (magnetDurationIcon != null)
//            {
//                magnetDurationIcon.fillAmount = 1 - (timeElapsed / magnetDuration); // Update the fill amount
//            }

//            yield return null; // Wait for the next frame
//        }

//        // After the duration, deactivate the magnet effect
//        magnet.SetActive(false); // Deactivate the magnet
//        isMagnetActive = false; // Reset the magnet state

//        // Optionally reset the icon to empty after the magnet effect ends
//        if (magnetDurationIcon != null)
//        {
//            magnetDurationIcon.fillAmount = 0f;
//        }
//    }

//    IEnumerator DeactivateShieldAfterDuration()
//    {
//        float timeElapsed = 0f;

//        while (timeElapsed < shieldDuration)
//        {
//            timeElapsed += Time.deltaTime; // Increase time elapsed

//            // Update the shield duration UI
//            if (shieldDurationIcon != null)
//            {
//                shieldDurationIcon.fillAmount = 1 - (timeElapsed / shieldDuration); // Update the fill amount
//            }

//            yield return null; // Wait for the next frame
//        }

//        // After the duration, deactivate the shield effect
//        shield.SetActive(false); // Deactivate the shield
//        isShieldActive = false; // Reset the shield state

//        // Optionally reset the icon to empty after the shield effect ends
//        if (shieldDurationIcon != null)
//        {
//            shieldDurationIcon.fillAmount = 0f;
//        }
//    }

//    void UpdateScoreDisplay()
//    {
//        if (scoreText != null)
//        {
//            scoreText.text = "Score: " + score.ToString(); // Update score display
//        }
//    }

//    void HandleSwipe()
//    {
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);

//            if (touch.phase == TouchPhase.Began)
//            {
//                startTouchPosition = touch.position;
//            }
//            else if (touch.phase == TouchPhase.Ended)
//            {
//                endTouchPosition = touch.position;

//                Vector2 swipeDelta = endTouchPosition - startTouchPosition;

//                // Check if the swipe is vertical
//                if (Mathf.Abs(swipeDelta.y) > Mathf.Abs(swipeDelta.x))
//                {
//                    if (swipeDelta.y > 0) // Swipe Up
//                    {
//                        Jump();
//                    }
//                    else if (swipeDelta.y < 0) // Swipe Down
//                    {
//                        Slide();
//                    }
//                }
//            }
//        }
//    }

//    void Jump()
//    {
//        if (!isGrounded) return; // Prevent jumping if not grounded

//        if (isSliding)
//        {
//            StopCoroutine(SlideRoutine());
//            transform.localScale = originalScale; // Reset scale immediately
//            isSliding = false;
//        }

//        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity
//        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply jump force
//        animator.SetTrigger("Jump");
//        isGrounded = false; // Set to false, player is now in air
//    }

//    void Slide()
//    {
//        if (isSliding) return; // Prevent multiple slides

//        if (!isGrounded) // If mid-air
//        {
//            rb.velocity = new Vector3(rb.velocity.x, -Mathf.Abs(rb.velocity.y) * fastFallMultiplier, rb.velocity.z); // Faster fall during slide
//        }

//        StartCoroutine(SlideRoutine()); // Start the sliding process
//    }

//    IEnumerator SlideRoutine()
//    {
//        isSliding = true;
//        animator.SetBool("IsSliding", true); // Trigger the slide animation
//        yield return new WaitForSeconds(slideDuration); // Wait for the slide duration
//        animator.SetBool("IsSliding", false); // Stop the slide animation
//        isSliding = false; // End the slide state
//    }

//    void CheckGrounded()
//    {
//        RaycastHit hit;
//        if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit, 1f))  // Added offset to the raycast
//        {
//            if (hit.collider.CompareTag("Ground"))
//            {
//                isGrounded = true;
//            }
//        }
//        else
//        {
//            isGrounded = false;
//        }
//    }

//    void GameOver()
//    {
//        Time.timeScale = 0; // Pause the game

//        // Update high score if needed
//        int highScore = GetHighScore();
//        if (score > highScore)
//        {
//            SaveHighScore(score); // Save the new high score
//        }

//        // Show the Game Over panel
//        if (gameOverPanel != null)
//        {
//            gameOverPanel.SetActive(true);

//            // Update the current score and high score text on the game over panel
//            if (currentScoreText != null)
//                currentScoreText.text = score.ToString();

//            if (highScoreText != null)
//                highScoreText.text = GetHighScore().ToString();
//        }
//    }

//    void SaveHighScore(int newHighScore)
//    {
//        PlayerPrefs.SetInt(HighScoreKey, newHighScore);
//    }

//    int GetHighScore()
//    {
//        return PlayerPrefs.GetInt(HighScoreKey, 0);
//    }


//}









using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition; // Touch positions
    private Rigidbody rb; // Reference to Rigidbody

    [Header("Movement Settings")]
    public float jumpForce = 5f; // Jump force
    public float slideDuration = 1f; // Duration of slide
    public Vector3 slideScale = new Vector3(1, 0.5f, 1); // Scale during slide
    public float fastFallMultiplier = 2f; // Multiplier for falling faster during mid-air slide

    private Vector3 originalScale; // Original scale of the player
    private bool isSliding = false;
    private bool isGrounded = false; // Ground check using Raycast
    private bool wasGrounded = false; // Track previous ground state for landing detection
    public Animator animator; // Reference to Animator component

    [Header("Score Settings")]
    public int score = 0; // Player's score
    public TMP_Text scoreText;

    [Header("Game Over Settings")]
    public GameObject gameOverPanel; // Reference to Game Over panel
    public TMP_Text currentScoreText; // Text for current score on game over panel
    public TMP_Text highScoreText; // Text for high score on game over panel

    [Header("Audio Settings")]
    public AudioSource collectSFX; // Sound effect for collecting "Graham"

    [Header("Magnet Settings")]
    public GameObject magnet; // Reference to Magnet game object
    public float magnetDuration = 5f; // Duration for which magnet will be active
    private bool isMagnetActive = false; // Track if magnet is active
    private Coroutine magnetCoroutine; // Store the running coroutine for magnet effect

    [Header("Shield Settings")]
    public GameObject shield; // Reference to Shield game object
    public float shieldDuration = 5f; // Duration for which shield will be active
    private bool isShieldActive = false; // Track if shield is active
    private Coroutine shieldCoroutine; // Store the running coroutine for shield effect

    [Header("Magnet/Shield Duration UI")]
    public Image magnetDurationIcon;  // Reference to the image representing the magnet's duration
    public Image shieldDurationIcon;  // Reference to the image representing the shield's duration

    private const string HighScoreKey = "HighScore"; // Key for storing high score in PlayerPrefs

    void Start()
    {
        Application.targetFrameRate = 120;
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale;
        animator = GetComponent<Animator>();
        UpdateScoreDisplay();

        highScoreText.text = GetHighScore().ToString();
    }

    void Update()
    {
        CheckGrounded();
        HandleSwipe();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Graham"))
        {
            CollectGraham(other);
        }
        else if (other.CompareTag("Obstacle"))
        {
            if (isShieldActive) //shield is active?
            {

            }
            else
            {
                GameOver();
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("Magnet"))
        {
            CollectMagnet(other); // Handle collecting the magnet
        }
        else if (other.CompareTag("Shield"))
        {
            CollectShield(other); // Handle collecting the shield
        }
    }

    void CollectGraham(Collider graham)
    {
        score++;
        UpdateScoreDisplay();

        // Play the sound effect when collecting Graham
        if (collectSFX != null)
        {
            collectSFX.Play(); // Play collection sound
        }

        Destroy(graham.gameObject); // Remove the collected item from the scene
    }

    void CollectMagnet(Collider magnetObject)
    {
        // If the magnet is already active, reset the duration
        if (isMagnetActive)
        {
            if (magnetCoroutine != null)
            {
                StopCoroutine(magnetCoroutine); // Stop the previous coroutine
            }
        }

        isMagnetActive = true;  // Activate the magnet effect
        magnet.SetActive(true); // Activate the magnet object

        // Start a new coroutine to manage the magnet duration
        magnetCoroutine = StartCoroutine(DeactivateMagnetAfterDuration());

        // Reset and update the magnet duration UI
        if (magnetDurationIcon != null)
        {
            magnetDurationIcon.fillAmount = 1f; // Fill the icon initially
        }

        Destroy(magnetObject.gameObject); // Destroy the collected magnet object
    }

    void CollectShield(Collider shieldObject)
    {
        // If the shield is already active, reset the duration
        if (isShieldActive)
        {
            if (shieldCoroutine != null)
            {
                StopCoroutine(shieldCoroutine); // Stop the previous coroutine
            }
        }

        isShieldActive = true;  // Activate the shield effect
        shield.SetActive(true); // Activate the shield object

        //  manage the shield duration
        shieldCoroutine = StartCoroutine(DeactivateShieldAfterDuration());

        // Reset and update the shield duration ui
        if (shieldDurationIcon != null)
        {
            shieldDurationIcon.fillAmount = 1f; // Fill the icon initially
        }

        Destroy(shieldObject.gameObject); // Destroy the collected shield object
    }

    IEnumerator DeactivateMagnetAfterDuration()
    {
        float timeElapsed = 0f;

        while (timeElapsed < magnetDuration)
        {
            timeElapsed += Time.deltaTime; // Increase time elapsed

            // Update the magnet duration UI
            if (magnetDurationIcon != null)
            {
                magnetDurationIcon.fillAmount = 1 - (timeElapsed / magnetDuration); // Update the fill amount
            }

            yield return null; // Wait for the next frame
        }

        // After the duration, deactivate the magnet effect
        magnet.SetActive(false); // Deactivate the magnet
        isMagnetActive = false; // Reset the magnet state

        // Optionally reset the icon to empty after the magnet effect ends
        if (magnetDurationIcon != null)
        {
            magnetDurationIcon.fillAmount = 0f;
        }
    }

    IEnumerator DeactivateShieldAfterDuration()
    {
        float timeElapsed = 0f;

        while (timeElapsed < shieldDuration)
        {
            timeElapsed += Time.deltaTime; // Increase time elapsed

            // Update the shield duration UI
            if (shieldDurationIcon != null)
            {
                shieldDurationIcon.fillAmount = 1 - (timeElapsed / shieldDuration); // Update the fill amount
            }

            yield return null; // Wait for the next frame
        }

        // After the duration, deactivate the shield effect
        shield.SetActive(false); // Deactivate the shield
        isShieldActive = false; // Reset the shield state

        // Optionally reset the icon to empty after the shield effect ends
        if (shieldDurationIcon != null)
        {
            shieldDurationIcon.fillAmount = 0f;
        }
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update score display
        }
    }

    void HandleSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;

                Vector2 swipeDelta = endTouchPosition - startTouchPosition;

                // Check if the swipe is vertical
                if (Mathf.Abs(swipeDelta.y) > Mathf.Abs(swipeDelta.x))
                {
                    if (swipeDelta.y > 0) // Swipe Up
                    {
                        Jump();
                    }
                    else if (swipeDelta.y < 0) // Swipe Down
                    {
                        Slide();
                    }
                }
            }
        }
    }

    void Jump()
    {
        if (!isGrounded) return; // Prevent jumping if not grounded

        if (isSliding)
        {
            StopCoroutine(SlideRoutine());
            transform.localScale = originalScale; // Reset scale immediately
            isSliding = false;
        }

        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply jump force
        animator.SetTrigger("Jump");
        isGrounded = false; // Set to false, player is now in air
    }

    void Slide()
    {
        if (isSliding) return; // Prevent multiple slides

        if (!isGrounded) // If mid-air
        {
            rb.velocity = new Vector3(rb.velocity.x, -Mathf.Abs(rb.velocity.y) * fastFallMultiplier, rb.velocity.z); // Faster fall during slide
        }

        StartCoroutine(SlideRoutine()); // Start the sliding process
    }

    IEnumerator SlideRoutine()
    {
        isSliding = true;
        animator.SetBool("IsSliding", true); // Trigger the slide animation
        yield return new WaitForSeconds(slideDuration); // Wait for the slide duration
        animator.SetBool("IsSliding", false); // Stop the slide animation
        isSliding = false; // End the slide state
    }

    void CheckGrounded()
    {
        // Store previous ground state
        wasGrounded = isGrounded;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit, 1f))  // Added offset to the raycast
        {
            if (hit.collider.CompareTag("Ground"))
            {
                isGrounded = true;

                // Trigger landing animation when transitioning from air to ground
                if (!wasGrounded && isGrounded && !isSliding)
                {
                    animator.SetTrigger("Landing");
                }
            }
        }
        else
        {
            isGrounded = false;
        }
    }

    void GameOver()
    {
        Time.timeScale = 0; // Pause the game

        // Update high score if needed
        int highScore = GetHighScore();
        if (score > highScore)
        {
            SaveHighScore(score); // Save the new high score
        }

        // Show the Game Over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            // Update the current score and high score text on the game over panel
            if (currentScoreText != null)
                currentScoreText.text = score.ToString();

            if (highScoreText != null)
                highScoreText.text = GetHighScore().ToString();
        }
    }

    void SaveHighScore(int newHighScore)
    {
        PlayerPrefs.SetInt(HighScoreKey, newHighScore);
    }

    int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }
}
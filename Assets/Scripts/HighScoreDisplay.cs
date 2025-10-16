using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TMP_Text highScoreText; // Reference to the TextMeshPro text

    void Start()
    {
        // Get the high score from PlayerPrefs and display it
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = highScore.ToString();
        }
    }
}

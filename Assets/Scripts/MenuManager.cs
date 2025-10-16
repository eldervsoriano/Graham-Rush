//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement; // For restarting the game and exiting

//public class MenuManager : MonoBehaviour
//{
//    public GameObject menuPanel;
//    public GameObject tutorialPanel;
//    public GameObject settingsPanel;
//    public GameObject quitConfirmationPanel;
//    public GameObject aboutPanel;

//    private Stack<GameObject> panelStack = new Stack<GameObject>();

//    // Opens the specified panel
//    public void OpenPanel(GameObject panel)
//    {
//        if (panel == null) return;

//        // Push the current panel onto the stack (if it exists)
//        if (panelStack.Count > 0)
//        {
//            GameObject currentPanel = panelStack.Peek();
//            if (currentPanel != panel)
//            {
//                currentPanel.SetActive(false);
//            }
//        }

//        // Activate the new panel and add it to the stack
//        panel.SetActive(true);
//        panelStack.Push(panel);
//    }

//    // Closes the current panel
//    public void CloseCurrentPanel()
//    {
//        if (panelStack.Count == 0) return;

//        // Deactivate the current panel
//        GameObject currentPanel = panelStack.Pop();
//        currentPanel.SetActive(false);

//        // Reactivate the previous panel (if it exists)
//        if (panelStack.Count > 0)
//        {
//            GameObject previousPanel = panelStack.Peek();
//            previousPanel.SetActive(true);
//        }
//    }

//    // Button methods
//    public void OnMenuButton() => OpenPanel(menuPanel);
//    public void OnTutorialButton() => OpenPanel(tutorialPanel);
//    public void OnSettingsButton() => OpenPanel(settingsPanel);
//    public void OnQuitButton() => OpenPanel(quitConfirmationPanel);
//    public void OnAboutButton() => OpenPanel(aboutPanel);
//    public void OnBackButton() => CloseCurrentPanel();

//    // Restart the game
//    public void OnRestartButton()
//    {
//        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//    }

//    // Exit the game
//    public void OnExitButton()
//    {
//        Application.Quit();
//    }
//}


//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class MenuManager : MonoBehaviour
//{
//    public GameObject menuPanel;
//    public GameObject tutorialPanel;
//    public GameObject settingsPanel;
//    public GameObject quitConfirmationPanel;
//    public GameObject aboutPanel;
//    public GameObject pausePanel; // Added for resuming functionality

//    private Stack<GameObject> panelStack = new Stack<GameObject>();
//    private bool isGamePaused = false;

//    // Opens the specified panel
//    public void OpenPanel(GameObject panel)
//    {
//        if (panel == null) return;

//        // Push the current panel onto the stack (if it exists)
//        if (panelStack.Count > 0)
//        {
//            GameObject currentPanel = panelStack.Peek();
//            if (currentPanel != panel)
//            {
//                currentPanel.SetActive(false);
//            }
//        }

//        // Activate the new panel and add it to the stack
//        panel.SetActive(true);
//        panelStack.Push(panel);

//        // Pause the game only if the menu or tutorial panel is opened
//        if (panel == menuPanel || panel == tutorialPanel)
//        {
//            PauseGame();
//        }
//    }

//    // Closes the current panel
//    public void CloseCurrentPanel()
//    {
//        if (panelStack.Count == 0) return;

//        // Deactivate the current panel
//        GameObject currentPanel = panelStack.Pop();
//        currentPanel.SetActive(false);

//        // Reactivate the previous panel (if it exists)
//        if (panelStack.Count > 0)
//        {
//            GameObject previousPanel = panelStack.Peek();
//            previousPanel.SetActive(true);
//        }
//        else
//        {
//            ResumeGame(); // Resume the game if no panels are active
//        }
//    }

//    // Button methods
//    public void OnMenuButton() => OpenPanel(menuPanel);
//    public void OnTutorialButton() => OpenPanel(tutorialPanel);
//    public void OnSettingsButton() => OpenPanel(settingsPanel);
//    public void OnQuitButton() => OpenPanel(quitConfirmationPanel);
//    public void OnAboutButton() => OpenPanel(aboutPanel);
//    public void OnBackButton() => CloseCurrentPanel();
//    public void OnResumeButton() // New method for resuming the game
//    {
//        if (panelStack.Count > 0)
//        {
//            CloseCurrentPanel();
//        }
//    }

//    // Restart the game
//    public void OnRestartButton()
//    {
//        CloseCurrentPanel();
//        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//        ResumeGame(); // Ensure the game is resumed upon restart

//    }

//    // Exit the game
//    public void OnExitButton()
//    {
//        Application.Quit();
//    }

//    // Change scene
//    public void OnChangeScene(string sceneName)
//    {
//        SceneManager.LoadScene(sceneName);
//    }

//    // Pause the game
//    private void PauseGame()
//    {
//        if (!isGamePaused)
//        {
//            Time.timeScale = 0f;
//            isGamePaused = true;
//        }
//    }

//    // Resume the game
//    private void ResumeGame()
//    {
//        if (isGamePaused)
//        {
//            Time.timeScale = 1f;
//            isGamePaused = false;
//        }
//    }

//}


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject tutorialPanel;
    public GameObject settingsPanel;
    public GameObject quitConfirmationPanel;
    public GameObject aboutPanel;
    public GameObject pausePanel; // Added for resuming functionality
    public GameObject gameOverPanel; // New panel for game over state
    public GameObject highScorePanel; 

    private Stack<GameObject> panelStack = new Stack<GameObject>();
    private bool isGamePaused = false;

    // Opens the specified panel
    public void OpenPanel(GameObject panel)
    {
        if (panel == null) return;

        // Push the current panel onto the stack (if it exists)
        if (panelStack.Count > 0)
        {
            GameObject currentPanel = panelStack.Peek();
            if (currentPanel != panel)
            {
                currentPanel.SetActive(false);
            }
        }

        // Activate the new panel and add it to the stack
        panel.SetActive(true);
        panelStack.Push(panel);

        // Pause the game only if the menu or tutorial panel is opened
        if (panel == menuPanel || panel == tutorialPanel || panel == gameOverPanel)
        {
            PauseGame();
        }
    }

    // Closes the current panel
    public void CloseCurrentPanel()
    {
        if (panelStack.Count == 0) return;

        // Deactivate the current panel
        GameObject currentPanel = panelStack.Pop();
        currentPanel.SetActive(false);

        // Reactivate the previous panel (if it exists)
        if (panelStack.Count > 0)
        {
            GameObject previousPanel = panelStack.Peek();
            previousPanel.SetActive(true);
        }
        else
        {
            ResumeGame(); // Resume the game if no panels are active
        }
    }

    // Method to show the "Game Over" panel when the player dies
    public void ShowGameOverPanel()
    {
        OpenPanel(gameOverPanel);
    }

    // Button methods
    public void OnMenuButton() => OpenPanel(menuPanel);
    public void OnTutorialButton() => OpenPanel(tutorialPanel);
    public void OnSettingsButton() => OpenPanel(settingsPanel);
    public void OnScoreButton() => OpenPanel(highScorePanel);
    public void OnQuitButton() => OpenPanel(quitConfirmationPanel);
    public void OnAboutButton() => OpenPanel(aboutPanel);
    public void OnBackButton() => CloseCurrentPanel();
    public void OnResumeButton()
    {
        if (panelStack.Count > 0)
        {
            CloseCurrentPanel();
        }
    }

    // Restart the game
    //public void OnRestartButton()
    //{
    //    CloseCurrentPanel();
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    ResumeGame(); // Ensure the game is resumed upon restart
    //}

    //public void OnRestartButton()
    //{
    //    // Close the current panel (Game Over panel)
    //    CloseCurrentPanel();

    //    // Ensure that timeScale is set to 1 before restarting the scene
    //    Time.timeScale = 1f;

    //    // Reload the current scene
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    public void OnRestartButton()
    {
        
        CloseCurrentPanel();

        // reset before restarting
        Move.ResetSpeed(); // Reset the speed

        Time.timeScale = 1f;

       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    
    public void OnExitButton()
    {
        Application.Quit();
    }

    
    public void OnChangeScene(string sceneName)
    {
        Time.timeScale = 1f;
        Move.ResetSpeed();
        SceneManager.LoadScene(sceneName);
    }

    
    private void PauseGame()
    {
        if (!isGamePaused)
        {
            Time.timeScale = 0f;
            isGamePaused = true;
        }
    }


    private void ResumeGame()
    {
        if (isGamePaused)
        {
            Time.timeScale = 1f;
            isGamePaused = false;
        }
    }
}



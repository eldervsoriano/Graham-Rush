using UnityEngine;
using UnityEngine.UI;  // Required for working with UI components

public class ForTutorialPanel : MonoBehaviour
{
    // Reference to the UI Panel
    public GameObject tutorialPanel;

    // References to the Open and Close Buttons
    public Button openPanelButton;
    public Button closePanelButton;

    void Start()
    {
        // Ensure the panel is inactive at the start
        tutorialPanel.SetActive(false);

        // Add listeners to buttons for opening and closing the panel
        openPanelButton.onClick.AddListener(OpenPanel);
        closePanelButton.onClick.AddListener(ClosePanel);
    }

    // Method to open the panel
    void OpenPanel()
    {
        tutorialPanel.SetActive(true);  // Activates the panel when the open button is clicked
    }

    // Method to close the panel
    void ClosePanel()
    {
        tutorialPanel.SetActive(false);  // Deactivates the panel when the close button is clicked
    }
}

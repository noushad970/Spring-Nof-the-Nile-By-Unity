using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject confirmationPanelRestart;
    public GameObject confirmationPanelMenu;
    public Button pauseButton;
    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;
    public Button yesButtonRestart;
    public Button noButtonRestart;
    public Button yesButtonMainMenu;
    public Button noButtonMainMenu;

   

    private void Start()
    {
        pauseMenuPanel.SetActive(false);
        confirmationPanelRestart.SetActive(false);
        confirmationPanelMenu.SetActive(false);

        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
        yesButtonMainMenu.onClick.AddListener(ConfirmActionMenu);
        noButtonMainMenu.onClick.AddListener(PauseGame);

        yesButtonRestart.onClick.AddListener(ConfirmActionRestart);
        noButtonRestart.onClick.AddListener(PauseGame);
    }

    private void PauseGame()
    {
        AudioManager.instance.buttonPressSound.Play();
        pauseMenuPanel.SetActive(true);
        confirmationPanelRestart.SetActive(false);
        confirmationPanelMenu.SetActive(false);
        Time.timeScale = 0f;  // Pause the game
    }

    private void ResumeGame()
    {
        AudioManager.instance.buttonPressSound.Play();
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;  // Resume the game
    }

    private void RestartGame()
    {
        AudioManager.instance.buttonPressSound.Play();
        confirmationPanelRestart.SetActive(true);
        confirmationPanelMenu.SetActive(false);
        pauseMenuPanel.SetActive(false);
        //currentAction = Action.Restart;
    }

    private void QuitGame()
    {
        AudioManager.instance.buttonPressSound.Play();
        confirmationPanelMenu.SetActive(true);
        confirmationPanelRestart.SetActive(false);
        pauseMenuPanel.SetActive(false);
       // currentAction = Action.Quit;
    }

    private void ConfirmActionMenu()
    {
        AudioManager.instance.buttonPressSound.Play();

        Time.timeScale = 1f;  // Make sure the game is not paused when switching scenes
            SceneManager.LoadScene("MenuSystem");  // Load the MenuSystem scene (replace with your menu scene name)
        
    }
    private void ConfirmActionRestart()
    {
        AudioManager.instance.buttonPressSound.Play();

        Time.timeScale = 1f;  // Make sure the game is not paused when reloading
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Restart the current scene
        
       
    }


}

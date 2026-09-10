using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    //public GameObject pausePanel;

    //public void PauseGame()
    //{
    //    pausePanel.SetActive(true);
    //    Time.timeScale = 0f;
    //}

    //public void ResumeGame()
    //{
    //    pausePanel.SetActive(false);
    //    Time.timeScale = 1f;
    //}

    //public void RestartGame()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    //public void MainMenu()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("MainMenu");
    //}

    public static PauseManager Instance;

    [Header("UI References")]
    public GameObject pauseButton;   // the button visible during gameplay
    public GameObject pausePanel;    // your Figma pause page

    //[Header("Scene Names")]
    //public string levelSelectSceneName = "LevelSelect";

    bool isPaused = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;          // freeze all physics/animation/Update-based movement
        pausePanel.SetActive(true);
        pauseButton.SetActive(false); // hide pause button while paused
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // always reset before loading, or the new scene loads frozen
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // use your actual main menu scene name
    }

    //public void GoToLevelSelect()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene(levelSelectSceneName);
    //}
}

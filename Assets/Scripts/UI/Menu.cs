using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public void StartGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //public void OpenSettings()
    //{
    //    SceneManager.LoadScene("Settings");
    //}
    public void QuitGame()
    {
        Application.Quit();

    }
    public void GoToMenu()
{
    Time.timeScale = 1f;               // safety, in case the game was paused
    SceneManager.LoadScene("Menu");    // must match your scene name exactly
}
}

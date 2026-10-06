using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f; // safety, in case the game was paused
        SceneManager.LoadScene("Menu"); // must match your scene name exactly
    }
}
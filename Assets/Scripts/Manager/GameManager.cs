using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    float restartDelay = 1.5f;
    float messageDelay = 0.7f;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    public Score scoreScript;
    public GameObject completeLevelUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        if (gameHasEnded == false){

            gameHasEnded = true;
            scoreScript.stopScore = true;
            Debug.Log("GAME OVER!");
            Invoke("ShowGameOver", messageDelay);
            Invoke("Restart", restartDelay);
        }
    }

    void ShowGameOver()
    {
        scoreText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over!";
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

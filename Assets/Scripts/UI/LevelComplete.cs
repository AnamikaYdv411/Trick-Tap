using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject completeLevelUI;

    public int mainMenuBuildIndex = 0;

    public TMP_Text scoreText;
    public TMP_Text coinsText;

    public void ShowLevelComplete()
    {
        gameObject.SetActive(true);

        // Stop score from changing
        Score.Instance.stopScore = true;

        // Get final values
        int finalScore = Score.Instance.currentScore;
        int finalCoins = CoinManager.Instance.TotalCoins;

        // Put values into UI
        scoreText.text = finalScore.ToString();
        coinsText.text = finalCoins.ToString();

        // Show Level Complete panel
        completeLevelUI.SetActive(true);
        StartCoroutine(PauseAfterDelay());
    }

    IEnumerator PauseAfterDelay()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 0f;
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;

        int next = SceneManager.GetActiveScene().buildIndex + 1;

        if (next < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(next);
        }
        else
        {
            SceneManager.LoadScene(mainMenuBuildIndex);
        }
    }

    public void OnReplayLevelPressed()
    {
        Time.timeScale = 1f;
        CoinManager.Instance.ResetCoins();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenuPressed()
    {
        Time.timeScale = 1f;
        CoinManager.Instance.ResetCoins();
        SceneManager.LoadScene(mainMenuBuildIndex);
    }
}
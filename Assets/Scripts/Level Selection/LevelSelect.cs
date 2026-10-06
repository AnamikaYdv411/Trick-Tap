using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public int firstLevelBuildIndex = 2;   // build index of Level 1
    public int mainMenuBuildIndex = 0;

    public void LoadLevel(int levelNumber)
    {
        Time.timeScale = 1f;
        if (CoinManager.Instance != null) CoinManager.Instance.ResetCoins();
        SceneManager.LoadScene(firstLevelBuildIndex + levelNumber - 1);
    }

    public void Back()
    {
        SceneManager.LoadScene(mainMenuBuildIndex);
    }
}
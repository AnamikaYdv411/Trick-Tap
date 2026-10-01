using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    float restartDelay = 2f;
    float messageDelay = 1f;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    public Score scoreScript;
    public LevelComplete levelComplete;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    public void CompleteLevel()
    {
        if (gameHasEnded)
            return;

        gameHasEnded = true;

        // Tell LevelComplete to display score + coins
        levelComplete.ShowLevelComplete();
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            scoreScript.stopScore = true;
            Debug.Log("GAME OVER!");

            // Play the die animation
            PlayerAnimation anim = FindAnyObjectByType<PlayerAnimation>();
            if (anim != null) anim.PlayDeath();

            // Stop the player's movement and physics
            PlayerMovement movement = FindAnyObjectByType<PlayerMovement>();
            if (movement != null)
            {
                movement.enabled = false;
                Rigidbody rb = movement.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;  // use rb.velocity on older Unity versions
                    rb.isKinematic = true;
                }
            }

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

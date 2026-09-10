using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public Transform player;
    public TMP_Text scoreText;

    public bool stopScore = false;

    public int currentScore { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (!stopScore && player != null)
        {
            currentScore = Mathf.RoundToInt(player.position.z);

            if (scoreText != null)
                scoreText.text = currentScore.ToString();
        }
    }
}
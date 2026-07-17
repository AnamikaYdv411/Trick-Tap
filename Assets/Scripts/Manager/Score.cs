using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;
    public bool stopScore = false;

    void Update()
    {
        if (!stopScore){
        scoreText.text = player.position.z.ToString("0");
        
        }
    }

}

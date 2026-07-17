using UnityEngine;

public class PathTrigger : MonoBehaviour
{
    public string pathValue;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        bool correct = pathValue == HintManager.Instance.currentHintValue;
        if (!correct)
            FindAnyObjectByType<GameManager>().EndGame();
        Debug.Log("Correct path!");
    }
}

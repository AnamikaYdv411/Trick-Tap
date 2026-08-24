using UnityEngine;

public class PatternGateManager : MonoBehaviour
{
    public static PatternGateManager Instance;
    string[] sequence;
    int currentIndex;

    void Awake() => Instance = this;

    public void SetSequence(string[] seq) { sequence = seq; currentIndex = 0; }

    public void TryPass (string shape)
    {
        if (sequence == null)
        {
            FindAnyObjectByType<GameManager>().EndGame();
            return;
        }
        if (currentIndex >= sequence.Length) return;
        if (shape == sequence[currentIndex]) currentIndex++;
        else FindAnyObjectByType<GameManager>().EndGame();
    }
}

using TMPro;
using UnityEngine;

public class MathGateManager : MonoBehaviour
{
    public static MathGateManager Instance;
    public TMP_Text timerText;
    public float timeLimit = 4f;

    float timer;
    bool active;
    int correctAnswer;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public (int a, int b, char op, string problemText) GenerateProblem()
    {
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        char op = Random.value > 0.5f ? '+' : '-';
        if (op == '-' && b>a) { int t = a; a = b; b = t; }

        StartProblem(a, b, op);
        string text = $"{a} {op} {b} = ?";
        return (a, b, op, text);
    }

    public void StartProblem(int a, int b, char op)
    {
        correctAnswer = op == '+' ? a + b : a - b;
        timer = timeLimit;
        active = true;
    }

    void Update()
    {
        if (!active) return;
        timer -= Time.deltaTime;
        if (timerText != null)
            timerText.text = Mathf.Ceil(timer).ToString();

        if (timer <= 0)
        {
            active = false;
            FindAnyObjectByType<GameManager>().EndGame();
        }
    }    

    public void CheckAnswer(int chosen)
    {
        if (!active) return;
        active = false;
        if (chosen != correctAnswer)
            FindAnyObjectByType<GameManager>().EndGame();
    }
    
}

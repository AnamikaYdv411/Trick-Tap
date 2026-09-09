using UnityEngine;

public class AnswerGate : MonoBehaviour
{
    public int value;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        MathGateManager.Instance.CheckAnswer(value);
    }
}

using UnityEngine;

public class EnvelopeHint : MonoBehaviour
{
    public bool isCorrectEnvelope;
    [TextArea] public string hintDisplayText;
    public string hintValue;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (isCorrectEnvelope)
            HintManager.Instance.SetHint(hintValue, hintDisplayText);
        gameObject.SetActive(false);
    }
}

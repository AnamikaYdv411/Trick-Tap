using UnityEngine;

public class EnvelopeHint : MonoBehaviour
{
    public bool isCorrectEnvelope;
    [TextArea] public string hintDisplayText;
    public string hintValue;

    [Header("Level 3 - Reverse Controls")]
    public bool triggersReverseControls = false;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (isCorrectEnvelope)
            HintManager.Instance.SetHint(hintValue, hintDisplayText);
        else
            HintManager.Instance.ShowMisleadingHint(hintDisplayText);

        if (triggersReverseControls)
        {
            PlayerMovement1 pm = other.GetComponent<PlayerMovement1>();
            if (pm != null) pm.controlReversed = true;
        }

        gameObject.SetActive(false);
    }
}

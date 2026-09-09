using UnityEngine;

public class EnvelopeHint : MonoBehaviour
{
    public bool isCorrectEnvelope;
    [TextArea] public string hintDisplayText;
    public string hintValue;

    [Header("Level 3 - Reverse Controls")]
    public bool triggersReverseControls = false;
    public float reverseDuration = 3f;

    [Header("Level 4 - Pattern Gate")]
    public bool setsPatternSequence;
    public string[] sequence;

    [Header("Level 5 - Math Gate")]
    public bool triggersMathGate = false;

    void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;

        PlayerMovement1 pm = other.GetComponent<PlayerMovement1>();

        if (isCorrectEnvelope)
        {
            if (setsPatternSequence)
                PatternGateManager.Instance.SetSequence(sequence);

            string valueToUse = hintValue;
            string displayToUse = hintDisplayText;

            if (triggersMathGate)
            {
                var problem = MathGateManager.Instance.GenerateProblem();
                valueToUse = problem.problemText;
                displayToUse = problem.problemText;
            }

            HintManager.Instance.SetHint(valueToUse, displayToUse, () =>
            {
                // runs only AFTER the freeze/popup ends
                if (triggersReverseControls && pm != null)
                {
                    pm.controlReversed = true;
                    pm.CancelInvoke(nameof(pm.ResetControls));
                    pm.Invoke(nameof(pm.ResetControls), reverseDuration);
                }
            });
        }
        else
        {
            HintManager.Instance.ShowMisleadingHint(hintDisplayText);
        }

        gameObject.SetActive(false);
    }
}
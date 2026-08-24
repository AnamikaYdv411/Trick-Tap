using UnityEngine;

public class PatternSequenceSetter : MonoBehaviour
{
    public string[] sequence = { "Square", "Triangle", "Circle" };

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        PatternGateManager.Instance.SetSequence(sequence);
    }
}

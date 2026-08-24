using UnityEngine;

public class ShapeGate : MonoBehaviour
{
    public string shapeName;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        PatternGateManager.Instance.TryPass(shapeName);
    }
}

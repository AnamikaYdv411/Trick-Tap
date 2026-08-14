using UnityEngine;

public class ReversedControlZone : MonoBehaviour
{
    public bool revertOnExit = true;
    public float revertAfterSeconds = 0f;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerMovement1 pm = other.GetComponent<PlayerMovement1>();
        if (pm==null) return;

        pm.controlReversed = true;
        if (revertAfterSeconds > 0f)
            Invoke(nameof(RevertByTimer), revertAfterSeconds);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!revertOnExit) return;
        PlayerMovement1 pm = other.GetComponent<PlayerMovement1>();
        if (pm != null) pm.controlReversed = false;
    }

    void RevertByTimer()
    {
        PlayerMovement1 pm = FindAnyObjectByType<PlayerMovement1>();
        if (pm != null) pm.controlReversed = false;
    }
}

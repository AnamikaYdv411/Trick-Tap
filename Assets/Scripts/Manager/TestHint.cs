using UnityEngine;

public class TestHint : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(TriggerHint), 1f);
    }

    void TriggerHint()
    {
        HintManager.Instance.SetHint("Right", "Choose RIGHT");
    }
}
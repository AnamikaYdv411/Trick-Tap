using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float spinSpeed = 3f;
    public float bobHeight = 0.15f;
    public float bobSpeed = 2f;

    private Vector3 initialScale;
    private Vector3 initialPosition;

    void Start()
    {
        initialScale = transform.localScale;
        initialPosition = transform.localPosition; // Store starting local position (e.g. Y = 0.8)
    }

    void Update()
    {
        // Pseudo 2D spin via scale
        float scaleX = Mathf.Cos(Time.time * spinSpeed);
        Vector3 s = initialScale;
        s.x = initialScale.x * scaleX;
        transform.localScale = s;

        // Bob up and down relative to starting Y position
        float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.localPosition = new Vector3(
            initialPosition.x,
            initialPosition.y + yOffset,
            initialPosition.z
        );
    }
}
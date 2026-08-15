using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float maxForwardForce = 6000f;
    public float forceIncreaseRate = 50f; // how fast it ramps up per second

    public float laneSwitchSpeed = 15f;
    public float laneWidth = 3f;
    public int laneCount = 4;
    private float[] lanePositions;
    private int currentLane;

    public bool controlReversed = false;

    void Start()
    {
        lanePositions = new float[laneCount];
        float groundWidth = laneWidth * laneCount;
        float startX = -groundWidth / 2f + laneWidth / 2f;

        for (int i = 0; i < laneCount; i++)
        {
            lanePositions[i] = startX + i * laneWidth;
        }

        currentLane = laneCount / 2;
    }

    void Update()
    {
        KeyCode rightKey = controlReversed ? KeyCode.A : KeyCode.D;
        KeyCode leftKey = controlReversed ? KeyCode.D : KeyCode.A; 
        if (Input.GetKeyDown(rightKey))
        {
            currentLane = Mathf.Clamp(currentLane + 1, 0, laneCount - 1);
        }
        if (Input.GetKeyDown(leftKey))
        {
            currentLane = Mathf.Clamp(currentLane - 1, 0, laneCount - 1);
        }
    }

    void FixedUpdate()
    {
        // Gradually ramp forward force up to the max over time
        forwardForce = Mathf.Min(forwardForce + forceIncreaseRate * Time.fixedDeltaTime, maxForwardForce);

        rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);

        float targetX = lanePositions[currentLane];
        Vector3 targetPosition = new Vector3(targetX, rb.position.y, rb.position.z);
        Vector3 newPosition = Vector3.MoveTowards(rb.position, targetPosition, laneSwitchSpeed * Time.fixedDeltaTime);

        rb.MovePosition(new Vector3(newPosition.x, rb.position.y, rb.position.z));

        if (rb.position.y < -1f)
        {
            FindAnyObjectByType<GameManager>().EndGame();
        }
    }

    public void ResetControls()
    {
        controlReversed = false;
        if (HintManager.Instance != null)
            HintManager.Instance.SetHint("", "Controls Normal");

    }
}
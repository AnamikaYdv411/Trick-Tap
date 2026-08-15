using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    public bool controlReversed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);
        KeyCode rightKey = controlReversed ? KeyCode.A : KeyCode.D;
        KeyCode leftKey = controlReversed ? KeyCode.D : KeyCode.A;

        if (Input.GetKey(rightKey))
        {
            rb.AddForce(sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(leftKey))
        {
            rb.AddForce(-sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

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

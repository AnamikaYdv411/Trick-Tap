using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(sidewaysForce * Time.fixedDeltaTime,0,0, ForceMode.VelocityChange);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-sidewaysForce * Time.fixedDeltaTime,0,0,ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindAnyObjectByType<GameManager>().EndGame();
        }
    }
}

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement1 movement;
    void OnCollisionEnter(Collision playerCollision)
    {
       if ( playerCollision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindAnyObjectByType<GameManager>().EndGame();
        }
    }
}

using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    public void PlayDeath()
    {
        animator.SetTrigger("Die");
    }
}
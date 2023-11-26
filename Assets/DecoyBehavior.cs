using System.Collections;
using UnityEngine;

public class DecoyBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canJump = true;
    public Animator animator;
    public AudioSource audio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Call the Jump method every 3 seconds
        InvokeRepeating("Jump", 3f, 3f);
    }

    void Update()
    {
        // Check if the decoy is on the ground
        bool isOnGround = IsOnGround();

        // Allow jumping only when on the ground
        if (isOnGround)
        {
            canJump = true;
        }
    }

    void Jump()
    {
        // Only jump if allowed (on the ground)
        if (canJump)
        {
            // Apply upward force for the jump
            rb.AddForce(new Vector2(0f, 500f));

            animator.SetFloat("UpMotion?", 1);

            audio.Play();

            // Disallow jumping until the decoy hits the ground again
            canJump = false;
        }
    }

    bool IsOnGround()
    {
        // Cast a ray downward to check if the decoy is on the ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 8f, LayerMask.GetMask("Terrain"));

        animator.SetFloat("UpMotion?", 0);

        if (hit.collider != null)
        {
            Debug.Log("On Ground");
            return true;
        }
        else
        {
            Debug.Log("Not On Ground");
            return false;
        }
    }
}

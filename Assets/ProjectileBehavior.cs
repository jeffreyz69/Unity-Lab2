using UnityEngine;
public class ProjectileBehavior : MonoBehaviour
{
    public float speed;
    

    void Start()
    {
        speed = 24.0f;
    }
    // Update is called once per frame
    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.right;

        // Update the rotation to match the scale set by the Movement script
        if (transform.localScale.x < 0)
        {
            // If scale is negative, rotate the projectile to face left
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            // If scale is positive, reset the rotation to its original (facing right)
            transform.rotation = Quaternion.identity;
        }

        DestroyAfterTime();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void DestroyAfterTime()
    {
        // Destroy after x time
        Destroy(gameObject, 6);
    }
}

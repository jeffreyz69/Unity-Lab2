using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] float moveSpeed;
    [SerializeField] float movementX, movementY;
    [SerializeField] Vector2 position;

    public ProjectileBehavior projectilePrefab;
    public GameObject plane;
    public Transform LaunchOffset;
    public new AudioSource audio;
    private float lastMovementDirection = 1; // 1 for right, -1 for left

    
    //private bool canShoot = true; // Flag to control shooting

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 12.0f;
        if (body == null)
        {
            body = GetComponent<Rigidbody2D>();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(movementX * moveSpeed, movementY * moveSpeed);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = movement;

        if (movementX < 0)
        {
            // Flip the plane sprite if moving left
            plane.transform.localScale = new Vector3(-1, 1, 1);
            lastMovementDirection = -1; // Set the direction to left
        }
        else if (movementX > 0)
        {
            // Reset the scale to its original if moving right
            plane.transform.localScale = new Vector3(1, 1, 1);
            lastMovementDirection = 1; // Set the direction to right
        }

        if (movementX == 0 && movementY == 0)
        {
            rb.velocity = Vector2.zero;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ShootProjectile();
        }

    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(plane); //dead if they touch you
            //Goes to gameover screen with a button to

            //SetCanShoot(false);
            //go back to the main menu
            SceneManager.LoadScene(0);
        }else if (collision.CompareTag("Terrain"))
        {
            Destroy(plane);
            SceneManager.LoadScene(0);
        }
    }

    void ShootProjectile()
    {
        // Get the position of the LauncherOffset in world space
        Vector2 launchPosition = LaunchOffset.position;
        audio.Play();

        // Instantiate the projectile
        ProjectileBehavior projectileInstance = Instantiate(projectilePrefab, launchPosition, Quaternion.identity);

        // Set the rotation of the projectile based on the last known movement direction
        projectileInstance.transform.localScale = new Vector3(lastMovementDirection, 1, 1);
    }

    // Set shooting permission based on game pause state
    //public void SetCanShoot(bool canShoot)
    //{
    //    this.canShoot = canShoot;
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //TODO: Implement enemy movement with basic AI, such as moving top to bottom, left to right, or in a circle.

    [SerializeField] Rigidbody2D body;
    [SerializeField] float moveSpeed;
    public GameObject player;
    public AudioSource audioPlayer;
    private float distance = 0;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 8.0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag("Projectile") && !this.gameObject.CompareTag("Boss"))
        {
            audioPlayer.Play();
            Destroy(gameObject);
            ScoreManager.instance.AddPoints();
        }else if (this.gameObject.CompareTag("Boss") && other.CompareTag("Projectile"))
        {
            audioPlayer.Play();
            Destroy(gameObject);
            ScoreManager.instance.AddPoints(4);
        }
    }

    // Update is called once per frame
    void Update()
    {

        FollowPlayer();


    }

    void FollowPlayer()
    {
        if (player != null)
        {
            distance = Vector2.Distance(this.transform.position, player.transform.position);
            Vector2 direction = (player.transform.position - transform.position).normalized;

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    
}

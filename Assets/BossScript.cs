using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement module

public class BossScript : MonoBehaviour
{
    private float height, width;
    public float growthRate = 1.0f; // Adjust the growth rate as needed
    public float maxSize = 5.0f; // Set the maximum size before the object dies
    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        width = transform.localScale.x;

        InvokeRepeating(nameof(IncreaseSize), 1.0f, 1.0f); // Invoke IncreaseSize every 1 second (adjust as needed)

        // Invoke RestartScene after 10 seconds (adjust as needed)
        Invoke(nameof(RestartScene), 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // You can add other logic here if needed
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile") && !this.gameObject.CompareTag("Boss"))
        {
            audioPlayer.Play();
            Destroy(gameObject);
            ScoreManager.instance.AddPoints();
        }
    }

    void IncreaseSize()
    {
        // Check if the object is not too big yet
        if (height < maxSize && width < maxSize)
        {
            height += growthRate;
            width += growthRate;

            // Apply the new size to the GameObject
            transform.localScale = new Vector3(width, height, 1.0f);
        }
        else
        {
            // When the Balloon becomes too big after 10 seconds, restart the scene
            RestartScene();
        }
    }

    void RestartScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}

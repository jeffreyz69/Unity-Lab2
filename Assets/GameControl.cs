using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl control;

    public int currentScore = 0;

    void Start()
    {
        // Initialize the score when the game starts
        ResetScore();
    }

    void Update()
    {
        // Check for input or game events that trigger score reset
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Example: Reset score when the Escape key is pressed
            ResetScore();
        }
    }

    public void Awake()
    {
        // Ensure there is only one instance of GameControl
        if (control == null)
        {
            control = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    // Call this method to reset the score to 0
    public void ResetScore()
    {
        currentScore = 0;
    }
}

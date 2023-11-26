using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Resume : MonoBehaviour
{

    public GameObject pauseButton;
    public GameObject resumeButton;

    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the initial state is not paused
        isPaused = false;
        Time.timeScale = 1f;

        // Initially show the pause button and hide the resume button
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPauseButtonClick()
    {
        // Pause the game
        Debug.Log("pause clicked");
        isPaused = true;
        Time.timeScale = 0f;

        // Hide the pause button and show the resume button
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
    }

    public void OnResumeButtonClick()
    {
        // Resume the game
        isPaused = false;
        Time.timeScale = 1f;

        // Hide the resume button and show the pause button
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] int score = 0;
    [SerializeField] TMP_Text scoreText;
    int ScoreThres = 0;
    int level;

    // Add a reference to the text for displaying notifications
    [SerializeField] TMP_Text notificationText;

    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        ScoreThres = GameControl.control.currentScore + level;
        scoreText.SetText("Score: " + GameControl.control.currentScore); // shows score
        Debug.Log(ScoreThres);
    }

    private void Awake()
    {
        instance = this;
    }

    public void AddPoints()
    {
        GameControl.control.currentScore++;

        scoreText.SetText("Score: " + GameControl.control.currentScore); // updates score

        if (GameControl.control.currentScore >= ScoreThres)
        {
            StartCoroutine(ShowNotificationAndLoadLevel());
        }
    }

    //overloaded function 
    public void AddPoints(int points)
    {
        GameControl.control.currentScore += points;
        scoreText.SetText("Score: " + GameControl.control.currentScore); // updates score

        if (GameControl.control.currentScore >= ScoreThres)
        {
            StartCoroutine(ShowNotificationAndLoadLevel());
        }
    }

    IEnumerator ShowNotificationAndLoadLevel()
    {
        // Show notification text
        notificationText.text = "Next level loading...";
        notificationText.enabled = true;

        // Wait for 2 seconds
        yield return new WaitForSeconds(2.0f);

        // Hide notification text
        notificationText.enabled = false;

        // Update the leaderboard if LeaderboardManager.instance is not null
        if (LeaderboardManager.instance != null)
        {
            LeaderboardManager.instance.UpdateLeaderboard(GameControl.control.currentScore);
        }
        // Load the next level
        SceneManager.LoadScene(level + 1);
    }
}

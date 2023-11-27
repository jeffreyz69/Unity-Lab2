using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager instance;

    [SerializeField] TMP_Text[] scoreTexts;

    private List<int> leaderboardScores = new List<int>();

    void Awake()
    {
        instance = this;
        LoadLeaderboard();
    }

    public void UpdateLeaderboard(int newScore)
    {
        Debug.Log("Updating leaderboard with score: " + newScore);

        leaderboardScores.Add(newScore);
        leaderboardScores.Sort((a, b) => b.CompareTo(a)); // Sort in descending order

        while (leaderboardScores.Count > 5)
        {
            leaderboardScores.RemoveAt(5); // Keep only the top 5 scores
        }

        UpdateUIText();
        SaveLeaderboard();
    }

    void UpdateUIText()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < leaderboardScores.Count)
            {
                scoreTexts[i].SetText((i + 1) + ". " + leaderboardScores[i]);
            }
            else
            {
                scoreTexts[i].SetText("");
            }
        }
    }

    void SaveLeaderboard()
    {
        // Convert the list to JSON-formatted string
        string jsonScores = JsonUtility.ToJson(new LeaderboardData(leaderboardScores));

        // Save the JSON string to PlayerPrefs
        PlayerPrefs.SetString("LeaderboardScores", jsonScores);
        PlayerPrefs.Save();
    }

    void LoadLeaderboard()
    {
        // Retrieve the JSON string from PlayerPrefs
        string jsonScores = PlayerPrefs.GetString("LeaderboardScores");

        if (!string.IsNullOrEmpty(jsonScores))
        {
            // Convert the JSON string back to a list of scores
            LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(jsonScores);
            leaderboardScores = data.scores;
        }

        UpdateUIText();
    }

    // Helper class to store leaderboard data
    [System.Serializable]
    private class LeaderboardData
    {
        public List<int> scores;

        public LeaderboardData(List<int> scores)
        {
            this.scores = scores;
        }
    }
}

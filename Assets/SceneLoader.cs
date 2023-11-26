using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnButtonClickMenu()
    {
        // Back to main menu
        SceneManager.LoadScene(0);

        // Reset the score when returning to the main menu
        if (GameControl.control != null)
        {
            GameControl.control.ResetScore();
        }
    }

    public void OnButtonClickDoc()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void OnButtonClickLeader()
    {
        SceneManager.LoadScene("LeaderBoard");
    }
}

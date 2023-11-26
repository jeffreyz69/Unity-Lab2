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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public static GameControl control;

    public int currentScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Awake()
    {
        if(control == null)
        {
            control = this;
            DontDestroyOnLoad(gameObject);
        } else if (control != this)
        {
            Destroy(gameObject);
        }
    }
}

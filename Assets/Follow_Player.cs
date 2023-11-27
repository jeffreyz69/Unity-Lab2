using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// CAMERA SCRIPT
public class Follow_Player : MonoBehaviour
{

    public Transform player;
    private const int zLayer = -1; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //null check
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y + 1, zLayer);
        }
    }
}

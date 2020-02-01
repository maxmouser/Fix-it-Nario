using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdatePlatformer()
    {
        
    }

    
}
 class gameManager 
{
    bool pause;

    void update()
    {
        if (pause) return;

        //platformer.UpdatePlatformer();
    }
}

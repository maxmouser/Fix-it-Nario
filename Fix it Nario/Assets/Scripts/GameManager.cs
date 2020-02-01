using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject PlatformerGO;
    public Mouse _mouseManager;
    bool isGameInPause = false;
    public FixerManager fixerM;

    void Update()
    {
        if (!isGameInPause)
        {
            _mouseManager.UpdateMousePosition();
            fixerM.UpdateFixerManager(_mouseManager.CurrentMousePosition);
        }
    }
}

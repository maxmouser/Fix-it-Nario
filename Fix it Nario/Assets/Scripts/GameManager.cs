using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject PlatformerGO;
    public Mouse _mouseManager;
    bool isGameInPause = true;
    public FixerManager fixerM;
    private MovimientoPlayer1 player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoPlayer1>();
        fixerM.StartCreateResources();
        Camera.main.GetComponent<MovimientoCamara>().onEndShake = StartToPlay;
    }

    private void StartToPlay()
    {
        isGameInPause = false;
        player.pause = false;
        player._onPlayerDeath = OnPlayerDeath;
    }


    void Update()
    {
        if (!isGameInPause)
        {
            _mouseManager.UpdateMousePosition();
            fixerM.UpdateFixerManager(_mouseManager.CurrentMousePosition);
            
        }
    }

    private void OnPlayerDeath()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");

        //UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    private void OnWin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");

    }
}




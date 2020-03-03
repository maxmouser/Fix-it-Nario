using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject PlatformerGO;
    public Mouse _mouseManager;
    bool isGameInPause = true;
    public FixerManager fixerM;
    private Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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

    public AudioClip hit;
    private void OnPlayerDeath()
    {
        Constants.AUDIO_MANAGER.PlayFx(hit, 1);
        Invoke("LoadAgain", hit.length + 0.5f);

        //UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    private void LoadAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");

    }

    private void OnWin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");

    }
}




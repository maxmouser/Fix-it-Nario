using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}

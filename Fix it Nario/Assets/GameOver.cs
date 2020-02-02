using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update

    bool anyKeyActivated = false;
    void Start()
    {
        Invoke("LoadMainMenu", 10);
        Invoke("ActivePressAnyKey", 1);
    }

    void ActivePressAnyKey()
    {
        anyKeyActivated = true;
    }

    private void Update()
    {
        if (anyKeyActivated)
        {
            if (Input.anyKey)
            {
                LoadMainMenu();
            }
        }
    }

    // Update is called once per frame
    void LoadMainMenu()
    {
        if (IsInvoking("LoadMainMenu"))
        {
            CancelInvoke("LoadMainMenu");
        }
        if (IsInvoking("ActivePressAnyKey"))
        {
            CancelInvoke("ActivePressAnyKey");
        }
       
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}

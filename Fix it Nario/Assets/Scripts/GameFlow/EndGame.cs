using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 8)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }

    }
}

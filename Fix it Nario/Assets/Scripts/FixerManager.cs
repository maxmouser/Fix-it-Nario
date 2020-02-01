using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FixerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] resources;
    public int[] resourcesCuantity;
    public GameObject[] resourcesGo;

    public UIResources _uiResources;

    void Start()
    {
        if (resources.Length + resourcesCuantity.Length != resourcesGo.Length * 2)
        {
            Debug.LogError("Error length");
        }

        for (int i = 0; i < resources.Length; i++)
        {
            int index = i;
            _uiResources.CreateResource(
                () => 
                {
                    CreateResourceInScene(index);
                }, resources[i], resourcesCuantity[i]);
        }
    }

    // Update is called once per frame
    public void UpdateFixerManager()
    {
        
    }

    public void CreateResourceInScene(int id)
    {
        Debug.Log("CreateResource Id : "  + id);
    }
}

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
        if (activeDragable != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("release");
                activeDragable = null;
            }
            else
            {
                activeDragable.transform.position = GetWorldToMouseScreenPosition();
            }
        }
    }

    GameObject activeDragable;

    public void CreateResourceInScene(int id)
    {
        Debug.Log("CreateResource Id : "  + id);
        activeDragable = Instantiate(resourcesGo[id], GetWorldToMouseScreenPosition(), Quaternion.identity);
        //Debug.Break();
    }

    Vector3 GetWorldToMouseScreenPosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
}

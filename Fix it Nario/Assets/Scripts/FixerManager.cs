using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FixerManager : MonoBehaviour
{
    public Sprite[] resources;
    public int[] resourcesCuantity;
    public GameObject[] resourcesGo;

    public UIResources _uiResources;

    Camera _mainCamera;

    void Start()
    {
        _mainCamera = Camera.main;
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

    public void UpdateFixerManager()
    {
        if (activeDragable != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
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
    }

    Vector3 GetWorldToMouseScreenPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, Constants.Z_WORLD));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}

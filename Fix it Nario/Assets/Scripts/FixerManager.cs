using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FixerManager : MonoBehaviour
{
    public Sprite[] resourcesSprites;
    public int[] resourcesCuantity;
    public GameObject[] resourcesGo;
    

    public UIResources _uiResources;

    Camera _mainCamera;

    void Start()
    {
        _mainCamera = Camera.main;
        if (resourcesSprites.Length + resourcesCuantity.Length != resourcesGo.Length * 2)
        {
            Debug.LogError("Error length");
        }

        for (int i = 0; i < resourcesSprites.Length; i++)
        {
            int index = i;
            _uiResources.CreateResource(
                () => 
                {
                    CreateResourceInScene(index);
                }, resourcesSprites[i], resourcesCuantity[i]);
        }
    }

    private Vector3 _currentMousePosition;

    public void UpdateFixerManager(Vector3 currentMousePosition)
    {
        _currentMousePosition = currentMousePosition;
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
        if (resourcesCuantity[id] > 0)
        {
            resourcesCuantity[id]--;
            Debug.Log("CreateResource Id : " + id + " left: " + resourcesCuantity[id]);

            activeDragable = Instantiate(resourcesGo[id], GetWorldToMouseScreenPosition(), Quaternion.identity);

        }
        else
        {
            Debug.Log("no item");
        }
    }

    Vector3 GetWorldToMouseScreenPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(_currentMousePosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, Constants.Z_WORLD));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    public int resourceCreatePerCollectable = 1;
    public void CreateResource()
    {
        int id = Mathf.RoundToInt(UnityEngine.Random.Range(0, resourcesGo.Length));
        resourcesCuantity[id] += resourceCreatePerCollectable;
        _uiResources.UpdateCuantity(id, resourcesCuantity[id]);

    }
}

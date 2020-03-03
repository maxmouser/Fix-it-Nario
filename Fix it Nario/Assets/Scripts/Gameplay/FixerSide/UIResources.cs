using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIResources : MonoBehaviour
{
    public GameObject resourceButton;
    private List<UIButtonResource> _uiR;

    public void CreateResource(Action onClick, Sprite sprite, int cuantity)
    {
        if (_uiR == null)
        {
            _uiR = new List<UIButtonResource>();
        }

        resourceButton = Instantiate(resourceButton, this.transform);
        UIButtonResource resource = resourceButton.GetComponent<UIButtonResource>();
        resource.SetResource(onClick, sprite, cuantity);
        _uiR.Add(resource);
    }

    public void UpdateCuantity(int id, int cuant)
    {
        _uiR[id].ModifyCuantity(cuant);
    }
}

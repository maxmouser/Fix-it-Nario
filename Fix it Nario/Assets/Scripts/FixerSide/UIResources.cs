using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIResources : MonoBehaviour
{
    public GameObject resourceButton;
    public void CreateResource(Action onClick, Sprite sprite, int cuantity)
    {
        resourceButton = Instantiate(resourceButton, this.transform);
        var resource = resourceButton.GetComponent<UIResource>();
        resource.SetResource(onClick, sprite, cuantity);
    }


}

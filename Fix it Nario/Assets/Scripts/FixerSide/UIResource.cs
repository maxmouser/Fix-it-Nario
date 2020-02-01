using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;

public class UIResource : MonoBehaviour
{
    private Button _button;
    private Action _onClick;
    private int _cuantity;

    private void Start()
    {
        _button = this.GetComponent<Button>();
        _button.onClick.AddListener(OnResourcesClick);
    }


    public void SetResource(Action onClick,  Sprite sprite, int cuantity)
    {
        if (sprite != null)
        {
            
        }

        _onClick = onClick;
    }

    private void OnResourcesClick()
    {
        Debug.Log("Click Resource");
        _onClick();
    }

    private void ModifyCuantity(int newCuantity)
    {

    }

}

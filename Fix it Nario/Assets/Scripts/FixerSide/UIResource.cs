using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;

public class UIResource : MonoBehaviour
{
    private Action _onClick;
    private int _cuantity;
    public bool _isHover;

    public void SetHover(bool value)
    {
        _isHover = value;
    }

    public bool clicked;
    
    private void Update()
    {
        if (clicked)
        {
            if (Input.GetMouseButtonUp(0))
            {
                clicked = false;
            }
        }
        else if (_isHover)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clicked = true;
                OnResourcesClick();

            }
        }

        
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

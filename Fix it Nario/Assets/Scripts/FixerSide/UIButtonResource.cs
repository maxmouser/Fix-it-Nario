using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;

public class UIButtonResource : MonoBehaviour
{
    public Text CuantityText;
    public Image MyRenderer;


    private Action _onClick;
    private int _cuantity;
    public bool _isHover;

    public void SetHover(bool value)
    {
        //Debug.Log("hover " + value);
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
            MyRenderer.sprite = sprite;
        }

        CuantityText.text = cuantity.ToString();

        _onClick = onClick;
    }

    private void OnResourcesClick()
    {
        _onClick();
    }

    public void ModifyCuantity(int newCuantity)
    {
        Debug.Log("ModifyCuantity " + newCuantity);
        CuantityText.text = newCuantity.ToString();

    }



}

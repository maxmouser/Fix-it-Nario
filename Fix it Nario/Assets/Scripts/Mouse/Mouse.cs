using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    public Rect mouseLimits;
    public GameObject _mouseImage;
    
    public float PercentScreenMove;

    private Vector3 _currentMousePosition;
    public Vector3 CurrentMousePosition
    {
        get
        {
            return _currentMousePosition;
        }
    }
   

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        mouseLimits = new Rect();
        mouseLimits.xMin = (PercentScreenMove * Screen.width) / 100;
        mouseLimits.xMax = Screen.width;
        mouseLimits.yMin = 0;
        mouseLimits.yMax = Screen.height;
    }

    public void UpdateMousePosition()
    {
        _currentMousePosition = GetMousePosition();
        _mouseImage.gameObject.transform.position = _currentMousePosition;
    }

    // Update is called once per frame
    public Vector3 GetMousePosition()
    {
        Vector3 realMousePos = Input.mousePosition;
        Vector3 fixedMousePos = Vector3.zero;
        
        if (realMousePos.x < mouseLimits.xMin)
        {
           // Debug.Log("min");
            fixedMousePos.x = mouseLimits.xMin;
            
        }
        else if (realMousePos.x > mouseLimits.xMax)
        {
            fixedMousePos.x = mouseLimits.xMax;
            //Debug.Log("max");
        }
        else
        {
            //Debug.Log("normal");
            fixedMousePos.x = realMousePos.x;
        }

        if (realMousePos.y < mouseLimits.yMin)
        {
            fixedMousePos.y = mouseLimits.yMin;
        }
        else if (realMousePos.y > mouseLimits.yMax)
        {
            fixedMousePos.y = mouseLimits.yMax;
        }
        else
        {
            fixedMousePos.y = realMousePos.y;
        }

        return fixedMousePos;

    }
}

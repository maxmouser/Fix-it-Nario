using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndDrop : MonoBehaviour
{
    /*DraggableObject DraggableObject;

    struct DragInfo
    {
        public bool buttonPressed;
        public Vector2 screenPosition;
    }

    DragInfo IsButtonPressedToDrag()
    {
        DragInfo dragInfo = new DragInfo();
        
        if (Input.GetMouseButtonDown(0))
        {
            dragInfo.buttonPressed = true;
            dragInfo.screenPosition = new Vector2();
            dragInfo.screenPosition.x = Input.mousePosition.x;
            dragInfo.screenPosition.y = Input.mousePosition.y;
        }

        return dragInfo;
    }
    // Update is called once per frame

    const float distRay = 50;
    void Update()
    {
        DragInfo dragInfo= IsButtonPressedToDrag();
        if (dragInfo.buttonPressed)
        {
            Vector3 position =  Camera.main.ScreenToWorldPoint(dragInfo.screenPosition);
            Physics.Raycast(position, Camera.main.transform.forward * distRay);
        }
    }*/

    public GameObject[] resourcesGo;
    public int[] resourcesCount;

    public void InstantiateItem()
    {

    }

    public void ReturnItem()
    {

    }
}

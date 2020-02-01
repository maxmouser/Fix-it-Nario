using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isDraggable;

    public void StartDrag()
    {

    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void StopDrag()
    {

    }

    public void FreezePosition()
    {
        isDraggable = false;
    }
   
    
    
}

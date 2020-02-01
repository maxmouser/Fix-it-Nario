using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isDraggable;

    public void FreezePosition()
    {
        isDraggable = false;
    }
   
    
    
}

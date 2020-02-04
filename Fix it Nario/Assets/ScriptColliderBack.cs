using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptColliderBack : MonoBehaviour
{
    public MovimientoPlayer1 player;

    void Start()
    {
        player = FindObjectOfType<MovimientoPlayer1>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 10)//Layer 10 es el empujador back
        {
            player.collisionEmpujeBack = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)//Layer 10 es el empujador back
        {
            player.collisionEmpujeBack = false;
        }
    }

}

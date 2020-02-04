using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptColliderFront : MonoBehaviour
{
    public MovimientoPlayer1 player;

    void Start()
    {
        player = FindObjectOfType<MovimientoPlayer1>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            player.isFalling = true;
            player.colisionEmpujeFront = true;
            player.isGrounded = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")//Layer 10 es el empujador back
        {
            player.colisionEmpujeFront = false;
        }
    }

}

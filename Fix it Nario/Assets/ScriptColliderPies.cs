using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptColliderPies : MonoBehaviour
{
	    public MovimientoPlayer1 player;

        void Start()
        {
  		    player = FindObjectOfType<MovimientoPlayer1>();
        }

    void OnTriggerEnter(Collider other){

          if (other.gameObject.layer == 11){ //Layer 11 es el el piso de muerte
				print("toca el objeto de piso de muerte con el nombre: " + other.gameObject.name);
				player.muerte();
         }
  	}

  	void OnTriggerStay(Collider other){
        if (other.gameObject.tag == "Ground")
        {
            player.isGrounded = true;
            player.isFalling = false;
            player.isJumping = false;
        }
  	}


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            player.isGrounded = false;

        }
        
    }
}

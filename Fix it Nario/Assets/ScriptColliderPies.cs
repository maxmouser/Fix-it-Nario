using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptColliderPies : MonoBehaviour
{
	public MovimientoPlayer1 player;
    // Start is called before the first frame update
    void Start()
    {
  		player = FindObjectOfType<MovimientoPlayer1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){

          if (other.gameObject.layer == 11){ //Layer 11 es el el piso de muerte
				print("toca el objeto de piso de muerte con el nombre: " + other.gameObject.name);
				player.muerte();
              //this.transform.position = new Vector3(transform.position.x + 10 * Time.deltaTime, transform.position.y, transform.position.z);
              //this.transform.Translate(-20 * transform.right * Time.deltaTime);

         }
  	}

  	void OnTriggerStay(Collider other){
        if (other.gameObject.tag == "Ground")
        {
        	print("tocando el piso");
            player.isGrounded = true;
            player.isFalling = false;
            player.isJumping = false;
        }
        else {
            player.isGrounded = false;
        }
  	}


	//void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Ground")
    //    {
    //    	print("tocando el piso");
    //        player.isGrounded = true;
    //        player.isFalling = false;
    //        player.isJumping = false;
    //    }
//
    //}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            player.isGrounded = false;

        }
        
    }
}

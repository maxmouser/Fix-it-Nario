using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovimientoPlayer1 : MonoBehaviour
{


    public Rigidbody rb;

    public float speed = 0.5f;

    public float jumpForce = 20;
    public float alturaSalto= 5;
	public float alturaSaltada;
	public float alturaDeSaltoInicial;
	public float alturaSaltoActual;
	public float deltaSalto;
    public float fallForce=-5;

    public bool isFalling= false;
    public bool isGrounded;
    public bool isJumping =false;
    public bool stairsCollision = false;
    public bool collisionEmpujeBack = false;
    public bool colisionEmpujeFront = false;

	public Action _onPlayerDeath;
    public Action _onWin;    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        fall();
 		jump();
 		movimientoHorizontal();

    }
  
    public void movimientoHorizontal(){


       if(Input.GetKey(KeyCode.D))
        {
           this.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z );
        }

       if(Input.GetKey(KeyCode.A) && !collisionEmpujeBack)
        {
        	this.transform.Translate(10 * transform.right * Time.deltaTime);
           //this.transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

       	if(Input.GetKey(KeyCode.W) && stairsCollision)
        {
           this.transform.position = new Vector3(transform.position.x, transform.position.y+speed * Time.deltaTime, transform.position.z);
        }
       	if(Input.GetKey(KeyCode.S) && stairsCollision)
        {
           this.transform.position = new Vector3(transform.position.x, transform.position.y-speed * Time.deltaTime, transform.position.z);
        }
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0);
    	//rb.AddForce(movement * speed);
    }

    public void fall()
    {
		//if (this.transform.position.y >= alturaSalto && isJumping) // Si no esta tocando la escalera OR si no esta tocando el piso 
        if ((!isGrounded && deltaSalto >= alturaSalto && isJumping) || (!isGrounded  && !stairsCollision && !isJumping) )
        {
            isFalling = true;
        }

        if (isFalling)
        {
            rb.AddForce(0, fallForce, 0, ForceMode.Impulse);
        }
    }

    public void jump()
    {
        if (isGrounded)
        {
            if ( Input.GetKey(KeyCode.Space))
            {
            	isJumping = true;
            	alturaDeSaltoInicial = this.transform.position.y;            	
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                //rb.velocity = Vector3.up * jumpForce;
            }
        }

        if(isJumping){
         	alturaSaltoActual = this.transform.position.y;
        }
        deltaSalto = alturaSaltoActual - alturaDeSaltoInicial;
    }

 


    void OnTriggerStay(Collider other){

        if (other.gameObject.tag == "Stairs")
        {
            stairsCollision = true;
            isFalling = false;
            rb.useGravity = false;
            //rb.useGravity = false;
        }
        if (other.gameObject.layer == 10)//Layer 10 es el empujador de la camara Back
        {
            collisionEmpujeBack = true;        
        }
        if (other.gameObject.layer == 12)//Layer 10 es el empujador de la camara Back
        {
            collisionEmpujeBack = true;
        }
    }

        void OnTriggerExit(Collider other){

        if (other.gameObject.tag == "Stairs")
        {
            stairsCollision = false;
            rb.useGravity = true;
        }
        if (other.gameObject.layer == 10){
            collisionEmpujeBack = false;
        }
    }

    public void muerte(){
        //print("MURIO EL PLAYER");
        if (_onPlayerDeath != null)
        {
            _onPlayerDeath();
        }
    }
   

    //void OnTriggerEnter(Collider other){
//
    //     if (other.gameObject.layer == 10){ //Layer 10 es el empujador de la camara
    //     	collisionEmpujeBack = true;
    //          //this.transform.position = new Vector3(transform.position.x + 10 * Time.deltaTime, transform.position.y, transform.position.z);
    //          //this.transform.Translate(-20 * transform.right * Time.deltaTime);
//
    //     }
  	//}



}

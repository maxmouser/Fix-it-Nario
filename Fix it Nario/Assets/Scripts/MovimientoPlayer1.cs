using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovimientoPlayer1 : MonoBehaviour
{


    public Rigidbody rb;

    public float speed = 0.5f;

    public bool pause = true;

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

    public Animator anim;
	public Action _onPlayerDeath;
    public Action _onWin;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        //if (!pause)
        {
            
            fall();
            jump();
            movimientoHorizontal();
            chequeoMuerte();
        }
    }

    
  
    public void movimientoHorizontal(){


       if(Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Camina", true);
            this.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z );
        }

       else if(Input.GetKey(KeyCode.A) && !collisionEmpujeBack)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Camina", true);
            this.transform.position = new Vector3(transform.position.x + (-speed) * Time.deltaTime, transform.position.y, transform.position.z);

            
           //this.transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

       	else if(Input.GetKey(KeyCode.W) && stairsCollision)
        {
            anim.SetBool("Escalar", true);
            anim.SetBool("Idle", false);
            anim.SetBool("Camina", false);
            this.transform.position = new Vector3(transform.position.x, transform.position.y+speed * Time.deltaTime, transform.position.z);
        }
       	else if(Input.GetKey(KeyCode.S) && stairsCollision)
        {
            anim.SetBool("Escalar", true);
            anim.SetBool("Idle", false);
            anim.SetBool("Camina", false);
            this.transform.position = new Vector3(transform.position.x, transform.position.y-speed * Time.deltaTime, transform.position.z);
        }
        else if ((Input.GetKeyDown(KeyCode.LeftControl) && isGrounded) || (Input.GetKeyDown(KeyCode.LeftShift)))
        {
            //SE ACTIVA CABEZAZO
            anim.SetBool("Head", true);
            anim.SetBool("Camina", false);
            anim.SetBool("Escalar", false);
            anim.SetBool("Idle", false);
        }
        else
        {
            //SE ACTIVA IDLE            
            anim.SetBool("Idle", true);
            anim.SetBool("Head", false);
            anim.SetBool("Escalar", false);
            anim.SetBool("Camina", false);
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
                anim.SetBool("Salta", true);
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

        if (other.gameObject.tag == "Stairs" && !isJumping)
        {
            anim.SetBool("Escalar", true);
            //anim.SetBool("Camina", false);
            //anim.SetBool("Idle", true);
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
            colisionEmpujeFront = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Stairs")
        {
            stairsCollision = false;
            rb.useGravity = true;
            anim.SetBool("Escalar", false);
            anim.SetBool("Idle", true);
        }
        //if (other.gameObject.layer == 10){
        //    collisionEmpujeBack = false;
        //}
        //if (other.gameObject.layer == 12)
        //{
        //    collisionEmpujeBack = false;
        //}
    }

    public void chequeoMuerte() //Esta funcion chequea si lo chocan 2 objetos a la vez
    {
        //if()

    }

    public void muerte(){
        //print("MURIO EL PLAYER");
        if (_onPlayerDeath != null)
        {
            _onPlayerDeath();
        }
    }  

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer1 : MonoBehaviour
{


    public Rigidbody rb;

    public float speed = 0.5f;

    public float jumpForce = 20;

    public float alturaSalto= 5;

    public float fallForce=-5;

    public bool isFalling= false;
    public bool isGrounded;
    public bool stairsCollision = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        fall();
 		jump();
 		movimientoHorizontal();

    }

        void Update()
    {
		//GetComponent<Animation>().Play("Idle");


    }

    public void movimientoHorizontal(){


       if(Input.GetKey(KeyCode.D))
        {
            //this.transform.Translate(speed, 0.0f, 0.0f);
            //Transform.position = oldPosition;
           this.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z );

        }

       if(Input.GetKey(KeyCode.A))
        {
            //this.transform.Translate(speed, 0.0f, 0.0f);
            //Transform.position = oldPosition;
           this.transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

        }

       	if(Input.GetKey(KeyCode.W) && stairsCollision)
        {
            //this.transform.Translate(speed, 0.0f, 0.0f);
            //Transform.position = oldPosition;
           this.transform.position = new Vector3(transform.position.x, transform.position.y+speed * Time.deltaTime, transform.position.z);

        }
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0);
    	//rb.AddForce(movement * speed);
    }

    public void fall()
    {
		if (this.transform.position.y >= alturaSalto)
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
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                //rb.velocity = Vector3.up * jumpForce;
            }
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            isFalling = false;
        }

    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
        
    }


    void OnTriggerStay(Collider other){

        if (other.gameObject.tag == "Stairs")
        {
            stairsCollision = true;
            isFalling = false;
            rb.useGravity = false;
        }
    }

    void OnTriggerExit(Collider other){

        if (other.gameObject.tag == "Stairs")
        {
            stairsCollision = false;
            rb.useGravity = true;
        }
    }





}

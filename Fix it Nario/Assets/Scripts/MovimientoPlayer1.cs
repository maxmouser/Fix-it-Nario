using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer1 : MonoBehaviour
{

    [Range(0, 1)]
    public float speed = 0.5f;

    public float alturaSalto= 5;
    public Rigidbody rb;

    [Range(1, 100)]
    public float jumpForce = 20;
    public float fallForce=-5;

    public bool isFalling= false;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        fall();
 		jump();
 		movimientoHorizontal();
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0);


        //transform.position = movement;
        //rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime);
    }

        void Update()
    {
        //Vector3 desiredVelocity = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        //rb.velocity = Vector3.Lerp(rb.velocity, desiredVelocity, Time.deltaTime * 5f);

		//GetComponent<Animation>().Play("Idle");

       

        if (this.transform.position.y >= alturaSalto)
        {
            isFalling = true;
        }



    }

    public void movimientoHorizontal(){


       if(Input.GetKey(KeyCode.D))
        {
            //this.transform.Translate(speed, 0.0f, 0.0f);
            //Transform.position = oldPosition;
           this.transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z );

        }

       if(Input.GetKey(KeyCode.A))
        {
            //this.transform.Translate(speed, 0.0f, 0.0f);
            //Transform.position = oldPosition;
           this.transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z );

        }
        //float moveHorizontal = Input.GetAxis("Horizontal");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0);

    	//rb.AddForce(movement * speed);
    }

    public void fall()
    {
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
            	print("salto");
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


}

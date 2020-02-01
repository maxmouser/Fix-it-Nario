using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer1 : MonoBehaviour
{

    [Range(1, 100)]
    public int speed = 50;

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
    }

        void Update()
    {
        //Vector3 desiredVelocity = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        //rb.velocity = Vector3.Lerp(rb.velocity, desiredVelocity, Time.deltaTime * 5f);

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0);
        jump();

        if (this.transform.position.y >= alturaSalto)
        {
            isFalling = true;
        }


        rb.AddForce(movement * speed);

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
            if (Input.GetButtonDown("Jump"))
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


}

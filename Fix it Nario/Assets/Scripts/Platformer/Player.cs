using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*public enum PlayerStatus
{
    Ground,
    Grabed,
    Jumping
}*/

public class Player : MonoBehaviour
{


    public Rigidbody rb;
    public Animator anim;

    public float speed = 0.5f;

    public bool pause = true;

    public float jumpForce = 20;
    public float alturaSalto= 5;
	public float alturaDeSaltoInicial;
	public float deltaSalto;
    public float fallForce=-5;
    public bool stairsCollision = false;


   
    
	public Action _onPlayerDeath;
    public Action _onWin;

    public GameObject _feetPosition;

    public PlayerStatus playerStatus;

    private void Start()
    {
        PlayAnimation("Idle");
    }

    private void SetPlayerStatus(PlayerStatus newStatus)
    {
        playerStatus = newStatus;
    }


    private void Update()
    {
        ResolveFeetCollision();
        Jump();
        TuVieja();
        ResolveAnimation();
    }

    private Collider[] _colliderFeet;
    

    private void ResolveFeetCollision()
    {
        _colliderFeet = Physics.OverlapBox(_feetPosition.transform.position, _feetPosition.transform.localScale / 4);
        bool foundGround = false;
        bool foundStairs = false;
        for (int i = 0; i < _colliderFeet.Length; i++)
        {
            if (_colliderFeet[i].gameObject.tag == "Ground")
            {
                foundGround = true;
                break;
            }

            if (!foundStairs && _colliderFeet[i].gameObject.layer == Constants.STAIRS_LAYER)
            {
                foundStairs = true;
            }
            
        }

        if (foundGround)
        {
            if (playerStatus != PlayerStatus.Grabed)
            {
                SetGround();
            }
        }
        else if (foundStairs && !stairsCollision)
        {
            SetGround();
        }

        if (!stairsCollision && playerStatus == PlayerStatus.Grabed)
        {
            SetPlayerStatus(PlayerStatus.Ground);
        }
    }

    float _verticalStairsMagnitude;
    float _horizontalMoveMagnitude;

    void TuVieja()
    {
       // if (pause) return;

        chequeoMuerte();

        Vector3 horizontalMoveDirection = GetHorizontalMoveDirection();
        Vector3 verticalStairsMoveDirection = GetStairsVerticalMoveDirection();

        _verticalStairsMagnitude = verticalStairsMoveDirection.magnitude;
        _horizontalMoveMagnitude = horizontalMoveDirection.magnitude;

        if (_verticalStairsMagnitude != 0 )
        {
            SetPlayerStatus(PlayerStatus.Grabed);
            horizontalMoveDirection = Vector3.zero;
        }

        ResolveGravity();
        moveDirection = horizontalMoveDirection + verticalStairsMoveDirection;
      
    }

    

    private Vector3 GetHorizontalMoveDirection()
    {
        return Vector3.right * Input.GetAxis("Horizontal");
    }

    private Vector3 GetStairsVerticalMoveDirection()
    {
        //For now only in the stairs
        if (stairsCollision)
        {
            return Vector3.up * Input.GetAxis("Vertical");
        }
        return Vector3.zero;
    }

    private void FixedUpdate()
    {
        ApplyRigidBodyMove();
    }

    private void ApplyRigidBodyMove()
    {
        rb.MovePosition(transform.position + (moveDirection * speed) * Time.fixedDeltaTime);
    }

    private void ResolveAnimation()
    {
        if (_verticalStairsMagnitude != 0)
        {
            PlayAnimation("Escalar");
        }
        else if (_horizontalMoveMagnitude != 0)
        {
            PlayAnimation("Camina");
        }
        else
        {
            PlayAnimation("Idle");
        }
    }

    private void ResolveGravity()
    {
        rb.useGravity = playerStatus != PlayerStatus.Grabed;
    }


    public AudioClip jumpFX;
    private Vector3 moveDirection;

    public void Jump()
    {

        if (playerStatus != PlayerStatus.Jumping)
        {
            if (Input.GetButtonDown("Jump"))
            {
                SetPlayerStatus(PlayerStatus.Jumping);
                deltaSalto = 0;
                alturaDeSaltoInicial = this.transform.position.y;
                //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                Vector3 act = rb.velocity;
                act.y = jumpForce;
                rb.velocity = act;  

                Constants.AUDIO_MANAGER.PlayFx(jumpFX, 1);
            }
        }
    }

    
    public void SetGround()
    {
        /*Vector3 newV = rb.velocity;
        newV.y = 0;
        rb.velocity = newV;*/
        playerStatus = PlayerStatus.Ground;       
    }
 


    void OnTriggerStay(Collider other)
    {
        stairsCollision = other.gameObject.layer == Constants.STAIRS_LAYER;
    }

    void OnTriggerExit(Collider other)
    {
        stairsCollision = !(other.gameObject.layer == Constants.STAIRS_LAYER);
    }

    public void chequeoMuerte() //Esta funcion chequea si lo chocan 2 objetos a la vez
    {
		/*if (colisionEmpujeFront && collisionEmpujeBack)
		{
            muerte();
		}*/

    }

    public void muerte(){
        //print("MURIO EL PLAYER");
        if (_onPlayerDeath != null)
        {
            _onPlayerDeath();
        }
    }


    private string _currentAnimation;



    private void PlayAnimation(string newAnimation)
    {
        if (_currentAnimation != newAnimation)
        {
            /*
            Reference            
            anim.SetBool("Idle", true);
            anim.SetBool("Head", false);
            anim.SetBool("Escalar", false);
            anim.SetBool("Camina", false);
            anim.SetBool("Salta", true);
            anim.SetBool("Camina", true);
            */

            anim.SetBool(_currentAnimation, false);
            anim.SetBool(newAnimation, true);
            _currentAnimation = newAnimation;
        }
    }
}

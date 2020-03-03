using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum PlayerStatus
{
    Ground,
    Grabed,
    Jumping,
    Falling
}

public class PlayerCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController _controller;
    public Animator anim;
    public Action _onPlayerDeath;
    public Action _onWin;
    public GameObject _feetPosition;

    public PlayerStatus playerStatus;

    public float speed = 0.5f;
    public bool pause = true;
    public float jumpForce = 20;
    public float alturaSalto = 5;
    public float alturaDeSaltoInicial;
    public float deltaSalto;
    public float fallForce = -5;
    public bool stairsCollision = false;

    public float number;


    private void Start()
    {

        _currentAnimation = "Idle";
        PlayAnimation("Idle");
    }

    private void SetPlayerStatus(PlayerStatus newStatus)
    {
        playerStatus = newStatus;
    }


    private void Update()
    {
        //Debug.Log(Mathf.Sqrt(number));
        //return;
        if (pause) return;

        chequeoMuerte();
        ResolveFeetCollision();

        
        ResolveMoveDirection();
        Jump();
        ResolveAnimation();
        MovePlayer();
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
            }

            if (!foundStairs && _colliderFeet[i].gameObject.layer == Constants.STAIRS_LAYER)
            {
                foundStairs = true;
            }

        }

        if (playerStatus != PlayerStatus.Jumping)
        {
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
            else if (!stairsCollision && playerStatus == PlayerStatus.Grabed)
            {
                SetGround();
            }
            else
            {
                SetPlayerStatus(PlayerStatus.Falling);
            }
        }
    }

    float _verticalStairsMagnitude;
    float _horizontalMoveMagnitude;

    private void SetGround()
    {
        SetPlayerStatus(PlayerStatus.Ground);
        moveDirection.y = 0;
    }

    void ResolveMoveDirection()
    {
        moveDirection.x = 0;
        Vector3 horizontalMoveDirection = GetHorizontalMoveDirection();
        Vector3 verticalStairsMoveDirection = GetStairsVerticalMoveDirection();

        _verticalStairsMagnitude = verticalStairsMoveDirection.magnitude;
        _horizontalMoveMagnitude = horizontalMoveDirection.magnitude;

        if (_verticalStairsMagnitude != 0)
        {
            SetPlayerStatus(PlayerStatus.Grabed);
        }

        moveDirection = (horizontalMoveDirection + verticalStairsMoveDirection) * speed;
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

    private void MovePlayer()
    {
        
        if (playerStatus == PlayerStatus.Falling)
        {
            moveDirection.y += Physics.gravity.y * fallForce;
        }

        if (moveDirection != Vector3.zero)
        {
            _controller.Move(moveDirection * Time.deltaTime);
        }

       
    }





    public AudioClip jumpFX;
    public Vector3 moveDirection;
    public float targetJump;
    public float hightJump;
    public float startJumpTimeStamp;

    public void Jump()
    {

        float moveJump = Physics.gravity.y * (Time.time - startJumpTimeStamp) + jumpForce;
        Debug.Log(moveJump);

        if (playerStatus == PlayerStatus.Ground || playerStatus == PlayerStatus.Grabed)
        {
            if (Input.GetButtonDown("Jump"))
            {
                SetPlayerStatus(PlayerStatus.Jumping);
                targetJump = this.transform.position.y + hightJump;
                moveDirection.y += jumpForce * 2;
                startJumpTimeStamp = Time.time;
                Constants.AUDIO_MANAGER.PlayFx(jumpFX, 1);
            }
        }

        if (playerStatus == PlayerStatus.Jumping)
        {
            if (this.transform.position.y >= targetJump)
            {
                this.transform.position = new Vector3(this.transform.position.x, targetJump, this.transform.position.z);
                SetPlayerStatus(PlayerStatus.Falling);
            }
            else if (Input.GetButton("Jump"))
            {
                Vector3 bef = moveDirection;

                if ((this.transform.position.y + moveJump) * Time.deltaTime > targetJump)
                {
                    moveDirection.y = targetJump - moveJump;
                }
                else
                {
                    moveDirection.y += moveJump;
                }
            }
            else
            {
                SetPlayerStatus(PlayerStatus.Falling);
            }
        }
        
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

    public void muerte()
    {
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
            anim.SetBool(_currentAnimation, false);
            anim.SetBool(newAnimation, true);
            _currentAnimation = newAnimation;
        }
    }
}


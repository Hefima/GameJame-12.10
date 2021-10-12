using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [Header("References")]
    public Rigidbody rb;
    public Animator anim;

    [Header("Variables")]
    public float horizontal;
    public float vertical;
    public float moveSpeed;
    public Vector2 playerInput;

    [Header("States")]
    public bool canMove;
    public bool isGrounded;
    public bool isWalking;
    public bool isRunning;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        CheckInput();
        AnimationVariables();

        if (isGrounded)
            canMove = true;
        else
            canMove = false;

        if (playerInput.magnitude > 0.1f)
            isWalking = true;
        else
            isWalking = false;

        if (isWalking && Input.GetKey(KeyCode.LeftShift))
            isRunning = true;
        else
            isRunning = false; 
    }
    
    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if(canMove)
        {
            Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized * moveSpeed * Time.deltaTime;
            rb.velocity = moveDirection;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), 4);
        }

        if (isRunning)
            moveSpeed = 250;
        else
            moveSpeed = 150;
    }

    void CheckInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        playerInput = new Vector2(horizontal, vertical);
    }

    void AnimationVariables()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);
    }


    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player acc;

    Health playerHealth;
    public GameObject healthUI;

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

    //Interactables
    public float playerCheckradius = 1.5f;
    public bool oven;
    public bool crafting;

    public LayerMask ovenMask;
    public LayerMask craftingMask;

    void Start()
    {
        acc = this;
        playerHealth = this.GetComponent<Health>();

        Cursor.lockState = CursorLockMode.Locked;
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


        if (Input.GetKeyDown(KeyCode.I))
            Inventory.acc.ToggleInv();

        HandleFood();

        oven = Physics.CheckSphere(this.transform.position, playerCheckradius, ovenMask);
        crafting = Physics.CheckSphere(this.transform.position, playerCheckradius, craftingMask);

    }
    
    private void FixedUpdate()
    {
        Movement();
    }

    public void CheckHealth()
    {
        if (playerHealth.health == 3)
        {
            healthUI.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (playerHealth.health == 2)
        {
            healthUI.transform.GetChild(2).gameObject.SetActive(false);
            healthUI.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (playerHealth.health == 1)
        {
            healthUI.transform.GetChild(1).gameObject.SetActive(false);
            healthUI.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(playerHealth.health == 0)
        {
            healthUI.transform.GetChild(0).gameObject.SetActive(false);
            Debug.LogError("YOU DIED");
        }
    }

    void Movement()
    {
        if(canMove)
        {
            Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized * moveSpeed * Time.deltaTime;
            rb.velocity = moveDirection;
            if (playerInput.magnitude > 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), 4);
            }
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

    void HandleFood()
    {

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            Inventory.acc.CollectItem(other.GetComponent<ItemHolder>().holderItem);
            Destroy(other.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(this.transform.position, playerCheckradius);
    }
}

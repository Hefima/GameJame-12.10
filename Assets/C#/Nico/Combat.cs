using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator anim;

    public bool isAttacking;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Player.instance.moveSpeed = 0;
        anim.Play("a_box");
        isAttacking = true;
    }

    public void ResetBool()
    {
        Player.instance.moveSpeed = 150;
        isAttacking = false;
    }

    void CheckInput()
    {
        anim.SetBool("isAttacking", isAttacking);
    }
}

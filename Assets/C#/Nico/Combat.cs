using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator anim;

    public bool isAttacking;
    public float attack;
    public float attackRange;

    public GameObject attackPoint;
    public LayerMask hitLayer;

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
        if(attack == 0)
        {
            anim.Play("a_box");
            isAttacking = true;
            attack++;

            Collider[] hitObjects = Physics.OverlapSphere(attackPoint.transform.position, attackRange, hitLayer);

            foreach (Collider enemy in hitObjects)
            {
               enemy.gameObject.GetComponent<Health>().LoseHealth(1);
            }
        }
    }

    public void ResetBool()
    {
        isAttacking = false;
        attack = 0;
    }

    void CheckInput()
    {
        anim.SetBool("isAttacking", isAttacking);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
}

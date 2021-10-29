using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using HefimaLibrary;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent navMesh;
    public GameObject enemyObj;

    public Transform startPos;

    public float moveRadius;
    public float attackRadius;
    public float stopDis;

    public float playerSearchRadius;
    public LayerMask playerMask;

    public float stopTime;
    float nextMoveTime;
    public bool moving;
    public bool attacking;

    //Attacking
    public GameObject attackPoint;
    public float attackRange;
    public LayerMask hitLayer;

    float nextAttack;
    public float attackCD;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        enemyObj = this.gameObject;
        startPos = this.transform;

        nextAttack = Time.time;
    }

    private void FixedUpdate()
    {
        if (!moving && Time.time >= nextMoveTime)
        {
            MoveEnemy();
        }

        if (moving && navMesh.remainingDistance <= stopDis)
        {
            nextMoveTime = Time.time + Random.Range(0, stopTime);
            moving = false;
        }

        if (attacking && navMesh.remainingDistance < 0.5f && Time.time >= nextAttack)
        {
            Attack();
        }
    }
    
    void Attack()
    {
        print("attack");
        nextAttack = Time.time + attackCD;
         
        Collider[] hitObjects = Physics.OverlapSphere(attackPoint.transform.position, attackRange, hitLayer);

        for (int i = 0; i < hitObjects.Length; i++)
        {
            hitObjects[i].gameObject.GetComponent<Health>().LoseHealth(1);
            return;
        }
    }

    void MoveEnemy()
    {
        moving = true;
        navMesh.SetDestination(HefiMath.RandomVector3_Plane(moveRadius, startPos.position));
    }

    /*void SearchPlayer()
    {
        Collider[] foundPlayer = Physics.OverlapSphere(enemyObj.transform.position, playerSearchRadius, playerMask);

        if(foundPlayer.Length > 5)
        {
            print("FoundPlayer");
            //attackPlayer 
            AttackPlayer(foundPlayer[foundPlayer.Length].transform);
        }
    }*/

    void AttackPlayer(Transform player)
    {
        moving = true;
        attacking = true;
        navMesh.SetDestination(new Vector3(player.transform.position.x , player.transform.position.y, player.transform.position.z));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(enemyObj.transform.position, playerSearchRadius);
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            print("FoundPlayer");
            //attackPlayer 
            AttackPlayer(other.transform);
        }
    }
}

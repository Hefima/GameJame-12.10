using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Health thisHealth;
    public int coinValue;

    private void Start()
    {
        thisHealth = GetComponent<Health>();
    }

    private void Update()
    {
        if (thisHealth.dead)
        {
            Instantiate(this.GetComponent<ItemHolder>().holderItem.mesh, this.transform.position, this.transform.rotation);
            PlayerManager.acc.CM.coins += coinValue;
            Destroy(this.gameObject);
        }
    }
}

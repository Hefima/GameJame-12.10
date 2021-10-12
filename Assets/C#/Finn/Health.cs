using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public bool dead;

    private void Start()
    {
        health = maxHealth;
        dead = false;
    }

    public void LoseHealth(int damage)
    {
        health -= damage;

        CheckDeath();
    }

    public void GetHealth(int heal)
    {
        health += heal;
    }

    void CheckDeath()
    {
        if(health >= 0)
        {
            dead = true;
        }
    }
}

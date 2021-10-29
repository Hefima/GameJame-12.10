using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodController : MonoBehaviour
{
    Health playerHealth;

    public float MaxFood;
    public float food;

    public float foodTick;
    public float foodTickCD;
    float nextTick;

    public Slider foodSlider;

    private void Start()
    {
        playerHealth = this.GetComponent<Health>();

        food = MaxFood;
        nextTick = Time.time + foodTickCD;
    }

    private void Update()
    {
        foodSlider.value = food;

        if (food > 0 && Time.time >= nextTick)
        {
            food -= foodTick;
            nextTick = Time.time + foodTickCD;

            if (food > 0.9)
                playerHealth.GetHealth(1);

            if (food < 0)
                food = 0;
        }
        else if(food <= 0 && Time.time >= nextTick)
        {
            playerHealth.LoseHealth(1);
            nextTick = Time.time + foodTickCD;
        }
    }

    public void AddFood(float add)
    {
        food += add;
        PlayerManager.acc.PH.GetHealth(1);
        if (food > MaxFood)
            food = MaxFood;
    }
}

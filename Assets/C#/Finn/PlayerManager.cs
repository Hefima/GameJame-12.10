using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager acc;

    public Player PL;
    public Combat PC;
    public Health PH;
    public FoodController PF;

    private void Awake()
    {
        acc = this;
    }
}

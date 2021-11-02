using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemClass
{
    none,
    food,
    ressource
}

[System.Serializable]
public struct Item
{
    public ItemClass itemClass;

    public float foodAmount;
    public bool foodUncooked;
    public GameObject foodCoocked;

    public string itemName;
    public GameObject mesh;
    public Sprite image;

    public int coinValue;
}

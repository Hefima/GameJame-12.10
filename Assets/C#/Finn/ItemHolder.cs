using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public Item holderItem;

    public static ItemHolder acc;

    private void Awake()
    {
        acc = this;
    }
}

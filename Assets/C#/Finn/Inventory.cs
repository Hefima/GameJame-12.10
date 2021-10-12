using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    List<Item> invItems = new List<Item>();

    public GameObject inventory;
    public GameObject itemPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CollectItem(ItemHolder.acc.holderItem);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            RemoveItem(0);
        }
    }

    public void CollectItem(Item item)
    {
        invItems.Add(item);

        GameObject g = Instantiate(itemPrefab, inventory.transform);
        g.transform.GetChild(1).transform.GetComponent<Text>().text = item.itemName;
    }

    public void RemoveItem(int i)
    {
        invItems.RemoveAt(i);
        Destroy(inventory.transform.GetChild(i).gameObject);
    }
}

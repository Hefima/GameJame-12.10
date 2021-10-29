using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory acc;
    List<Item> invItems = new List<Item>();

    public GameObject inventory;
    public GameObject inventoryUI;
    public GameObject itemPrefab;

    private void Awake()
    {
        acc = this;
    }

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
        if(item.image != null)
            g.transform.GetChild(0).transform.GetComponent<Image>().sprite = item.image;

        g.GetComponent<itemSlot>().slotItem = item;
    }

    public void RemoveItem(int i)
    {
        invItems.RemoveAt(i);
        Destroy(inventory.transform.GetChild(i).gameObject);
    }

    public void ToggleInv()
    {
        if (inventoryUI.activeInHierarchy)
        {
            inventoryUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            inventoryUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

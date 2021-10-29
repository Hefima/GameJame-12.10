using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemSlot : MonoBehaviour
{
    public Button thisButton;
    public Item slotItem;

    private void Start()
    {
        thisButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        switch (slotItem.itemClass)
        {
            case ItemClass.food:
                if (PlayerManager.acc.PL.oven && slotItem.foodUncooked)
                {
                    Inventory.acc.CollectItem(slotItem.foodCoocked.GetComponent<ItemHolder>().holderItem);
                    Destroy(this.gameObject);
                }
                else if(slotItem.itemClass == ItemClass.food && PlayerManager.acc.PF.food < PlayerManager.acc.PF.MaxFood || slotItem.itemClass == ItemClass.food && PlayerManager.acc.PH.health < PlayerManager.acc.PH.maxHealth)
                {
                    PlayerManager.acc.PF.AddFood(slotItem.foodAmount);
                    Destroy(this.gameObject);
                }
                break;
            case ItemClass.ressource:
                break;
        }
    }
}

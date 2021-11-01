using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject newIsland;
    public GameObject Panel;
    public GameObject text;

    public bool isTalking;
    public bool inRange;

    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleBool();
        }

        if (isTalking)
        {
            Cursor.lockState = CursorLockMode.None;
            text.SetActive(false);
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
            inRange = false;
        }
    }

    void ToggleBool()
    {
        isTalking = !isTalking;
    }

    public void BuyIsland()
    {
        if(CoinManager.acc.coins >= 100)
        {
            newIsland.SetActive(true);
            CoinManager.acc.coins -= 100;
        }
        else
        {
            Debug.Log("You do not have enough Coins!");
        }
    }
}

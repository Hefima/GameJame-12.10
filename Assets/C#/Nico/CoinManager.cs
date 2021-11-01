using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager acc;

    public Text coinsValue;
    public int coins;

    private void Start()
    {
        acc = this;
    }

    private void Update()
    {
        coinsValue.text = ": " + coins;
    }
}

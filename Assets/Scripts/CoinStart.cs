using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinStart : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countCoin;
    void Start()
    {
        countCoin.SetText(GameManager.Instance.CoinBag.ToString());
    }
}

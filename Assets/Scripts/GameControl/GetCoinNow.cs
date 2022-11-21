using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetCoinNow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    void Awake()
    {
        text.text = GameManager.Instance.CoinBag.ToString();
    }
}

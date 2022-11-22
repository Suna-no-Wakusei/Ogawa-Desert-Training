using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetCoinNow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    void Start()
    {
        text.SetText(GameManager.Instance.CoinBag.ToString());
    }
}

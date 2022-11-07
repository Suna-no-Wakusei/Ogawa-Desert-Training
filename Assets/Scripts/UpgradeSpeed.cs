using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSpeed : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI price;
    [SerializeField] TextMeshProUGUI count;

    void Awake()
    {
        if (GameManager.Instance.SpeedModifier >= 10)
        {
            price.text = "1000";
        }
        else
        {
            price.text = ((GameManager.Instance.SpeedModifier + 1) * 100).ToString();
        }
    }

    public void Compra()
    {
        if (GameManager.Instance.SpeedModifier >= 10)
        {
            if (GameManager.Instance.CoinBag >= 1000)
            {
                GameManager.Instance.CoinBag -= 1000;
                count.text = GameManager.Instance.CoinBag.ToString();
                GameManager.Instance.SpeedModifier++;
                PlayerPrefs.SetInt("SpeedModifier", GameManager.Instance.SpeedModifier);
                //playsound
            }
        }
        else
        {
            if (GameManager.Instance.CoinBag >= (GameManager.Instance.SpeedModifier + 1) * 100)
            {
                GameManager.Instance.SpeedModifier++;
                PlayerPrefs.SetInt("SpeedModifier", GameManager.Instance.SpeedModifier);
                GameManager.Instance.CoinBag -= GameManager.Instance.SpeedModifier * 100;
                count.text = GameManager.Instance.CoinBag.ToString();
                //playsound
                price.text = (GameManager.Instance.SpeedModifier++ * 100).ToString();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMaxStamina : MonoBehaviour
{
    [SerializeField] GameObject[] upsButtons;
    [SerializeField] TextMeshProUGUI coinBag;
    Color32 comprado = new Color32(100, 100, 100, 255);

void Awake()
    {
        switch (GameManager.Instance.MaxStamina)
        {
            case 30:
                foreach (Image childImage in upsButtons[0].GetComponentsInChildren<Image>())
                {
                    childImage.color = comprado;
                }
                upsButtons[0].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                break;
            case 50:
                foreach (Image childImage in upsButtons[0].GetComponentsInChildren<Image>())
                {
                    childImage.color = comprado;
                }
                foreach (Image childImage in upsButtons[1].GetComponentsInChildren<Image>())
                {
                    childImage.color = comprado;
                }
                upsButtons[0].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                upsButtons[1].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                break;
            case 60:
                foreach (Image childImage in upsButtons[0].GetComponentsInChildren<Image>())
                {
                    childImage.color = comprado;
                }
                foreach (Image childImage in upsButtons[1].GetComponentsInChildren<Image>())
                {
                    childImage.color = comprado;
                }
                foreach (Image childImage in upsButtons[2].GetComponentsInChildren<Image>())
                {
                    childImage.color = comprado;
                }
                upsButtons[0].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                upsButtons[1].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                upsButtons[2].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                break;
            default:
                break;
        }
    }
    public void Compra()
    {
        switch (GameManager.Instance.MaxStamina)
        {
            case 20:
                if (GameManager.Instance.CoinBag >= 200)
                {
                    GameManager.Instance.CoinBag -= 200;
                    GameManager.Instance.MaxStamina = 30;
                    PlayerPrefs.SetFloat("MaxStamina", GameManager.Instance.MaxStamina);
                    foreach (Image childImage in upsButtons[0].GetComponentsInChildren<Image>())
                    {
                        childImage.color = comprado;
                    }
                    upsButtons[0].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                }
                break;
            case 30:
                if (GameManager.Instance.CoinBag >= 500)
                {
                    GameManager.Instance.CoinBag -= 500;
                    GameManager.Instance.MaxStamina = 40;
                    PlayerPrefs.SetFloat("MaxStamina", GameManager.Instance.MaxStamina);
                    foreach (Image childImage in upsButtons[1].GetComponentsInChildren<Image>())
                    {
                        childImage.color = comprado;
                    }
                    upsButtons[1].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                }
                break;
            case 40:
                if (GameManager.Instance.CoinBag >= 1000)
                {
                    GameManager.Instance.CoinBag -= 1000;
                    GameManager.Instance.MaxStamina = 50;
                    PlayerPrefs.SetFloat("MaxStamina", GameManager.Instance.MaxStamina);
                    foreach (Image childImage in upsButtons[2].GetComponentsInChildren<Image>())
                    {
                        childImage.color = comprado;
                    }
                    upsButtons[2].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                }
                break;
            default:
                break;
        }
        coinBag.text = GameManager.Instance.CoinBag.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class UpgradeMaxStamina : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject[] upsButtons;
    [SerializeField] TextMeshProUGUI coinBag;
    [SerializeField] AudioClip clip;
    [SerializeField] float holdTime = .2f;
    [SerializeField] GameObject PopUp;
    Color32 comprado = new Color32(100, 100, 100, 255);

    public UnityEvent onLongPress = new UnityEvent();
    public UnityEvent pressOff = new UnityEvent();

    void Awake()
    {
        onLongPress.AddListener(PopItUp);
        pressOff.AddListener(PopItDown);
        switch (GameManager.Instance.MaxStamina)
        {
            case 30:
                foreach (Image childImage in upsButtons[0].GetComponentsInChildren<Image>())
                {
                    childImage.color = comprado;
                }
                upsButtons[0].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                break;
            case 40:
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
            case 50:
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
                    SoundManager.Instance.PlaySound(clip);
                    GameManager.Instance.CoinBag -= 200;
                    GameManager.Instance.MaxStamina = 30;
                    PlayerPrefs.SetInt("MaxStamina", GameManager.Instance.MaxStamina);
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
                    SoundManager.Instance.PlaySound(clip);
                    GameManager.Instance.CoinBag -= 500;
                    GameManager.Instance.MaxStamina = 40;
                    PlayerPrefs.SetInt("MaxStamina", GameManager.Instance.MaxStamina);
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
                    SoundManager.Instance.PlaySound(clip);
                    GameManager.Instance.CoinBag -= 1000;
                    GameManager.Instance.MaxStamina = 50;
                    PlayerPrefs.SetInt("MaxStamina", GameManager.Instance.MaxStamina);
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

    public void OnPointerDown(PointerEventData eventData)
    {
        Invoke("OnLongPress", holdTime);
        pressOff.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");
        pressOff.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");
        pressOff.Invoke();
    }

    void OnLongPress()
    {
        onLongPress.Invoke();
    }

    void PopItUp()
    {
        PopUp.SetActive(true);
    }

    void PopItDown()
    {
        PopUp.SetActive(false);
    }

}

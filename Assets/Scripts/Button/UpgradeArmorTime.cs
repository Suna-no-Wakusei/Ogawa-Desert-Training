using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class UpgradeArmorTime : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
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
        switch (GameManager.Instance.TempoArmor)
        {
            case 7.5f:
                foreach (Image childImage in upsButtons[0].GetComponentsInChildren<Image>())
                {
                    childImage.color = comprado;
                }
                upsButtons[0].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                break;
            case 10f:
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
            case 15f:
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
        switch (GameManager.Instance.TempoArmor)
        {
            case 5f:
                if (GameManager.Instance.CoinBag >= 200)
                {
                    SoundManager.Instance.PlaySound(clip);
                    GameManager.Instance.CoinBag -= 200;
                    GameManager.Instance.TempoArmor = 7.5f;
                    PlayerPrefs.SetFloat("TempoArmor", GameManager.Instance.TempoArmor);
                    foreach (Image childImage in upsButtons[0].GetComponentsInChildren<Image>())
                    {
                        childImage.color = comprado;
                    }
                    upsButtons[0].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                }
                break;
            case 7.5f:
                if (GameManager.Instance.CoinBag >= 500)
                {
                    SoundManager.Instance.PlaySound(clip);
                    GameManager.Instance.CoinBag -= 500;
                    GameManager.Instance.TempoArmor = 10f;
                    PlayerPrefs.SetFloat("TempoArmor", GameManager.Instance.TempoArmor);
                    foreach (Image childImage in upsButtons[1].GetComponentsInChildren<Image>())
                    {
                        childImage.color = comprado;
                    }
                    upsButtons[1].GetComponentInChildren<TextMeshProUGUI>().color = comprado;
                }
                break;
            case 10f:
                if (GameManager.Instance.CoinBag >= 1000)
                {
                    SoundManager.Instance.PlaySound(clip);
                    GameManager.Instance.CoinBag -= 1000;
                    GameManager.Instance.TempoArmor = 15f;
                    PlayerPrefs.SetFloat("TempoArmor", GameManager.Instance.TempoArmor);
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

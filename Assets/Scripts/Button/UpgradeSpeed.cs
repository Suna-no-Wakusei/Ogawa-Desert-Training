using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class UpgradeSpeed : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] TextMeshProUGUI price;
    [SerializeField] TextMeshProUGUI count;
    [SerializeField] AudioClip clip;
    [SerializeField] float holdTime = .2f;
    [SerializeField] GameObject PopUp;

    public UnityEvent onLongPress = new UnityEvent();
    public UnityEvent pressOff = new UnityEvent();

    void Awake()
    {
        onLongPress.AddListener(PopItUp);
        pressOff.AddListener(PopItDown);
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
                SoundManager.Instance.PlaySound(clip);
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
                SoundManager.Instance.PlaySound(clip);
                GameManager.Instance.SpeedModifier++;
                PlayerPrefs.SetInt("SpeedModifier", GameManager.Instance.SpeedModifier);
                GameManager.Instance.CoinBag -= GameManager.Instance.SpeedModifier * 100;
                count.text = GameManager.Instance.CoinBag.ToString();
                //playsound
                price.text = (GameManager.Instance.SpeedModifier++ * 100).ToString();
            }
        }
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

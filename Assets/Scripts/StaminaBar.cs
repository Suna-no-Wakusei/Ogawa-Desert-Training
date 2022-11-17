using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private RectTransform size;

    public void SetMaxSliderStamina(float stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
        switch (stamina)
        {
            case 20:
                size.sizeDelta = new Vector2(Screen.width * 0.01f, 30);
                break;
            case 30:
                size.sizeDelta = new Vector2(Screen.width * 0.03f, 30);
                break;
            case 40:
                size.sizeDelta = new Vector2(Screen.width * 0.05f, 30);
                break;
            case 50:
                size.sizeDelta = new Vector2(Screen.width * 0.07f, 30);
                break;
            case 60:
                size.sizeDelta = new Vector2(Screen.width * 0.1f, 30);
                break;
            case 70:
                size.sizeDelta = new Vector2(Screen.width * 0.12f, 30);
                break;
            default:
                size.sizeDelta = new Vector2(Screen.width * 0.1f, 30);
                break;
        }
    }

    public void SetStamina(float stamina)
    {
        slider.value = stamina;
    }

}

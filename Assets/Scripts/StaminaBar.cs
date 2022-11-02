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
        size.sizeDelta = new Vector2(stamina*5, 30);
    }

    public void SetStamina(float stamina)
    {
        slider.value = stamina;
    }

}

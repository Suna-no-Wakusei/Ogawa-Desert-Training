using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoNoShop : MonoBehaviour
{
    [SerializeField] GameObject StartingMenu;
    [SerializeField] GameObject Shop;
    [SerializeField] AudioClip clip;
    public void HideShop()
    {
        StartingMenu.SetActive(true);
        Shop.SetActive(false);
        SoundManager.Instance.PlaySound(clip);
    }
}

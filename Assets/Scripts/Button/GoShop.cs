using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoShop : MonoBehaviour
{
    [SerializeField] GameObject StartingMenu;
    [SerializeField] GameObject Shop;
    [SerializeField] AudioClip clip;
    public void ShowShop()
    {
        StartingMenu.SetActive(false);
        Shop.SetActive(true);
        SoundManager.Instance.PlaySound(clip);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoShop : MonoBehaviour
{
    [SerializeField] GameObject StartingMenu;
    [SerializeField] GameObject Shop;
    public void ShowShop()
    {
        StartingMenu.SetActive(false);
        Shop.SetActive(true);
    }
}

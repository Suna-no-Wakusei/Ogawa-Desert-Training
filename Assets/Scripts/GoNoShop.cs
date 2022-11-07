using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoNoShop : MonoBehaviour
{
    [SerializeField] GameObject StartingMenu;
    [SerializeField] GameObject Shop;
    public void HideShop()
    {
        StartingMenu.SetActive(true);
        Shop.SetActive(false);
    }
}

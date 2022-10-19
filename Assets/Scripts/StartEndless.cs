using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndless : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject KmCount;
    [SerializeField] private GameObject CoinCount;
    [SerializeField] private GameObject CoinMoment;

    public void Bora()
    {
        startMenu.SetActive(false);
        HUD.SetActive(true);
        KmCount.SetActive(true);
        CoinMoment.SetActive(false);
        CoinCount.SetActive(true);
        GameManager.instance.IsOkToMove = true;
        Time.timeScale = 1f;
    }
}

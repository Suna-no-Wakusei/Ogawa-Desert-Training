using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRun : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject KmCount;
    [SerializeField] private GameObject CoinCount;
    [SerializeField] private GameObject CoinMoment;

    public void Bora()
    {
        GameManager.Instance.IsNotEndless = true;
        startMenu.SetActive(false);
        HUD.SetActive(true);
        CoinCount.SetActive(false);
        KmCount.SetActive(true);
        CoinMoment.SetActive(true);
        GameManager.Instance.IsOkToSpawn = true;
        GameManager.Instance.IsOkToMove = true;
        Time.timeScale = 1f;
    }
}

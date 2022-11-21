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
    [SerializeField] private PlayerController playerController;
    [SerializeField] AudioClip clip;

    public void Bora()
    {
        SoundManager.Instance.PlaySound(clip);
        GameManager.Instance.IsOnRun = true;
        GameManager.Instance.IsNotEndless = true;
        startMenu.SetActive(false);
        playerController.OnRunStart();
        HUD.SetActive(true);
        CoinCount.SetActive(false);
        KmCount.SetActive(true);
        CoinMoment.SetActive(true);
        GameManager.Instance.IsOkToSpawn = true;
        GameManager.Instance.IsOkToMove = true;
        Time.timeScale = 1f;
    }
}

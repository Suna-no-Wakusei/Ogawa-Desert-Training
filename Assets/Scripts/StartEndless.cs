using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndless : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject HUD;
    private GameManager manager;
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void Bora()
    {
        startMenu.SetActive(false);
        HUD.SetActive(true);
        manager.IsOkToMove = true;
        Debug.Log(manager.IsOkToMove.ToString());
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get 
        { 
            if (instance == null)
            {
                Debug.LogError("GameManager Null");
            }
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        instance.TopKm = PlayerPrefs.GetInt("TopKm", 0);
        instance.CoinBag = PlayerPrefs.GetInt("CoinBag", 0);
        instance.SpeedModifier = PlayerPrefs.GetInt("SpeedModifier", 1);
        instance.MaxStamina = PlayerPrefs.GetInt("MaxStamina", 20);
    }

    private int topKm;
    private int coinBag;
    private int speedModifier = 1;
    private int maxStamina = 20;
    private bool isNotEndless = false;
    private bool isOkToSpawn = false;
    private bool isOkToMove = false;
    
    public int TopKm
    {
        get { return topKm; }
        set { topKm = value; }
    }

    public int CoinBag
    {
        get { return coinBag; }
        set { coinBag = value; }
    }

    public int SpeedModifier
    {
        get { return speedModifier; }
        set { speedModifier = value; }
    }

    public int MaxStamina
    {
        get { return maxStamina; }
        set { maxStamina = value; }
    }

    public bool IsNotEndless
    {
        get { return isNotEndless; }
        set { isNotEndless = value; }
    }

    public bool IsOkToMove
    {
        get { return isOkToMove; }
        set { isOkToMove = value; }
    }
    public bool IsOkToSpawn
    {
        get { return isOkToSpawn; }
        set { isOkToSpawn = value; }
    }

}

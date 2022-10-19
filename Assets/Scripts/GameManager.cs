using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = new GameManager();
    private int topKm;
    private int coinBag;
    public bool isOkToMove = false;
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
    public bool IsOkToMove
    {
        get { return isOkToMove; }
        set { isOkToMove = value; }
    }
}

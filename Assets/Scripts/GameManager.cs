using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int floorsCena;
    private int obstaculosCena;
    private int moedasCena;
    private float km;
    private int topKm;
    private int coinCount;
    private int coinBag;
    private bool isOkToMove = false;

    public int FloorsCena
    {
        get { return floorsCena; }
        set { floorsCena = value; }
    }
    public int ObstaculosCena
    {
        get { return obstaculosCena; }
        set { obstaculosCena = value; }
    }
    public int MoedasCena
    {
        get { return moedasCena; }
        set { moedasCena = value; }
    }
    public float Km
    {
        get { return km; }
        set { km = value; }
    }
    public int TopKm
    {
        get { return topKm; }
        set { topKm = value; }
    }
    public int CoinCount
    {
        get { return coinCount; }
        set { coinCount = value; }
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

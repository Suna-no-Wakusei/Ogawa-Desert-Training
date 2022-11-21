using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    public enum UpgradeType
    {
        Armor = 1,
        CoinSack,
        Stamina,
    };
    [SerializeField] private Sprite[] spriteUpgrades;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private int rand;
    public UpgradeType upType;
    
    void Awake()
    {
        rand = Random.Range(1, 4);
        upType = (UpgradeType)rand;
        spriteRenderer.sprite = spriteUpgrades[rand-1];
    }

}

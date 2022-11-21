using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteSpawn : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteFoods;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, spriteFoods.Length-1);
        spriteRenderer.sprite = spriteFoods[rand];
    }
}

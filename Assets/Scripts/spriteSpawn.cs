using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteSpawn : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteFoods;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private int rand;
    private float seno;

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, spriteFoods.Length-1);
        spriteRenderer.sprite = spriteFoods[rand];
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y+Mathf.Sin(seno)*0.005f, transform.position.z);
        seno+=0.01f;
        if (seno>=360)
        {
            seno = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodGen : MonoBehaviour
{
    [SerializeField] private Sprite[] foodSprites;
    private int rand;
    private float seno;

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, foodSprites.Length);
        GetComponent<SpriteRenderer>().sprite = foodSprites[rand];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(seno)*0.2f, transform.position.z);
        seno+=0.01f;
        if (seno>=360)
        {
            seno = 0;
        }
    }
}

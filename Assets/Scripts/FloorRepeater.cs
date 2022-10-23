using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRepeater : MonoBehaviour
{

    [SerializeField] private GameObject[] chaos;
    private Sprite sprite;
    private int i = 0;
    private int aux = 0;
    void Start()
    {
        sprite = chaos[0].GetComponent<SpriteRenderer>().sprite;
    }
    void Update()
    {
        if (chaos[i].transform.position.x + sprite.bounds.size.x <= Camera.main.transform.position.x - Camera.main.orthographicSize * Screen.width/Screen.height)
        {
            if (i==0)
            {
                aux = chaos.Length - 1;
            }
            Vector3 newpos = new Vector3(chaos[aux].transform.position.x + sprite.bounds.size.x, chaos[i].transform.position.y, chaos[i].transform.position.z);
            chaos[i].transform.position = newpos;
            aux++;
            if (aux == chaos.Length)aux = 0;
            i++;
            if (i == chaos.Length)i = 0;
        }
    }
}

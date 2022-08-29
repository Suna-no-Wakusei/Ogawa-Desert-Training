using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsGoBrrr : MonoBehaviour
{
    private float movespeed = -0.2f;
    private GameManager manager;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if (!manager.IsOkToMove) return;
        transform.position = transform.position + new Vector3(movespeed, 0, 0);
        if (transform.position.x <= -32f)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Ground"))
            {
                manager.FloorsCena--;            
            }
            if (gameObject.CompareTag("Coin"))
            {
                manager.MoedasCena--;   
            }
            if (gameObject.CompareTag("Spike"))
            {
                manager.ObstaculosCena--;
            }
        }
    }
}

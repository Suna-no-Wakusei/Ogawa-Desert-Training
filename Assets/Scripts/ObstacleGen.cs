using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGen : MonoBehaviour
{

    [SerializeField] private GameObject[] obstacle;//chaos
    private int rand;
    private GameManager manager;
    private float tempo = 2;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    
    void Update()
    {
        tempo -= Time.deltaTime;
        if (tempo <= 0&& manager.IsOkToMove)
        {
            rand = Random.Range(0, obstacle.Length);
            Instantiate(obstacle[rand], transform.position, transform.rotation);
            tempo = 6;
        }
            
    }
}

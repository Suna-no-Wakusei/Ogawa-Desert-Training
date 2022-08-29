using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] floor;//chaos
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
            rand = Random.Range(0, floor.Length+3);
            if (rand > floor.Length-1)
            { 
                tempo = 3; 
                return;
            }
            else
            {
                Instantiate(floor[rand], transform.position, transform.rotation);
                tempo = 6;
            }
        }
            
    }

}

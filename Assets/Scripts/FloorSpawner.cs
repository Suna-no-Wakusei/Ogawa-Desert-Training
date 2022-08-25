using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    private GameManager manager;
    private float tempo = 3;
    private Vector3 offset = new Vector3(0, 4.7875f, 0);

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    
    void Update()
    {
        tempo -= Time.deltaTime;
        if (tempo <= 0 && manager.FloorsCena<5)
        {
            int rand = Random.Range(0, 3);
            if (rand == 2)
            {
                Instantiate(floor, transform.position + offset, transform.rotation);
                manager.FloorsCena++;
                tempo = 3;
            }
            Instantiate(floor, transform.position, transform.rotation);
            manager.FloorsCena++;
            tempo = 3;
        }
            
    }

    //public gameobject[] chao;
    //private int rand
    //private int lastSpawn
    //if(rand <= chao.Length && ParteLivre())
    //  instantiate(chao[rand], transform.position + offset, transform.rotation);
    //  lasSpawn = rand
    //else
    //  lastSpawn = 0;
    //bool ParteLivre()
    //  if(lastSpawn == {[(set especifico de prefabs que impedem sussies)]})
    //      falseascfjuaishyiashvyahyih amimir




}

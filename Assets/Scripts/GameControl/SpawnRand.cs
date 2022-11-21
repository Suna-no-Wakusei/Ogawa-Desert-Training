using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRand : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private float timer = 2f;
    private float timeVolta;
    private int randChance;
    private int randObj;

    void Start()
    {
        timeVolta = timer;
    }

    void Update()
    {
        if (!GameManager.Instance.IsOkToSpawn) return;
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            randChance = Random.Range(0, 2);
            if (randChance == 0)
            {
                randObj = Random.Range(0, prefab.Length);
                Instantiate(prefab[randObj], transform.position, transform.rotation);
            }
            timer = timeVolta;
        }
    }
}

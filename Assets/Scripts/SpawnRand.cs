using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRand : MonoBehaviour
{
    [SerializeField] private GameObject ruin;
    [SerializeField] private float timer = 5f;
    private float timeVolta;
    private int rand;

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
            rand = Random.Range(0, 4);
            if (rand == 3)
            {
                Instantiate(ruin, transform.position, transform.rotation);
            }
            timer = timeVolta;
        }
    }
}

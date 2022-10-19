using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRand : MonoBehaviour
{
    [SerializeField] private GameObject ruin;
    private int rand;
    private float timer = 5f;

    void Update()
    {
        if (!GameManager.instance.IsOkToMove) return;
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            rand = Random.Range(0, 4);
            if (rand == 3)
            {
                Instantiate(ruin, transform.position, transform.rotation);
                Debug.Log("Mouse");
            }
            timer = 3f;
        }
    }
}

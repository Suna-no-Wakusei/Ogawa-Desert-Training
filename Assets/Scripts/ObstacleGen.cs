using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGen : MonoBehaviour
{

    [SerializeField] private GameObject espinho;
    private float count = 2;
    private GameManager manager;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        count -= Time.deltaTime;
        if (manager.ObstaculosCena < 100 && count <= 0)
        {
            StartCoroutine(Espinho());
            count = 2;
        }
    }

    IEnumerator Espinho()
    {
        int rand = Mathf.FloorToInt(Random.Range(0, 3));
        for (int i = 0; i < rand; i++)
        {
            Instantiate(espinho, transform.position, transform.rotation);
            manager.ObstaculosCena++;
            yield return new WaitForSeconds(10f);
        }
    }
}

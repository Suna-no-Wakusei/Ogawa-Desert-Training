using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsGoBrrr : MonoBehaviour
{
    [SerializeField] private float moveSpeed = -0.2f;
    private GameManager manager;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if (!manager.IsOkToMove) return;
        transform.position = transform.position + new Vector3(moveSpeed, 0, 0);
    }
}

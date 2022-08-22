using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTr;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 offset1;
    [SerializeField] private Vector3 offset2;
    [SerializeField] private float tempo = 0.25f;
    private Vector3 atualPos, antigaPos;
    void LateUpdate()
    {
        tempo -= Time.deltaTime;
        atualPos = playerTr.position;
        if (tempo <= 0)
        {
            if (atualPos == antigaPos)
            {
                tempo = 0.25f;
            }
            if (playerRb.velocity.y > 0f)
            {
                tempo = 0.25f;
            }
            if (playerRb.velocity.y == 0f)
            {
                Vector3 posit = atualPos + offset1;
                Vector3 smoothed = Vector3.Lerp(transform.position, posit, smoothSpeed * Time.deltaTime);
                transform.position = smoothed; 
                tempo = 0.25f; 
            }
            if (playerRb.velocity.y < 0f)
            {
                Vector3 posit = atualPos + offset2;
                Vector3 smoothed = Vector3.Lerp(transform.position, posit, smoothSpeed * Time.deltaTime);
                transform.position = smoothed;
                tempo = 0.25f; 
            }
            antigaPos = playerTr.position;
        }
    }
}

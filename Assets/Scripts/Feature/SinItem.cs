using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinItem : MonoBehaviour
{
    private float seno = 0;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y+Mathf.Sin(seno)*0.005f, transform.position.z);
        seno+=0.01f;
        if (seno>=360)
        {
            seno = 0;
        }
    }
}

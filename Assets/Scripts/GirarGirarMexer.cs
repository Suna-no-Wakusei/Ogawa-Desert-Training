using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarGirarMexer : MonoBehaviour
{
    private float rotaccione = 1f;
    void FixedUpdate()
    {    
        transform.rotation = Quaternion.Euler(0, rotaccione, 0);
        rotaccione++;
    }
}

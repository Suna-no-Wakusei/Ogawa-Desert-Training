using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDown : MonoBehaviour
{
    [SerializeField] private PlatformEffector2D platEffect;
    [SerializeField] private Collider2D col;
    private Vector3 startPos;
    private bool fingerDown;
    private int pixelDistToDetect = 20;

    void Update()
    {
        int pleum = TouchSwipe();
        if (pleum == 1)
        {
            col.enabled = true;
            platEffect.rotationalOffset = 0f;
        }
        if (pleum == 2)
        {
            col.enabled = false;
        }
    }
    int TouchSwipe()
    {
        if (!fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }
        if (fingerDown)
        {
            if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect)
            {
                fingerDown = false;
                return 1;
            }
            else if (Input.touches[0].position.y <= startPos.y - pixelDistToDetect)
            {
                fingerDown = false;
                return 2;
            }
        }
        return 0;
    }
}

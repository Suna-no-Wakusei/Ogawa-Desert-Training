using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Sprite sprite;
    private Texture2D texture;
    private float camPosX;
    private float textureUnitSizeX;
    private float camSize;
    private float spriteBound;

    void Start()
    {
        camPosX = Camera.main.transform.position.x;
        sprite = GetComponent<SpriteRenderer>().sprite;
        texture = sprite.texture;
        camSize = Camera.main.orthographicSize * Screen.width / Screen.height;
        spriteBound = sprite.bounds.size.x;
    }

    void FixedUpdate()
    {
        if (!GameManager.instance.IsOkToMove) return;
        transform.position += new Vector3(-moveSpeed, 0);
        if (transform.position.x + spriteBound <= camPosX - camSize)
        {
            transform.position = new Vector3(camPosX + camSize + spriteBound, transform.position.y);
        }
    }
}

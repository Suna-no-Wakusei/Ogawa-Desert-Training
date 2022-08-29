using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int jumpForce;
    [SerializeField] private float currentStamina;
    [SerializeField] private int maxStamina;
    [SerializeField] private int staminaUpgrades;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D colGround;
    [SerializeField] private Collider2D colTotal;
    [SerializeField] private StaminaBar staminaBar;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject morte;
    [SerializeField] private TextMeshProUGUI countCoin;
    [SerializeField] private TextMeshProUGUI countKm;
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    private bool isGrounded = false;
    private GameManager manager;
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void Start()
    {
        switch (staminaUpgrades)
        {
            case 0:
                maxStamina = 20;
                break;
            case 1:
                maxStamina = 25;
                break;
            case 2:
                maxStamina = 30;
                break;
            case 3:
                maxStamina = 35;
                break;
            case 4:
                maxStamina = 40;
                break;
            case 5:
                maxStamina = 45;
                break;
            case 6:
                maxStamina = 50;
                break;
            default:
                maxStamina = 20;
                break;
        }
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
    }

    void Update()
    {
        if (!manager.IsOkToMove) return;
        manager.Km += Time.deltaTime*2;
        countKm.SetText(Convert.ToInt32(manager.Km).ToString());
        currentStamina -= Time.deltaTime;
        staminaBar.SetStamina(currentStamina);
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if ((Input.touchCount > 0 || Input.GetButtonDown("Fire1")))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        if (coyoteTimeCounter > 0f && jumpBufferCounter>0f)
        {
            rb.AddForce(transform.up * jumpForce);
            isGrounded = false;
            coyoteTimeCounter = 0f;
            jumpBufferCounter = 0f;
        }
        if (currentStamina <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Coin"))
        {
            manager.CoinCount++;
            countCoin.SetText(manager.CoinCount.ToString());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Food"))
        {
            currentStamina += 5;
            staminaBar.SetStamina(currentStamina + 5);
            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
            Destroy(collision.gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Ground"))
        {
            if (!isGrounded && collision.otherCollider == colGround)
            {
                isGrounded = true;
            }
        }

        if(collision.gameObject.CompareTag("Spike"))
        {
            Die();
        }

    }

    void Die()
    {
        manager.IsOkToMove = false;
        Time.timeScale = 0f;
        HUD.SetActive(false);
        morte.SetActive(true);
    }

}

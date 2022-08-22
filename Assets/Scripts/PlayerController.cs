using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool isGrounded = false;
    private GameManager manager;
    public GameObject moneda;
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
        manager.Km += Time.deltaTime;
        currentStamina -= Time.deltaTime;
        staminaBar.SetStamina(currentStamina);
        if (isGrounded && (Input.touchCount > 0 || Input.GetButtonDown("Fire1")))
        {
            rb.AddForce(transform.up * jumpForce);
            isGrounded = false;
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

        if (collision.gameObject.CompareTag("Coin"))
        {
            manager.CoinCount++;
        }

    }
}

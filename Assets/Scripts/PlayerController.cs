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
    [SerializeField] private TextMeshProUGUI topKm;
    [SerializeField] private TextMeshProUGUI coinBag;
    private int coinCount;
    private float km;
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    private bool isGrounded = false;
    private Vector3 startPos;
    private bool fingerDown;
    private int pixelDistToDetect = 20;
    private bool hasArmor;
    private bool hasStamUp;

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
        if (!GameManager.instance.IsOkToMove) return;
        km += Time.deltaTime * 2;
        countKm.SetText(Convert.ToInt32(km).ToString());
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
        int pleum = TouchSwipe();
        if (pleum == 1)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else if (pleum == 2)
        {
            rb.AddForce(-transform.up * jumpForce);
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
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

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Coin"))
        {
            AcquireMoney();
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Food"))
        {
            GainStamina();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Upgrade"))
        {
            UpgradeScript upScripy = collision.GetComponent<UpgradeScript>();
            if (upScripy != null)
            {
                UpgradeScript.UpgradeType upTypy = upScripy.upType;
                switch (upTypy)
                {
                    case UpgradeScript.UpgradeType.Armor:
                        ArmorUp();
                        Destroy(collision.gameObject);
                        break;
                    case UpgradeScript.UpgradeType.CoinSack:
                        GetCoinSack();
                        Destroy(collision.gameObject);
                        break;
                    case UpgradeScript.UpgradeType.Stamina:
                        if (!hasStamUp)
                        {
                            StartCoroutine(StaminaUpgrade());
                        }
                        Destroy(collision.gameObject);
                        break;
                    default:
                        Debug.Log("Colidiu e veio pro default");
                        break;
                }
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!isGrounded && collision.otherCollider == colGround)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            if (!hasArmor)
            {
                Die();
            }
            else
            {
                hasArmor = false;
            }
        }

    }

    void Die()
    {

        GameManager.instance.CoinBag += coinCount;
        coinCount = 0;
        if (km > GameManager.instance.TopKm)
        {
            GameManager.instance.TopKm = Convert.ToInt32(km);
        }
        GameManager.instance.IsOkToMove = false;
        Time.timeScale = 0f;
        HUD.SetActive(false);
        morte.SetActive(true);
    }

    public IEnumerator ArmorUp()
    {
        hasArmor = true;
        yield return new WaitForSeconds(10f);
        hasArmor = false;
    }

    public void AcquireMoney()
    {
        coinCount++;
        countCoin.SetText(coinCount.ToString());
    }

    public void GetCoinSack()
    {
        coinCount += 5;
        countCoin.SetText(coinCount.ToString());
    }

    public void GainStamina()
    {
        currentStamina += 5;
        staminaBar.SetStamina(currentStamina + 5);
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
    }

    public IEnumerator StaminaUpgrade()
    {
        hasStamUp = true;
        maxStamina += 20;
        staminaBar.SetMaxStamina((float)maxStamina);
        currentStamina = maxStamina;
        yield return new WaitForSeconds(20f);
        maxStamina -= 20;
        staminaBar.SetMaxStamina((float)maxStamina);
        currentStamina = maxStamina;
        hasStamUp = false;
    }

}

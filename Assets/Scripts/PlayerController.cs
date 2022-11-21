using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int jumpForce;
    [SerializeField] float currentStamina;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D colTotal;
    [SerializeField] StaminaBar staminaBar;
    [SerializeField] GameObject hUD;
    [SerializeField] GameObject morte;
    [SerializeField] GameObject coinCount;
    [SerializeField] GameObject coinMoment;
    [SerializeField] GameObject kmMoment;
    [SerializeField] TextMeshProUGUI countCoin;
    [SerializeField] TextMeshProUGUI momentCoin;
    [SerializeField] TextMeshProUGUI countKm;
    [SerializeField] TextMeshProUGUI coinBag;
    [SerializeField] PlayableDirector finalCut;
    [SerializeField] Animator animator;
    [SerializeField] AudioClip coinPickUpSound;
    [SerializeField] AudioClip upgradePickUpSound;
    [SerializeField] AudioClip[] canseiros;
    [SerializeField] AudioClip[] comida;
    [SerializeField] AudioClip[] dor;
    [SerializeField] AudioClip[] pulo;
    [SerializeField] AudioClip rolamento;
    [SerializeField] AudioClip lizardDie;
    [SerializeField] AudioClip areia;
    int maxStamina;
    int cashCount;
    public float km;
    float coyoteTime = 0.2f;
    float coyoteTimeCounter;
    float jumpBufferTime = 0.2f;
    float jumpBufferCounter;
    bool isGrounded = false;
    Vector3 startPos;
    bool fingerDown;
    int pixelDistToDetect = 20;
    bool hasArmor;
    bool hasStamUp;
    float rollCooldown = 0f;
    int idFinger;

    void Start()
    {
        countCoin.SetText(GameManager.Instance.CoinBag.ToString());
    }

    public void OnRunStart()
    {
        maxStamina = GameManager.Instance.MaxStamina;
        currentStamina = maxStamina;
        staminaBar.SetMaxSliderStamina(maxStamina);
    }

    void Update()
    {
        if (!GameManager.Instance.IsOkToMove) return;
        if (rollCooldown >= 0)
        {
            rollCooldown -= Time.deltaTime;
        }
        if (transform.position.y >= 8f)
        {
            transform.position = new Vector2(transform.position.x, 8f);
        }
        if (animator.GetBool("Moving") && !animator.GetBool("Rolling") && animator.GetFloat("VerticalSpeed") == 0)
        {

        }
        animator.SetBool("Moving", true);
        animator.SetFloat("VerticalSpeed", rb.velocity.y);
        km += Time.deltaTime * 2 * GameManager.Instance.SpeedModifier;
        if (km >= 1000 && GameManager.Instance.IsNotEndless)
        {
            StartCoroutine(EndRun());
        }
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
        else if (pleum == 2 && (rollCooldown <= 0 || !isGrounded))
        {
            StartCoroutine(Rolling());
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            int puloRandAudio = UnityEngine.Random.Range(0, pulo.Length);
            SoundManager.Instance.PlayAudio(pulo[puloRandAudio]);
            rb.AddForce(transform.up * jumpForce);
            isGrounded = false;
            coyoteTimeCounter = 0f;
            jumpBufferCounter = 0f;
        }
        if (currentStamina <= 0)
        {
            int cansarRandAudio = UnityEngine.Random.Range(0, canseiros.Length);
            SoundManager.Instance.PlayAudio(canseiros[cansarRandAudio]);
            Die();
        }
    }

    int TouchSwipe()
    {
        if (!fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            idFinger = Input.touches[0].fingerId;
            fingerDown = true;
        }
        if (fingerDown && Input.touches[0].fingerId == idFinger)
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

    IEnumerator Rolling()
    {
        SoundManager.Instance.PlayAudio(rolamento);
        rb.AddForce(-transform.up * jumpForce);
        rollCooldown = 1f;
        animator.SetBool("Rolling", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("Rolling", false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            AcquireMoney();
        }

        if (collision.gameObject.CompareTag("Food"))
        {
            if (collision.GetComponent<SpriteRenderer>().sprite.name.Equals("bread"))
            {
                SoundManager.Instance.PlayAudio(comida[1]);
            }
            else
            {
                bool audioOk = false;
                int comidaRandAudio = UnityEngine.Random.Range(0, comida.Length);
                while (!audioOk)
                {
                    comidaRandAudio = UnityEngine.Random.Range(0, comida.Length);
                    if (comidaRandAudio == 1)
                    {
                        audioOk = false;
                    }
                    else
                    {
                        audioOk = true;
                    }
                }
                SoundManager.Instance.PlayAudio(comida[comidaRandAudio]);
            }
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
                        SoundManager.Instance.PlaySound(upgradePickUpSound);
                        StartCoroutine(ArmorUp());
                        Destroy(collision.gameObject);
                        break;
                    case UpgradeScript.UpgradeType.CoinSack:
                        GetCoinSack();
                        Destroy(collision.gameObject);
                        break;
                    case UpgradeScript.UpgradeType.Stamina:
                        if (!hasStamUp)
                        {
                            SoundManager.Instance.PlaySound(upgradePickUpSound);
                            StartCoroutine(StaminaUpgrade());
                        }
                        Destroy(collision.gameObject);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpForce = 1500;
            if (!isGrounded)
            {
                isGrounded = true;
            }
        }
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            jumpForce = 900;
            if (!isGrounded)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            if (gameObject.transform.position.y >= collision.gameObject.transform.position.y + 1f)
            {
                SoundManager.Instance.PlaySound(lizardDie);
                GainStamina();
                Destroy(collision.gameObject);
            }
            else
            {
                if (!hasArmor)
                {
                    int morreRandAudio = UnityEngine.Random.Range(0, dor.Length);
                    SoundManager.Instance.PlayAudio(dor[morreRandAudio]);
                    Die();
                }
                else
                {
                    collision.collider.enabled = false;
                    Destroy(collision.gameObject);
                    hasArmor = false;
                }
            }
        }

    }

    public void FootstepsOnTheSand()
    {
        if (jumpForce == 1500)
        {
            SoundManager.Instance.PlaySound(areia);
        }
    }

    void Die()
    {
        SoundManager.Instance.transform.GetChild(0).GetComponent<AudioSource>().loop = false;
        GameManager.Instance.IsOnRun = false;
        animator.SetBool("Moving", false);
        animator.SetTrigger("Cansado");
        SaveAfterRun();
        GameManager.Instance.IsOkToSpawn = false;
        GameManager.Instance.IsOkToMove = false;
        hUD.SetActive(false);
        coinMoment.SetActive(false);
        coinCount.SetActive(true);
        countCoin.SetText(GameManager.Instance.CoinBag.ToString());//talvez add counting number
        cashCount = 0;
        morte.SetActive(true);
    }

    void SaveAfterRun()
    {
        GameManager.Instance.CoinBag += cashCount;
        if (km > GameManager.Instance.TopKm)
        {//add topEffect
            GameManager.Instance.TopKm = Convert.ToInt32(km);
            PlayerPrefs.SetInt("TopKm", GameManager.Instance.TopKm);
        }
        PlayerPrefs.SetInt("CoinBag", GameManager.Instance.CoinBag);
        PlayerPrefs.SetFloat("TempoArmor", GameManager.Instance.TempoArmor);
        PlayerPrefs.SetInt("SpeedModifier", GameManager.Instance.SpeedModifier);
    }

    public IEnumerator ArmorUp()
    {
        hasArmor = true;
        yield return new WaitForSeconds(PlayerPrefs.GetFloat("TempoArmor", 10f));
        hasArmor = false;
    }

    public void AcquireMoney()
    {
        cashCount++;
        momentCoin.SetText(cashCount.ToString());
        SoundManager.Instance.PlaySound(coinPickUpSound);
    }

    public void GetCoinSack()
    {
        for (int i = 0; i < 5; i++)
        {
            AcquireMoney();
        }
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
        staminaBar.SetMaxSliderStamina((float)maxStamina);
        currentStamina = maxStamina;
        yield return new WaitForSeconds(20f);
        maxStamina -= 20;
        staminaBar.SetMaxSliderStamina((float)maxStamina);
        currentStamina = maxStamina;
        hasStamUp = false;
    }

    private IEnumerator EndRun()
    {
        GameManager.Instance.IsOkToSpawn = false;
        yield return new WaitForSeconds(6f);
        GameManager.Instance.IsOkToMove = false;
        finalCut.Play();
        SaveAfterRun();
        cashCount = 0;
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUps : MonoBehaviour
{
    public GameObject activeBarL;
    public GameObject activeBarR;
    public GameObject score;

    private Image barL;
    private Image barR;
    private Text scoreText;

    public GameObject powerUpWL;
    public GameObject powerUpWR;
    public GameObject powerUpBL;
    public GameObject powerUpBR;

    private Image barWL;
    private Image barWR;
    private Image barBL;
    private Image barBR;

    public playerController playerController;
    public playerHealth playerHealth;
    public healthBarController healthBar;

    public int powerUpWhite;
    public int powerUpBlack;

    public float powerUpTimeW;
    public float powerUpTimeB;

    public bool tookPowerUpWhite;
    public bool tookPowerUpBlack;

    public bool isActivePowerW;
    public bool isActivePowerB;

    // Start is called before the first frame update
    void Start()
    {
        barL = activeBarL.GetComponent<Image>();
        barR = activeBarR.GetComponent<Image>();

        barWL = powerUpWL.GetComponent<Image>();
        barWR = powerUpWR.GetComponent<Image>();
        barBL = powerUpBL.GetComponent<Image>();
        barBR = powerUpBR.GetComponent<Image>();

        powerUpWL.SetActive(false);
        powerUpWR.SetActive(false);

        powerUpBL.SetActive(false);
        powerUpBR.SetActive(false);

        scoreText = score.GetComponent<Text>();

        playerController = GetComponent<playerController>();
        playerHealth = GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpWhite > 2)
        {
            healthBar.aditionalBars += 1;
            powerUpWhite = 0;
        }

        if (powerUpBlack > 2)
        {
            healthBar.aditionalBars += 1;
            powerUpBlack = 0;
        }
    }

    private IEnumerator PowerW()
    {
        playerHealth.isEmpoweredB = false;
        playerController.isEmpoweredW = true;

        powerUpWL.SetActive(true);
        powerUpWR.SetActive(true);

        powerUpBL.SetActive(false);
        powerUpBR.SetActive(false);

        barL.color = Color.white;
        barR.color = Color.white;
        scoreText.color = Color.white;

  

        yield return new WaitForSeconds(powerUpTimeW);

        playerController.isEmpoweredW = false;
        powerUpWL.SetActive(false);
        powerUpWR.SetActive(false);
    }

    private IEnumerator PowerB()
    {
        playerController.isEmpoweredW = false;
        playerHealth.isEmpoweredB = true;

        powerUpBL.SetActive(true);
        powerUpBR.SetActive(true);

        powerUpWL.SetActive(false);
        powerUpWR.SetActive(false);

        barL.color = Color.black;
        barR.color = Color.black;
        scoreText.color = Color.black;

      

        yield return new WaitForSeconds(powerUpTimeB);

        playerHealth.isEmpoweredB = false;
        powerUpBL.SetActive(false);
        powerUpBR.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "powerUpWhite")
        {
            powerUpWhite += 1;
            Destroy(collision.gameObject);

            StopCoroutine(PowerW());
            StartCoroutine(PowerW());
        }

        if(collision.tag == "powerUpBlack")
        {
            powerUpBlack += 1;
            Destroy(collision.gameObject);

            StopCoroutine(PowerB());
            StartCoroutine(PowerB());
        }
    }
}

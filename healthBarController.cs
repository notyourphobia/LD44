using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarController : MonoBehaviour
{
    public int aditionalBars;
    private int minBars;
    private int maxBars;

    public powerUps powerUps;
    public playerHealth playerHealth;

    public GameObject firstGroupFirstBar;
    public GameObject firstGroupSecondBar;
    public GameObject firstGroupThirdBar;

    public GameObject secondGroupFirstBar;
    public GameObject secondGroupSecondBar;
    public GameObject secondGroupThirdBar;

    public GameObject thirdGroupFirstBar;
    public GameObject thirdGroupSecondBar;
    public GameObject thirdGroupThirdBar;

    public GameObject firstCompletedFirstConfirm;
    public GameObject firstCompletedSecondConfirm;

    public GameObject secondCompletedFirstConfirm;
    public GameObject secondCompletedSecondConfirm;

    // Start is called before the first frame update
    void Start()
    {
        maxBars = 10;
        minBars = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (aditionalBars < minBars)
        {
            aditionalBars = minBars;
        }
        if (aditionalBars > 0)
        {
            firstGroupFirstBar.SetActive(true);
            playerHealth.repelDrain = 0.11f;
        }
        if (aditionalBars > 1)
        {
            firstGroupSecondBar.SetActive(true);
            playerHealth.repelDrain = 0.1f;
        }
        if (aditionalBars > 2)
        {
            firstGroupThirdBar.SetActive(true);
            playerHealth.repelDrain = 0.09f;
        }
        if (aditionalBars > 3)
        {
            secondGroupFirstBar.SetActive(true);
            playerHealth.repelDrain = 0.08f;
        }
        if (aditionalBars > 4)
        {
            secondGroupSecondBar.SetActive(true);
            playerHealth.repelDrain = 0.07f;
        }
        if (aditionalBars > 5)
        {
            secondGroupThirdBar.SetActive(true);
            playerHealth.repelDrain = 0.06f;
        }
        if (aditionalBars > 6)
        {
            thirdGroupFirstBar.SetActive(true);
            playerHealth.repelDrain = 0.05f;
        }
        if (aditionalBars > 7)
        {
            thirdGroupSecondBar.SetActive(true);
            playerHealth.repelDrain = 0.04f;
        }
        if (aditionalBars > 8)
        {
            thirdGroupThirdBar.SetActive(true);
            playerHealth.repelDrain = 0.03f;
            print(playerHealth.repelDrain);
        }
        if (aditionalBars > 9)
        {
            firstCompletedFirstConfirm.SetActive(true);
            firstCompletedSecondConfirm.SetActive(true);
            secondCompletedFirstConfirm.SetActive(true);
            secondCompletedSecondConfirm.SetActive(true);

            playerHealth.repelDrain = 0f;
        }
        if (aditionalBars > 10)
        {
            aditionalBars = maxBars;
        }


    }
}

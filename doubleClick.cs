using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleClick : MonoBehaviour
{
    public playerController playerController;
    public playerHealth playerHealth;

    private float firstCickTime;
    private float timeBetweenClicks;

    private bool coroutineAllowed;

    private int clickCounter;


    // Start is called before the first frame update
    void Start()
    {
        firstCickTime = 0f;
        timeBetweenClicks = 0.21f;
        clickCounter = 0;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickCounter += 1;
        }

        if(clickCounter == 1 && coroutineAllowed)
        {
            firstCickTime = Time.time;
            StartCoroutine(DoubleClickDetection());
        }
    }

    private IEnumerator DoubleClickDetection()
    {
        coroutineAllowed = false;
        while (Time.time < firstCickTime + timeBetweenClicks)
        {
            
            if (clickCounter ==2)
            {
                playerController.isRepeling = true;
                
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        clickCounter = 0;
        firstCickTime = 0f;
        coroutineAllowed = true;       
    }
}

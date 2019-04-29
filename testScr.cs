using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScr : MonoBehaviour
{
    public float randomMin;
    public float randomMax;

    public float number;

    void Start()
    {
       
    }

    void Update()
    {
        number = Random.Range(randomMin, randomMax);
   //     print(number);
    }
}


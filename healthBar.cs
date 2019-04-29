using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public playerHealth playerHealth;
    private float healthPoints;

    
    private Image barImage;
    // Start is called before the first frame update
    void Start()
    {
        barImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthPoints = playerHealth.curentHealthPoints;
        barImage.fillAmount = healthPoints/100f;        
    }
}

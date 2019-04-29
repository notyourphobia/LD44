using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{

    private float minHealthPoints = 0;
    private float maxHealthPoints = 100;
    public float curentHealthPoints;

    public float healthRegen;
    public float repelDrain;

    public bool isEmpoweredB;

    public bool isRepeling;

    // Start is called before the first frame update
    void Start()
    {
        

        curentHealthPoints = maxHealthPoints;
        isRepeling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRepeling && !isEmpoweredB)
        {
            curentHealthPoints -= repelDrain;
        }
        else
        {
            curentHealthPoints += healthRegen;
        }

        if (curentHealthPoints > maxHealthPoints)
        {
            curentHealthPoints = maxHealthPoints;
        }

        if (curentHealthPoints < minHealthPoints)
        {
            SceneManager.LoadScene("SampleScene");
        }



        if (Input.GetMouseButtonUp(0))
        {
            isRepeling = false;
        }
    }
}

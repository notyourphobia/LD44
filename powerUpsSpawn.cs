using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpsSpawn : MonoBehaviour
{
    

    public GameObject powerUpW;
    public GameObject powerUpB;

    private int powerUpWCount;
    private int powerUpBCount;

    private float positionX;

    private float distanceBetweenP = 0;

    public float minDistanceBP;
    public float maxDistanceBP;

    public float minPosX;
    public float maxPosX;

    private Vector2 newPos;

    // Start is called before the first frame update
    void Start()
    {
        powerUpWCount = Random.Range(3, 9);
        powerUpBCount = Random.Range(3, 9);

        newPos = transform.position;
        MakePowerUpsW(newPos.y);
        MakePowerUpsB(newPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakePowerUpsW(float atDistance)
    {
        for (int i = 0; i < powerUpWCount; i++)
        {
            positionX = Random.Range(minPosX, maxPosX);

            distanceBetweenP = Random.Range(minDistanceBP, maxDistanceBP);

            atDistance += distanceBetweenP;

            GameObject thePlatform = Instantiate(powerUpW, new Vector2(positionX, atDistance), transform.rotation, gameObject.transform);
        }
    }

    public void MakePowerUpsB(float atDistance)
    {
        for (int i = 0; i < powerUpBCount; i++)
        {
            positionX = Random.Range(minPosX, maxPosX);

            distanceBetweenP = Random.Range(minDistanceBP, maxDistanceBP);

            atDistance += distanceBetweenP;

            GameObject thePlatform = Instantiate(powerUpB, new Vector2(positionX, atDistance), transform.rotation, gameObject.transform);
        }
    }
}

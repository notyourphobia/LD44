using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldCotroller : MonoBehaviour
{
    public GameObject platform;

    private int platformCount = 81;

    private float positionX = 0;

    private float distanceBetweenP = 0;

    private float minDistanceBP = 2.6f;
    private float maxDistanceBP = 3.9f;

    private float minPosX = -1.1f;
    private float maxPosX = 1.1f;

    private Vector2 newPos;

    // Start is called before the first frame update
    void Start()
    {
        newPos = transform.position;
        MakePlatforms(newPos.y);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MakePlatforms(float atDistance)
    {

  
        for (int i = 0; i < platformCount; i++)
        {
            positionX = Random.Range(minPosX, maxPosX);

            distanceBetweenP = Random.Range(minDistanceBP, maxDistanceBP);

            atDistance += distanceBetweenP;

            GameObject thePlatform = Instantiate(platform, new Vector2(positionX, atDistance), transform.rotation, gameObject.transform);
            
        }      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isInWorld : MonoBehaviour
{
    public GameObject world;
    public GameObject platformSpawn;

    public GameObject currentWorld;

  

    public bool isInWorldCheck;

    public Vector2 lastWorldPosition;
    public Vector2 distanceBetweenWorlds;
    public Vector2 nextWorldPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        nextWorldPosition = lastWorldPosition + distanceBetweenWorlds;    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "World")
        {
            isInWorldCheck = true;
            lastWorldPosition = collision.transform.position;
            currentWorld = collision.gameObject; 
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "World")
        {
            isInWorldCheck = false;

            Instantiate(world, nextWorldPosition, transform.rotation);
            Instantiate(platformSpawn, new Vector2(nextWorldPosition.x, nextWorldPosition.y), transform.rotation);
        }
    }
}

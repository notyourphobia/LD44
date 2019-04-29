using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyWorld : MonoBehaviour
{
    public GameObject currentWorld;
    public GameObject lastWorld;

    public bool isInCurrentWorld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "World")
        {
            lastWorld = collision.gameObject;

            Destroy(lastWorld);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "World")
        {
            currentWorld = collision.gameObject;
        }
    }
}

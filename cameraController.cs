using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public playerController playerController;
    public Transform target;

    public GameObject gameWorld;
    private Vector3 worldPos = new Vector3(0f, 0f, 21f);

    public bool bound;
    public float boundY;

    private bool isRepeling;


    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Start()
    {
        Instantiate(gameWorld, worldPos, transform.rotation);
    }

    void Update()
    {
        isRepeling = playerController.isRepeling;
        if (isRepeling)
        {
            if (Input.mousePosition.y < transform.position.y)
            {
                  offset.y = -2.1f;
                
            }
        }
        else
        {
            //  offset.y = 3.9f;
            offset.y = 0f;

        }
    }

    void FixedUpdate()
    {
        if (bound)
        {
            if(transform.position.y < boundY)
            {
                transform.position = new Vector3(0,boundY,-10f);
            }
        }
        
        Vector3 desiredPosition =  new Vector3 (0, target.position.y + offset.y, -10f);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3 (0, smoothedPosition.y, -10f);

        
    }

}﻿


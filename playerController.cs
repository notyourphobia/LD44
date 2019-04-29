using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject balanceBar;

    public float attractForce;
    public float repelForce;

    public float greyStart;
    public float greyEnd;

    public float attractIncrease;
    public float attractEmpoweredIncrease;
    public float repelIncrease;

    public float totalForceScore;
    public float totalAttraction;
    public float totalRepel;

    public float attractPercentage;
    public float repelPercentage;

    public float test;

    private Rigidbody2D playerRb;
    private Animator animator;
    private TrailRenderer trailRenderer;

    public playerHealth playerHealth;
    
    public bool isRepeling;

    public bool pickedWhite;
    public bool pickedBlack;

    public bool isEmpoweredW;


    public bool isWhite;
    public bool isGrey;
    public bool isBlack;
   


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<playerHealth>();

        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.emitting = false;

        balanceBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isGrey)
        {
            animator.SetBool("isGrey", true);
            playerRb.mass = 1;
        }
        else if (!isGrey)
        {
            animator.SetBool("isGrey", false);
            playerRb.mass = 1.2f;
        }
        if (isWhite && !isBlack)
        {
            animator.SetBool("isAttracting", true);
            animator.SetBool("isRepeling", false);            
        }

        if(isBlack && !isWhite)
        {
            animator.SetBool("isRepeling", true);
            animator.SetBool("isAttracting", false);            
        }

        totalForceScore = totalAttraction + totalRepel;
        attractPercentage = totalAttraction / totalForceScore * 100;
        repelPercentage = totalRepel / totalForceScore * 100;


        if(attractPercentage > greyStart && attractPercentage < greyEnd)
        {
            isGrey = true;
        }
        else
        {
            isGrey = false;
        }
         

        if (Input.GetMouseButtonDown(0))
        {
            Attract();
            balanceBar.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isRepeling = false;
        }
        if(Input.GetMouseButton(0) && isEmpoweredW)
        {
            AttractEmpowered();
        }
        if(isRepeling)
        {
            Repel();
            totalRepel += repelIncrease;
            playerHealth.isRepeling = true;
            trailRenderer.emitting = true;
        }
        else
        {
            trailRenderer.emitting = false;
        }
    }

    void Attract()
    {
        isWhite = true;
        isBlack = false;

        Vector3 mousePosition;
        Vector2 mouseDirection;

        totalAttraction += attractIncrease;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = (mousePosition - transform.position).normalized;

        if (mousePosition.y < 0f)
        {
            playerRb.AddForce(new Vector2(mouseDirection.x * attractForce, 0), ForceMode2D.Impulse);
        }
        else
        {
            playerRb.AddForce(new Vector2(mouseDirection.x * attractForce, mouseDirection.y * attractForce), ForceMode2D.Impulse);
        }
    }

    public void Repel()
    {
        isBlack = true;
        isWhite = false;

        Vector3 mousePosition;
        Vector2 mouseDirection;

        trailRenderer.emitting = true;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = -(mousePosition - transform.position);

        playerRb.velocity = new Vector2(mouseDirection.x * repelForce, mouseDirection.y * repelForce);
    }

    void AttractEmpowered()
    {
        isWhite = true;
        isBlack = false;
      

        Vector3 mousePosition;
        Vector2 mouseDirection;

        totalAttraction += attractEmpoweredIncrease;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = (mousePosition - transform.position).normalized;

        playerRb.AddForce(new Vector2(mouseDirection.x * (attractForce + repelForce), mouseDirection.y * (attractForce + repelForce)), ForceMode2D.Force);
    }
}

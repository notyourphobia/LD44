using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killer : MonoBehaviour
{
    private Rigidbody2D killRb;
    private bool startMoving;
    private Vector3 moveDir;
    public float speed;
    public Transform playerT;
    private Vector2 playerPos;
    public float minYPos;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = playerT.position;
        killRb = GetComponent<Rigidbody2D>();
        moveDir = new Vector3(0, 1,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMoving = true;
        }

        if (startMoving)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        distance = playerPos.y + transform.position.y;


     
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}

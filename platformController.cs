using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{
    public playerController player;

    public float minScaleX;
    public float maxScaleX;

    private Rigidbody2D thisRB;

    public Vector3 randomScale;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<playerController>();
        thisRB = GetComponent<Rigidbody2D>();
        randomScale = new Vector3(Random.Range(minScaleX, maxScaleX), transform.localScale.y, transform.localScale.z);
        transform.localScale = randomScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private IEnumerator DeletePlatform()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && player.isRepeling)
        {
            thisRB.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(DeletePlatform());
        }

        if(collision.gameObject.tag == "Platform" && thisRB.bodyType == RigidbodyType2D.Dynamic)
        {

            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            collision.gameObject.GetComponent<platformController>().StartCoroutine(DeletePlatform());
        }
    }
}

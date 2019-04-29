using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class balanceBar : MonoBehaviour
{
    public playerController playerController;

    public Transform playerT;

    private float playerPosY;

    private float score;

    public Text scoreText;

    private float attractPercentage;
    private float repelPercentage;

    public Image blackBar;
    public Image whiteBar;

    // Start is called before the first frame update
    void Start()
    {
        playerT = playerController.GetComponent<Transform>();

        attractPercentage = playerController.attractPercentage;
        repelPercentage = playerController.repelPercentage;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosY = playerT.position.y;

        score = Mathf.RoundToInt(playerPosY + 5f);

        scoreText.text = "" + score;

        attractPercentage = playerController.attractPercentage;
        repelPercentage = playerController.repelPercentage;

        whiteBar.fillAmount = (attractPercentage / 100)  ;
        blackBar.fillAmount = (repelPercentage / 100) ;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float leftMoveLimit,rightMoveLimit;

    GameManager gameManager;


    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }


    void Update()
    {

        if (gameManager.gameOver == true)
        {
            return;
        }

        //Paddle Move
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right*h*moveSpeed*Time.deltaTime);


        //Paddle Move Limit
        Vector2 temp = transform.position;
        temp.x = Mathf.Clamp(temp.x, leftMoveLimit, rightMoveLimit);
        transform.position = temp;




        
        
        
        /* Alternate Code Paddle Move Limit
         if (transform.position.x<leftMoveLimit)
        {
            transform.position = new Vector2(leftMoveLimit, transform.position.y);
        }

        if (transform.position.x > rightMoveLimit)
        {
            transform.position = new Vector2(rightMoveLimit, transform.position.y);
        }*/



    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "LiveUpBall")
        {
            gameManager.UpdateLives(1);
            Destroy(target.gameObject);
        }

        if (target.gameObject.tag == "ScoreUpBall")
        {
            gameManager.updateScore(20);
            Destroy(target.gameObject);
        }
    }
}

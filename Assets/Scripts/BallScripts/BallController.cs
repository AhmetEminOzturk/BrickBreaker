using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float ballSpeed;

    [SerializeField]
    bool inPlay;
    
    [SerializeField]
    Transform ballStartPosition;

    GameManager gameManager;




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
        if (gameManager.gameOver == true)
        {
            return;
        }
        
        
        
        if (!inPlay)
        {
            transform.position = ballStartPosition.position;
        }

        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * ballSpeed);
        }

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bottom")
        {
            rb.velocity = Vector2.zero;
            gameManager.UpdateLives(-1);
            inPlay = false;
        }
    }
}

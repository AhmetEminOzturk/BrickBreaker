using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField]
    GameObject brickEffect;

    GameManager gameManager;

    [SerializeField]
    GameObject luckliveImage;


    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ball")
        {
            Instantiate(brickEffect,transform.position,transform.rotation);
            gameManager.updateScore(5);
            Destroy(gameObject);

            int LuckLive = Random.Range(1, 101);

            if (LuckLive > 50)
            {
                Instantiate(luckliveImage,transform.position,transform.rotation);
            }

        }
    }
}

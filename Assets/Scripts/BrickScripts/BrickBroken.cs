using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBroken : MonoBehaviour
{
    [SerializeField]
    Sprite brokenImage;
    int count;
    [SerializeField]
    GameObject brickBrokenEffect,scoreUpImage;

    GameManager gameManager;



    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }


    private void Start()
    {
        count = 0;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag=="Ball")
        {
            count++;
           
            if (count == 1)
            {
                GetComponent<SpriteRenderer>().sprite = brokenImage;
                gameManager.updateScore(5);
            }
            if (count == 2)
            {
                Instantiate(brickBrokenEffect,transform.position,transform.rotation);
                gameManager.updateScore(10);
                
                int LuckLive = Random.Range(1, 101);

                if (LuckLive > 30)
                {
                    Instantiate(scoreUpImage, transform.position, transform.rotation);
                }
                Destroy(gameObject);
            }
        }
    }
}

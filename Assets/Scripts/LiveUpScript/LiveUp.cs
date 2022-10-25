using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveUp : MonoBehaviour
{
    [SerializeField]
    float liveUpSpeed;

    void Update()
    {
        transform.Translate(Vector2.down * liveUpSpeed * Time.deltaTime);
    }

}

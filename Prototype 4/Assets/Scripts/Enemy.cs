using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;

    private Rigidbody enemyRb;
    private GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //To make an enemy to "follow" the player
        Vector3 followPlayer = (player.transform.position - enemyRb.transform.position).normalized;
        enemyRb.AddForce( followPlayer * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        
        //This one is NOT correct:
        //enemyRb.AddForce((enemyRb.transform.position - player.transform.position).normalized * speed);
    }

}

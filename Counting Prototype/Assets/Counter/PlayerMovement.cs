using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Limit zBound = 30
    public bool reachBoundLimit = false;
    public int registerKeyPressed = 0;
    private float zBoundLimit = 25f;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && registerKeyPressed < 2)
        {
            playerRb.AddForce(new Vector3(0,5,2), ForceMode.Impulse);
            //registerKeyPressed++;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        float xGoal = 0.0383f;
        float yGoal = 1.5991f;
        float zGoal = 0.0303f;
        Vector3 goalCollider = new Vector3(xGoal, yGoal, zGoal);
        
        if (playerRb == true)
        {
            Instantiate(playerRb, new Vector3(0.75f, 0.66f, -17.47f), playerRb.transform.rotation);
            
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (gameObject.transform.position.z > zBoundLimit)
        {
            transform.position = new Vector3(0.75f, 0.66f, -17.47f);
            playerRb.velocity = Vector3.zero;
            reachBoundLimit = true;
            Debug.Log(reachBoundLimit);
        }
        else
        {
            reachBoundLimit = false;
            Debug.Log(reachBoundLimit);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    public float speed = 5.0f;
    public float powerStrength = 16.0f;
    public bool hasPowerUp = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        //With this the Indicator is in the position of the player  This Vector3 is the offset to place it correctly the powerUpIndicator
        powerUpIndicator.transform.position = playerRb.transform.position + new Vector3(0,-0.5f,0);
        
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
        //Debug.Log("PowerUp has gone");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Now it function the powerUP correctly, TURNS OUT you need to put the StartCoroutine in here
        //because it will activivate once the is trigger and NOT in update bc it will start the countdown immediately
        //Research to make powerups wwith a timer and that don't reset
        hasPowerUp = true;
        powerUpIndicator.SetActive(true);
        Destroy(other.gameObject);
        
        StartCoroutine(PowerUpCountdown());
        
    }

    private void OnCollisionEnter(Collision other)
    {   
        // If I set hasPowerUp to tru is redundant
        if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            
            //Take the enemy position and - with the player position, with this we send it back
            //My version BUT also workd fine :D
            Vector3 moveAwayEnemy = enemyRb.transform.position - playerRb.transform.position;
            
            //This one is the "correct" with the tutorial
            //Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
            
            enemyRb.AddForce(moveAwayEnemy * powerStrength, ForceMode.Impulse);
            
            //Debug concatenation to get accurate info for the player and the power up
            Debug.Log("Player hit the " + other.gameObject.name + " with power up set " + hasPowerUp);
        }
    }
}

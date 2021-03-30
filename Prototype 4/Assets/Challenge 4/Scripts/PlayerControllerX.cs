using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;
    private ParticleSystem dashParticle;
    //Something like 100
    public float boostSpeed;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        dashParticle = GameObject.Find("Smoke_Particle").GetComponent<ParticleSystem>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
        
        // Set the dashParticle to be with the player it can be gameObject or the Rb of the player(in this case playerRb)
        //With the 0.3f the particle would be a bit up
        dashParticle.transform.position = playerRb.transform.position - Vector3.up * 0.3f;
        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        
        SpeedBoost();
        

    }
    
    //Add a boost to the player for a breif moment ONLY when press SPACE
    void SpeedBoost()
    {
        dashParticle.transform.position = gameObject.transform.position - Vector3.up * 0.3f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashParticle.Play();
            speed *= 3.0f;
            
            //Put the particle below the player
            //We add the speed when press the Space
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            dashParticle.Stop();
            speed /= 3.0f;
        }
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            //Maybe always is the object we want to keep away and then the object we are using
            Vector3 awayFromPlayer =  other.gameObject.transform.position - transform.position ; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }



}

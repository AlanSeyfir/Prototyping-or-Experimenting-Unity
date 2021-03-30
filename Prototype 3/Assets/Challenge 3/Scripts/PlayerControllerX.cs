using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    /*
     *  Bonus - Prevent the player from floating their balloon too high 
        Hint - Add a boolean to check if the balloon isLowEnough, then only allow the player to add upwards 
        force if that boolean is true
        
        A comment helped but maybe I can use this hint too!
     */
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip boingSound;

    public float topBound = 14.5f;
    public float lowBound = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }
    
    

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < topBound)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        //Here is the code that Prevent the player from floating their balloon too high 
        else if (transform.position.y >= topBound)
        {
            transform.position = new Vector3(transform.position.x,topBound, transform.position.z);
            //Adding this it will create another force to nullify the player Force, so we don't get the balloon
            //stays a lot of time in the topBound
            playerRb.AddForce(Vector3.down, ForceMode.Impulse);
        }
        
        //I try this to stop moving the balloon but no xd
        //transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y, -15, 14),transform.position.z);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }else if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            
            playerRb.AddForce(Vector3.up * lowBound, ForceMode.VelocityChange);
            playerAudio.PlayOneShot(boingSound,1.0f);
        }

    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    //We make a reference with Rigidbody & Animator
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    //Put Audio/sound
    public AudioClip soundJump;
    public AudioClip soundCrash;
    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    public bool isOnGround = true;
    public bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //              Also be gameOver == false or gameOver != true or !gameOver (Meaning NOT equal, not gameOver)
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(soundJump, 1.0f);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //I add it because if you die and last second jump in the obstacle the particle can appear again
        //so with this we are telling that if is on Ground and is NOT game over dirtParticle will play
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Game over");
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(soundCrash, 1.0f);
        }
        
    }
}

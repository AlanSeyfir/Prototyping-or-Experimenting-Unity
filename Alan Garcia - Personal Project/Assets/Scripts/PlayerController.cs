using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    //11:45

    private float speed = 100.0f;
    private float zBound = 8.0f;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       MovePlayer();
       SanPedroTodoPoderoso();
        
    }

    void MovePlayer()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        
        playerRb.AddForce(Vector3.forward * speed * verticalMovement);
        playerRb.AddForce(Vector3.right * speed * horizontalMovement);
    }

    //Add boundaries to the player in Z & -Z
    void SanPedroTodoPoderoso()
    {
        if (transform.position.z < -zBound)
        {
            //If I delete/comment the following line it will simulate a trampoline effect Line 43
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
            playerRb.AddForce(Vector3.forward, ForceMode.Impulse);
        }

        if (transform.position.z > zBound)
        {
            //If I delete/comment the following line it will simulate a trampoline effect Line 50
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
            playerRb.AddForce(Vector3.back, ForceMode.Impulse);
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            //Debug.Log("Player obtained a powerUP" + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player trigger the " + collision.gameObject.name);
        }
    }
}

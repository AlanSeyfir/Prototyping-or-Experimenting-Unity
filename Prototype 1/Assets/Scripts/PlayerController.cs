using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private variables
    [SerializedField] private float speed = 10.0f;
    private const float turnSpeed = 40;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //The good thing about Input(Manager) is that it's easier to assign to a controller
        //mouse or keyboard(but that's something later on)
        //Detects the player inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //We move the vehicle forward - Is the same but more easy to read
          //transform.Translate(0, 0, 1);
          //transform.Translate(0,0,1 * Time.deltaTime * 10);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //We rotate the vehicle
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}

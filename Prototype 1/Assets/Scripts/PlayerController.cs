using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //private variables
    [SerializeField] private float horsepower = 0f;
    [SerializeField] private float speed;
    private const float turnSpeed = 40;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI rpmText;
    private float rpm;
    [SerializeField] private List<WheelCollider> allWheels;
    [SerializeField] private int wheelsOnGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //The good thing about Input(Manager) is that it's easier to assign to a controller
        //mouse or keyboard(but that's something later on)
        //Detects the player inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (isOnGround())
        {
            //We move the vehicle forward - Is the same but more easy to read
                //transform.Translate(0, 0, 1);
                //transform.Translate(0,0,1 * Time.deltaTime * 10);
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddForce(Vector3.forward * horsepower * forwardInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f); //For Mph/h change 3.6 to 2.237
            speedText.text = "Speed: " + speed + "km/h";
            //speedText.SetText("Speed: " + speed + "km/h"); For some reason is better the .text

            rpm = (speed % 30) * 40;
            rpmText.text = "Rpm: " + rpm;
        
            //We rotate the vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }
        
    }

    bool isOnGround()
    {
        wheelsOnGround = 0;
        //Understand foreach bc is confusing :/
        foreach (WheelCollider wheels in allWheels)
        {
            if (wheels.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xLimitPlayer = 15.0f;
    public GameObject foodProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Keep the player in bounds
        if (transform.position.x < -xLimitPlayer)
        {
            transform.position = new Vector3(-xLimitPlayer, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xLimitPlayer)
        {
            transform.position = new Vector3(xLimitPlayer, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //The character will fire the projectile
            Instantiate(foodProjectilePrefab, transform.position, foodProjectilePrefab.transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20f;
    //Script Communication
    private PlayerMovement playerMovementScript;
    private float leftBound = -10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Script Communication
        // Will find "Player" in the scene hiercachy, to set PlayerMovementScript to be the ACTUAL PlayerMovementScript
        // With this we have a reference to "Player" by this I mean in the hiercachy
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}

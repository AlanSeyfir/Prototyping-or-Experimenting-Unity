using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBounds : MonoBehaviour
{

    public float topBound = 40.0f;
    public float lowerBound = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            //Make sure to apply to destroy the prefab and not the GameObject in the hierarchy
            //By this I mean if the player use certain GameObject it will destroy and I can't use it
            //so wee need to use destroy the prefab NOT the gameobject
            Destroy(gameObject);
        }else if (transform.position.z < lowerBound)
        {
            //Placeholder when we want a game over screen
            Debug.Log("Game over");
            Destroy(gameObject);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    //public float resetBackground = 56.5f;
    private float resetBackground;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        //Method to repeat the background accurate than using pure numbers
        resetBackground = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - resetBackground)
        {
            transform.position = startPos;
            
        }
    }
}

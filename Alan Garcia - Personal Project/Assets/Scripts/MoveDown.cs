using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f;
    private float zBoundDestroyObj = 15.0f;
    private Rigidbody objectsRb;
    // Start is called before the first frame update
    void Start()
    {
        objectsRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Also you can use .back with +speed
        objectsRb.AddForce(Vector3.forward * -speed);

        if (transform.position.z < -zBoundDestroyObj)
        {
            Destroy(gameObject);
        }
    }
}

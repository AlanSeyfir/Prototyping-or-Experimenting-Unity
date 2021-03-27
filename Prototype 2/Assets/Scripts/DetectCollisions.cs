using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //With this we override the method OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        //Destroy the gameobject if collide 
        Destroy(gameObject);
        //I don't know why  but we need only Destroy(gameObject); maybe bc is a different version of Unity
        //Destroy(other.gameObject);
    }
}

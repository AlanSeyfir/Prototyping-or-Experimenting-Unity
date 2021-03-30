using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    
    private float spawnDelay = 2f;
    private float spawnRate = 3f;
    //Script Communication
    private PlayerMovement playerMovementScript;
    
    // Start is called before the first frame update
    void Start()
    {
        //Script Communication
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        //If I put this in here the Instantiate they will a LOT every frame
    }

    void SpawnObstacle()
    {
        if (playerMovementScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}

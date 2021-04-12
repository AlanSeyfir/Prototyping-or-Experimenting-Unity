using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private PlayerMovement playerMovementScript;

    public GameObject[] playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlayer()
    {
        int playerIndex = Random.Range(0, playerPrefab.Length);
        playerMovementScript = GameObject.Find("SpawnManager").GetComponent<PlayerMovement>();
        Instantiate(playerPrefab[playerIndex], new Vector3(0.75f, 0.66f, -17.47f), playerPrefab[playerIndex].transform.rotation);
    }
    
}

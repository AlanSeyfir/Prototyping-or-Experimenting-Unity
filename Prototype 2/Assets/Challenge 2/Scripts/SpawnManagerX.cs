using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        //Spawn the gameObject in random values between 3 and 5
        int spawnRandomInterval = Random.Range(3, 5);
        Invoke("SpawnRandomBall", spawnRandomInterval);

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        int spawnDiffBalls = Random.Range(0,ballPrefabs.Length);
        Instantiate(ballPrefabs[spawnDiffBalls], spawnPos, ballPrefabs[spawnDiffBalls].transform.rotation);

        
    }

}

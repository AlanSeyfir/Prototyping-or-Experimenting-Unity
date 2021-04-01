using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Target : MonoBehaviour
{
    //ALWAYS CLEAN CODE OR COMMENT THE METHODS
    private Rigidbody objectPrefab;
    private GameManager gameManager;
    
    private float minSpeedUp = 12f;
    private float maxSpeedUp = 16f;
    private float maxTorque = 10f;
    private float xRangePos = 4f;
    private float yRangePos = -2f;

    public int targetValue;
    public ParticleSystem explosionParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        objectPrefab = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        //With Vector.up we get rid of the innecessesary 0 in x & z 
        objectPrefab.AddForce(RandomSpeedSpawn(), ForceMode.Impulse);
        objectPrefab.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);
        
        
        objectPrefab.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //It can check when the game is active before it starts doing
        //all these things to explode all the different objects
        //With this the player can't click if is gameOver
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(targetValue);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomSpeedSpawn()
    {
        return Vector3.up * Random.Range(minSpeedUp, maxSpeedUp);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        //No need to add the O in z Bc well it's redundant
        return new Vector3(Random.Range(-xRangePos, xRangePos), yRangePos);
    }
}

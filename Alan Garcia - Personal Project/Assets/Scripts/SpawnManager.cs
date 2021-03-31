using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject powerUp;

    private float zSpawnEnemy = 10.0f;
    private float xSpawnRange = 10.0f;
    private float zSpawnPowerUp = 6.0f;
    private float ySpawnRange = 0.6f;
    
    
    private float startDelay = 1.0f;
    private float repeatDelayEnemy = 2.0f;
    private float repeatDelayPowerUp = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, repeatDelayEnemy);
        InvokeRepeating("SpawnPowerUp", startDelay, repeatDelayPowerUp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        //Code cleanup with this variables
        int enemyIndex = Random.Range(0, enemy.Length);
        float randomXPos = Random.Range(-xSpawnRange, xSpawnRange);
        
        Vector3 positionEnemy = new Vector3(randomXPos,ySpawnRange,zSpawnEnemy);

        Instantiate(enemy[enemyIndex], positionEnemy, enemy[enemyIndex].transform.rotation);
    }

    void SpawnPowerUp()
    {
        //Code cleanup with this variables
        float randomXPos = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZPos = Random.Range(-zSpawnPowerUp, zSpawnPowerUp);
        
        Vector3 positionPowerUp = new Vector3(randomXPos,ySpawnRange, randomZPos);

        Instantiate(powerUp, positionPowerUp, powerUp.transform.rotation);
    }
}

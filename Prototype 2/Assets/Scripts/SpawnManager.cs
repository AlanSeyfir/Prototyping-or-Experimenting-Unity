using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private int spawnPosX = 20;
    private int spawnPosZ = 20;
    private float spawnDelay = 2.0f;
    private float spawnRepeat = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Call the method and repeat it with how muhc delay and how much appear again
        InvokeRepeating("SpawnRandomAnimal", spawnDelay, spawnRepeat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Will spawn the animals in the scene
    /// </summary>
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        //Make more readable adding variables instead of raw numbers
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}

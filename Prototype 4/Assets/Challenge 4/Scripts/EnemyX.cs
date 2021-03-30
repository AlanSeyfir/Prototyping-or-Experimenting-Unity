using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 1.0f;
    private EnemyX[] enemyCount;
    private Rigidbody enemyRb;
    public GameObject playerGoal;
    private SpawnManagerX spawnManagerXScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        //WITH THIS IT INCREASE THE DIFFICULTY OR MORE ACCURATE THE THE VARIABLE SPEED WITH THE WAVECOUNT
        speed = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().waveCount;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}

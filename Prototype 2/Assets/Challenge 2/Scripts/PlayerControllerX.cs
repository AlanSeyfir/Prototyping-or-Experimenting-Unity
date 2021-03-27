using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float time = 2.0f;
    private float timer = Time.time;

    // Update is called once per frame

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnDogs();
                timer = 0;
            }
        }
    }


    void SpawnDogs()
    {


        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
    }
}

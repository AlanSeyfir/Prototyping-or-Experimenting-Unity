using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        transform.position = new Vector3(3, 4, 1);

        transform.localScale = Vector3.one * 1.0f;

        Material material = Renderer.material;
        material.color = new Color(1f, 0.4f, 0.8f, 0.9f);
    }

    void Update()
    {
        //ColorHSV
        float xRotation = Random.Range(0f, 200.0f);
        float yRotation = Random.Range(0f, 700.0f);
        float zRotation = Random.Range(0f, 350.0f);

        float xScale = Random.Range(0f, 5.0f);
        float yScale = Random.Range(0f, 5.0f);
        float zScale = Random.Range(0f, 5.0f);

        transform.Rotate(xRotation * Time.deltaTime, yRotation * Time.deltaTime, zRotation * Time.deltaTime);


        //transform.localScale = Vector3.one * Random.Range(1.0f, 5.0f) * Time.deltaTime;
        PlayerChangedColors();
        
    }

    void PlayerChangedColors()
    {
        Material material = Renderer.material;
        float rndColor = Random.Range(0f, 1.0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            material.color = new Color(rndColor, rndColor, rndColor);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            material.color = new Color(0,10,255);
        }
    }

}

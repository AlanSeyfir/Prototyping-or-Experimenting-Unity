using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartBtn;
    public bool isGameActive;
    private int score;
    private float spawnRate = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;
        
        StartCoroutine("SpawnTargets");
        UpdateScore(0);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator SpawnTargets()
    {
        //If I don't add the while it would spawn one time
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            //If we don't add the Vector and rotation it would spawn weird or in the center.
            Instantiate(targets[index], Vector3.down, targets[index].transform.rotation);
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartBtn.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        //Get the current scene and assign this method for the button to restart the game/scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    
    public GameObject titleScreen;
    public Button restartButton; 

    public List<GameObject> targetPrefabs;

    private GameManager gameManager;
    private int score;
    
    private float spawnRate = 1.5f;
    public bool isGameActive;

    private float spaceBetweenSquares = 2.5f; 
    private float minValueX = -3.75f; //  x value of the center of the left-most square
    private float minValueY = -3.75f; //  y value of the center of the bottom-most square
    
    public int countdownTime;
    public TextMeshProUGUI timerText;
    
    /*
    //ANOTHER WAY TO MAKE A TIMER
    private float timeLeft;
    public TextMeshProUGUI timeLeftText;
    //ANOTHER WAY TO MAKE A TIMER
    */
    


    /*//ANOTHER WAY TO MAKE A TIMER
    private void Update()
    {
        if(isGameActive)
        {
            timeLeft -= Time.deltaTime;
        }
        timeLeftText.text = "Time: " + Mathf.Round(timeLeft);
        if(timeLeft <= 0 && isGameActive)
        {
            GameOver();
        }
    }//ANOTHER WAY TO MAKE A TIMER
    */

    // Start the game, remove title screen, reset score, and adjust spawnRate based on difficulty button clicked
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        StartCoroutine(StartCountDown());
        score = 0;
        
        /*//ANOTHER WAY TO MAKE A TIMER
        timeLeft = 60;
        //ANOTHER WAY TO MAKE A TIMER*/
        
        UpdateScore(0);
        titleScreen.SetActive(false);
    }

    // While game is active spawn a random target
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);

            if (isGameActive)
            {
                Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            }
            
        }
    }
    
    //START COUNTDOWN FOR THE USER
    IEnumerator StartCountDown()
    {
        while (countdownTime >= 0)
        {
            timerText.text = "Timer: " + countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);

    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;

    }

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // Update score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        
    }

    /*public void UpdateTimer(int timerLeft)
    {
        //timer -= timerLeft;
        timerText.text = "Timer: " + timer;

        if (timer <= 0)
        {
            isGameActive = false;
            Debug.Log("SE ACABO");
        }
        else
        {
            timer--;
            Debug.Log("SE ESTA RESTANDO");
        }
    }*/

    

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

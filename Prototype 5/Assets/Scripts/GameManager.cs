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
    public GameObject titleScreen;
    public Button restartBtn;
    public bool isGameActive;
    private int score;
    private float spawnRate = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //For some reason I need to reference the gameObject "Game Manager" instead of the Game Manager script on the
        //On Click() for the buttons to pass the values. The gameObject passes all the methods and the script only
        //the monodevelop....huh
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
    
    //Start difficulty and the game, I see that is easier and simple to make it this way, intead of making a new script (I mean the DifficultyButton.cs)
    public void StartGame(int difficulty)
    {
        Debug.Log("Set difficulty to: " + difficulty.ToString());
        //Adding false if I click the difficulty will disappear and to start playing
        titleScreen.gameObject.SetActive(false);
        //Divide the difficulty to make the spawnRate faster
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        
        StartCoroutine("SpawnTargets");
        UpdateScore(0);
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

    /*public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        
        StartCoroutine("SpawnTargets");
        UpdateScore(0);
        
        titleScreen.gameObject.SetActive(false);
    }*/
}

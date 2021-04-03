using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public int countdownTime;
    public TextMeshProUGUI timerText;

    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(StartCountDown());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator StartCountDown()
    {
        while (countdownTime > 0)
        {
            timerText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        gameManager.isGameActive = true;
        yield return new WaitForSeconds(1f);

    }
}

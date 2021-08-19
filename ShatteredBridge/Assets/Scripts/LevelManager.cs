using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{   
    public GameObject startPoint;
    private int count;
    public Text scoreText;
    public Text scoreTextFinal;
    public GameObject TimeCounter;
    public GameObject WinMessage;

    private void Awake()
    {
        WinMessage.SetActive(false);
    }

    private void Start()
    {
        count = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Goal":
                StartGoalSequence();
                break;
            case "Trap":
                Restart();
                GetComponent<PlayerController>().enabled = true;
                break;
            case "PickUp":
                other.gameObject.SetActive(false);
                count++;
                SetScoreText();
                break;
        }
    }

    void StartGoalSequence()
    {   
        SetWinMessage();
        GetComponent<PlayerController>().enabled = false;
        TimerController timerController = TimeCounter.GetComponent<TimerController>();
        timerController.EndTimer();
        //Invoke("ReloadLevel", 1f);
    }

    private void Restart()
    {   
        GetComponent<PlayerController>().enabled = false;
        startPoint.GetComponent<SpawnPlayer>().firstSpawn();
    }

    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void SetScoreText()
    {
        scoreText.text = "Score:" + count.ToString();
    }

    private void SetWinMessage()
    {
        WinMessage.SetActive(true);
        scoreTextFinal.text = "You got score of " + count + "!";
    }
    
}


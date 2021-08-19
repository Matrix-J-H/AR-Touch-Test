using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timeCounter;

    private TimeSpan timePlayed;
    private bool timerRunning;

    private float timePassed;

    private void Awake() 
    {
        instance = this;
    }
    
    private void Start() 
    {
        timeCounter.text = "Time: 00:00";
        BeginTimer();
    }

    private void BeginTimer()
    {
        timerRunning = true;
        timePassed = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerRunning = false;
    }

    private IEnumerator UpdateTimer()
    {
        while(timerRunning)
        {
            timePassed += Time.deltaTime;
            timePlayed = TimeSpan.FromSeconds(timePassed);
            string timePlayedTxt = "Time: " + timePlayed.ToString("mm':'ss");
            timeCounter.text = timePlayedTxt;

            yield return null;
        }
    }
}

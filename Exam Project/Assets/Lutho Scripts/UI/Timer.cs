using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Timer : MonoBehaviour
{
    public Text timerTxt;
    public float timeRemaining;

    public bool isTimerRunning = true;
   
    void Start()
    {
        UpdateTimerDisplay();
    }

    public void Update()
    {
        if (isTimerRunning)
        {
            UpdateTimer();
        }
    }
    void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            isTimerRunning = false;

        }

        UpdateTimerDisplay();
    }

    public void UpdateTimerDisplay()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerTxt.text = seconds.ToString();
       
    }
}

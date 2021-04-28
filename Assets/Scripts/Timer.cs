using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;

    bool keepTiming;
    float timer;

    public GameController gameManager;

    public void Update()
    {
        if (keepTiming)
        {
            UpdateTime();
        }
    }

    public void UpdateTime()
    {
        timer = Time.time - startTime;
        timerText.text = TimeToString(timer).Replace(".", ":");
    }

    public void StopTimer()
    {
        string time = timer.ToString();
        //gameManager.endTimer.text = timerText.text;
        keepTiming = false;
    }

    public void StartTimer()
    {
        keepTiming = true;
        startTime = Time.time;
    }

    public string TimeToString(float t)
    {
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        return minutes + ":" + seconds;
    }
}

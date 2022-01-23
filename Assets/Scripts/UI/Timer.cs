using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public List<GameObject> timers;
    private ChestService chestService;

    private bool timerActive = false;
    private float currentTime;
    public int startMinutes;

    private TextMeshProUGUI timerText;
    private int slotNum;

    private void Awake()
    {
        chestService = this.GetComponent<ChestService>();
    }

    private void Start()
    {     
    }

    private void Update()
    {
        if(timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if(currentTime <= 0)
            {
                timerActive = false;
                resetTime();
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = time.Hours.ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    private void startTimer()
    {
        timerActive = true;
    }

    private void resetTime()
    {
        currentTime = startMinutes * 60;
    }

    private void onClickSlot(int slotNum, Vector3 slotPos)
    {
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Timer : MonoBehaviour
{
    private int slotNum;

    public double currentTime;



    private TextMeshProUGUI timerText;

    private void Update()
    {
        if(currentTime <= 0)
        {
            CancelInvoke();
        }
    }

    public void startTimer(double unlockTime, int slotNum)
    {
        this.slotNum = slotNum;
        currentTime = unlockTime * 60;
        timerText = this.GetComponent<TextMeshProUGUI>();      
        timerText.text = currentTime.ToString();

        InvokeRepeating("timerLogic", 0f, 1f);
    }

    private void timerLogic()
    {
        currentTime--;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = time.Hours.ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
    
}

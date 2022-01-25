using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ChestActionsManager : MonoBehaviour
{
    public static event Action<int, double> clickedOnStartTimer;
    public static event Action clickedOnUseGems;

    public GameObject chestActions;
    public List<TextMeshProUGUI> texts;

    private ChestService service;

    private int cost, id, slotNum;
    private double unlockTime;

    // Start is called before the first frame update
    void Start()
    {
        ChestController.clickedOnChest += onClickChest;
    }

    private void onClickChest(double unlockTime, int cost, int id, int slotNum)
    {
        this.unlockTime = unlockTime;
        this.cost = cost;
        this.id = id;
        this.slotNum = slotNum;
        chestActions.SetActive(true);
        updateStartTimerText();
        updateUseGemsText();
    }

    public void onClickStartTimer()
    {
        Debug.Log(slotNum);
        clickedOnStartTimer?.Invoke(slotNum, unlockTime);
        chestActions.SetActive(false);
    }
    
    public void onClickUseGems()
    {
        clickedOnUseGems?.Invoke();
        chestActions.SetActive(false);
    }

    private void updateStartTimerText()
    {
        TimeSpan time = TimeSpan.FromMinutes(unlockTime);
        texts[0].text = time.Hours.ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    private void updateUseGemsText()
    {
        texts[1].text = cost.ToString();
    }
}

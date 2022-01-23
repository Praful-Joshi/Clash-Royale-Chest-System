using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ChestActionsManager : MonoBehaviour
{
    public static event Action clickedOnStartTimer;
    public static event Action clickedOnUseGems;

    public GameObject chestActions;
    public List<TextMeshProUGUI> texts;

    private ChestService service;

    private int cost, unlockTime;

    // Start is called before the first frame update
    void Start()
    {
        ChestController.clickedOnChest += onClickChest;
    }

    private void onClickChest(int unlockTime, int cost)
    {
        this.unlockTime = unlockTime;
        this.cost = cost;
        chestActions.SetActive(true);
        updateStartTimerText();
        updateUseGemsText();
    }

    public void onClickStartTimer()
    {
        clickedOnStartTimer?.Invoke();
        chestActions.SetActive(false);
    }
    
    public void onClickUseGems()
    {
        clickedOnUseGems?.Invoke();
        chestActions.SetActive(false);
    }

    private void updateStartTimerText()
    {
        texts[0].text = unlockTime.ToString();
    }

    private void updateUseGemsText()
    {
        texts[1].text = cost.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryManager : MonoBehaviour
{
    //other script ref
    private ChestController controller;

    //declaring components
    public TextMeshProUGUI coinsText, gemsText;

    //declaring variables
    public static int startingCoins = 20, startingGems = 5;
    private int rewardCoins, rewardGems;
    

    private void Awake()
    {
        updateData(startingCoins, startingGems);     
    }

    // Start is called before the first frame update
    void Start()
    {
        RewardManager.clickedOnCollectReward += onClickCollectReward;
        ChestActionsManager.clickedOnUseGems += onClickUseGems;
    }

    private void onClickUseGems(int slotNum)
    {
        controller = ChestService.createdChests[slotNum].GetComponent<ChestController>();
        startingGems -=  controller.cost;
        updateData(startingCoins, startingGems);
    }

    private void onClickCollectReward(int slotNum)
    {
        controller = ChestService.createdChests[slotNum].GetComponent<ChestController>();
        startingCoins += controller.numCoins;
        startingGems += controller.numGems;
        updateData(startingCoins, startingGems);
    }

    private void updateData(int startingCoins, int startingGems)
    {
        coinsText.text = startingCoins.ToString();
        gemsText.text = startingGems.ToString();
    }
}

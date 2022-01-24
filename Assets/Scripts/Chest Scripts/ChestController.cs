using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChestController : MonoBehaviour
{
    private ChestModel model;
    private ChestActionsManager chestActions;

    public static event Action<int, int, int, int> clickedOnChest;

    private Button chestButton;

    private int cost;
    private int numCoins;
    private int numGems;
    private int unlockTime;
    private int id;
    private int slotNum;

    private void Start()
    {
        
    }

    public void init(ChestModel model, int slotNum)
    {
        this.model = model;
        this.slotNum = slotNum;
        setLocalValues();
        Debug.Log(this.model.name + " created with id " + id);

        chestButton = this.GetComponent<Button>();
        chestButton.onClick.AddListener(onChestClick);
    }

    private void onChestClick()
    {
        Debug.Log("Cost - " + cost + ", Unlock Time - " + unlockTime);
        clickedOnChest?.Invoke(unlockTime, cost, id, slotNum);
        chestButton.enabled = false;
    }

    private void setLocalValues()
    {
        cost = model.cost;
        numCoins = UnityEngine.Random.Range(model.min_coins, model.max_coins);
        numGems = UnityEngine.Random.Range(model.min_gems, model.max_gems);
        unlockTime = model.unlockTime;
        id = model.id;
    }
}

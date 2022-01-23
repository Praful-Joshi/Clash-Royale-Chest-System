using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChestController : MonoBehaviour
{
    private ChestModel model;
    private ChestActionsManager chestActions;

    public static event Action<int, int> clickedOnChest;

    private Button chestButton;

    private int cost;
    private int numCoins;
    private int numGems;
    private int unlockTime;
    private int id;

    public void init(ChestModel model)
    {
        this.model = model;
        setLocalValues();
        Debug.Log(this.model.name + " created with id " + id);

        chestButton = this.GetComponent<Button>();
        chestButton.onClick.AddListener(onChestCLick);
    }

    private void onChestCLick()
    {
        Debug.Log("Cost - " + cost + ", Unlock Time - " + unlockTime);
        clickedOnChest?.Invoke(unlockTime, cost);
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

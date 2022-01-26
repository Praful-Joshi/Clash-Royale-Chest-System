using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChestController : MonoBehaviour
{
    //events
    public static event Action<int> clickedOnChest;

    //other script ref
    private ChestModel model;

    //declaring components
    private Button chestButton;

    //declaring variables
    internal int cost, numCoins, numGems, id, slotNum;
    internal double unlockTime;

    public void init(ChestModel model, int slotNum)
    {
        this.model = model;
        this.slotNum = slotNum;
        Debug.Log(this.model.name + " created with id " + id);

        setLocalValues();
        
        chestButton = this.GetComponent<Button>();
        chestButton.onClick.AddListener(onChestClick);
    }

    private void onChestClick()
    {
        clickedOnChest?.Invoke(slotNum);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ChestActionsManager : MonoBehaviour
{
    //events
    public static event Action<int> clickedOnStartTimer;
    public static event Action<int> clickedOnUseGems;

    //other script ref
    private ChestController controller;

    //declaring components
    public Button useGemsButton;
    public GameObject chestActions;
    public List<TextMeshProUGUI> texts;

    //declaring variables
    private int slotNum;
    private bool haveEnoughGems;


    // Start is called before the first frame update
    void Start()
    {
        ChestController.clickedOnChest += onClickChest;
    }

    private void onClickChest(int slotNum)
    {
        this.slotNum = slotNum;
        controller = ChestService.createdChests[slotNum].GetComponent<ChestController>();

        haveEnoughGems = controller.cost <= InventoryManager.startingGems;
        useGemsButton.enabled = haveEnoughGems;

        updateText();
        chestActions.SetActive(true);
    }

    private void updateText()
    {
        TimeSpan time = TimeSpan.FromMinutes(ChestService.createdChests[slotNum].GetComponent<ChestController>().unlockTime);
        texts[0].text = time.Hours.ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString();
        texts[1].text = ChestService.createdChests[slotNum].GetComponent<ChestController>().cost.ToString();
    }

    public void onClickStartTimer()
    {
        clickedOnStartTimer?.Invoke(slotNum);
        chestActions.SetActive(false);
    }

    public void onClickUseGems()
    {
        clickedOnUseGems?.Invoke(slotNum);
        chestActions.SetActive(false);
    }
}

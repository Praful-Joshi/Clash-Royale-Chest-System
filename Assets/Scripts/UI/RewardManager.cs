using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RewardManager : MonoBehaviour
{
    //events
    public static event Action<int> clickedOnCollectReward;

    //other script ref
    private ChestController controller;

    //declaring components
    public List<Button> collectRewardButtons;
    public List<TextMeshProUGUI> coinsTexts, gemsTexts;
    public List<GameObject> rewardObjects;

    //declaring variables
    private int slotNum, rewardCoins, rewardGems;

    // Start is called before the first frame update
    void Start()
    {
        TimerManager.timerCompleted += rewardsLogic;
        ChestActionsManager.clickedOnUseGems += rewardsLogic;
    }

    private void rewardsLogic(int slotNum)
    {
        this.slotNum = slotNum;
        controller = ChestService.createdChests[slotNum].GetComponent<ChestController>();
        this.rewardCoins = controller.numCoins;
        this.rewardGems = controller.numGems;
        StartCoroutine(timerCompleteLogic(slotNum));
    }

    private IEnumerator timerCompleteLogic(int slotNum)
    {
        yield return new WaitForSeconds(0.2f);
        coinsTexts[slotNum].text = rewardCoins.ToString();
        gemsTexts[slotNum].text = rewardGems.ToString();
        rewardObjects[slotNum].SetActive(true);
    }

    public void onClickCollectReward(int slotNum)
    {
        clickedOnCollectReward?.Invoke(slotNum);
        rewardObjects[slotNum].SetActive(false);
    }
}

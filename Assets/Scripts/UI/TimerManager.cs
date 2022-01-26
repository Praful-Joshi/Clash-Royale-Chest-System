using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using TMPro;
using System;

public class TimerManager : MonoBehaviour
{
    //events
    public static event Action<int> timerCompleted;

    //other script ref
    public List<Timer> timers;

    //declaring components
    public List<GameObject> timerGameObjects;

    //declaring variables
    private bool isTimerRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        ChestActionsManager.clickedOnStartTimer += onClickStartTimer;
        RewardManager.clickedOnCollectReward += onClickCollectReward;
    }

    private void onClickStartTimer(int slotNum)
    {
        timerGameObjects[slotNum].SetActive(true);
        StartCoroutine(timerLogic(slotNum, ChestService.createdChests[slotNum].GetComponent<ChestController>().unlockTime));
    }

    private IEnumerator timerLogic(int slotNum, double unlockTime)
    {
        if (isTimerRunning == false)
        {
            StartCoroutine(startTimer(slotNum, unlockTime));
        }
        else
        {
            timers[slotNum].GetComponent<TextMeshProUGUI>().text = "In Queue";
            yield return new WaitUntil(() => isTimerRunning == false);
            StartCoroutine(startTimer(slotNum, unlockTime));
        }
    }

    private IEnumerator startTimer(int slotNum, double unlockTime)
    {
        isTimerRunning = true;
        timers[slotNum].startTimer(unlockTime);
        yield return new WaitUntil(() => timers[slotNum].currentTime <= 0);
        timers[slotNum].GetComponent<TextMeshProUGUI>().text = "Done!!!";
        timerCompleted?.Invoke(slotNum);
        isTimerRunning = false;
    }

    private void onClickCollectReward(int slotNum)
    {
        timerGameObjects[slotNum].SetActive(false);
    }
}

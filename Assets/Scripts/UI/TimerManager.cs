using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using TMPro;
using System;

public class TimerManager : MonoBehaviour
{
    public static event Action<int> timerCompleted;

    public List<Timer> timers;
    private bool isTimerRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        ChestActionsManager.clickedOnStartTimer += onClickStartTimer;
    }

    private void onClickStartTimer(int slotNum, double unlockTime)
    {
        StartCoroutine(timerLogic(slotNum, unlockTime));
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
        timers[slotNum].startTimer(unlockTime, slotNum);
        yield return new WaitUntil(() => timers[slotNum].currentTime <= 0);
        timers[slotNum].GetComponent<TextMeshProUGUI>().text = "Done!!";
        timerCompleted?.Invoke(slotNum);
        isTimerRunning = false;
    }
}

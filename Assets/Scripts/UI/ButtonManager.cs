using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static event Action clickedOnGenerateChests;

    public Button generateChestButton;
    public List<GameObject> timers;

    private void Start()
    {
        ChestActionsManager.clickedOnStartTimer += onClickStartTimer;
    }

    public void onClickGenerateChests()
    {
        clickedOnGenerateChests?.Invoke();
        generateChestButton.enabled = false;
    }

    private void onClickStartTimer(int slotNum, double unlockTime)
    {
        switch (slotNum)
        {
            case 0:
                timers[0].SetActive(true);
                break;
            case 1:
                timers[1].SetActive(true);
                break;
            case 2:
                timers[2].SetActive(true);
                break;
            case 3:
                timers[3].SetActive(true);
                break;
            default:
                break;
        }
    }
}

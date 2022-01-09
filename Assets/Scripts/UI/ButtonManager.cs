using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonManager : MonoBehaviour
{
    private ChestService chestService;

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject chest1;
    public GameObject chest2;
    public GameObject chest3;
    public GameObject chest4;
    public GameObject chestActions;
    public GameObject startTimer;
    public GameObject useGems;

    public static event Action clickedUseGems;
    public static event Action clickedChest;

    private void Awake()
    {
        chestService = this.GetComponent<ChestService>();
    }

    private void Start()
    {
        
    }

    public void onClickChest()
    {
        clickedChest?.Invoke();
        chestActions.SetActive(true);
    }

    public void onClickSlot(int slotNum)
    {
        switch(slotNum)
        {
            case 1:
                chest1.SetActive(true);
                break;
            case 2:
                chest2.SetActive(true);
                break;
            case 3:
                chest3.SetActive(true);
                break;
            case 4:
                chest4.SetActive(true);
                break;
            default:
                Debug.Log("Press correct button");
                break;
        }
        chestService.onClickSlot();
    }

    public void onClickStartTimer()
    {
        disableAll();
        //start timer logic
    }

    public void onClickUseGems()
    {
        clickedUseGems?.Invoke();
        disableAll();
        //use gems logic
    }

    public void disableAll()
    {
        chestActions.SetActive(false);
        chest1.SetActive(false);
        chest2.SetActive(false);
        chest3.SetActive(false);
        chest4.SetActive(false);
    }
}

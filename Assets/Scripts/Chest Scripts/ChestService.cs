using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChestService : MonoBehaviour
{
    //other script ref
    private ChestModel model;
    private ChestController controller;
    private ChestSO chestSO;
    public ChestSO[] chestSOList;

    //declaring components
    public GameObject canvas;
    public static GameObject[] createdChests;

    //declaring variables
    public List<Vector3> spawnPositions;


    void Start()
    {
        createdChests = new GameObject[4];

        TimerManager.timerCompleted += deactivateChest;
        ChestActionsManager.clickedOnUseGems += deactivateChest;
    }

    public void spawnChests()
    {        
        for(int i = 0; i < 4; i++)
        {
            createdChests[i]  = createNewChest(spawnPositions[i], i);
        }
    }

    private GameObject createNewChest(Vector3 spawnPos, int slotNum)
    {
        int value = UnityEngine.Random.Range(1, 51);
        if (value >= 1 && value <= 30)
        {
            chestSO = chestSOList[0];
        }
        else if (value >= 31 && value <= 42)
        {
            chestSO = chestSOList[1];
        }
        else if (value >= 43 && value <= 47)
        {
            chestSO = chestSOList[2];
        }
        else if (value >= 48 && value <= 50)
        {
            chestSO = chestSOList[3];
        }

        model = new ChestModel(chestSO);
        GameObject instance = Instantiate(model.prefab, spawnPos, Quaternion.identity);
        instance.transform.SetParent(canvas.transform, false);

        controller = instance.GetComponent<ChestController>();
        controller.init(model, slotNum);
        return instance;
    }

    private void deactivateChest(int slotNum)
    {
        createdChests[slotNum].SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : MonoBehaviour
{
    private int cost;
    private int num_coins;
    private int num_gems;
    private float timer;

    private ChestModel model;
    public ChestSO[] chestSOList;
    private ChestSO chestSO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createNewChest()
    {
        chestSO = chestSOList[Random.Range(0, 4)];
        model = new ChestModel(chestSO);
        cost = model.cost;
        num_coins = Random.Range(model.min_coins, model.max_coins);
        num_gems = Random.Range(model.min_gems, model.max_gems);
        timer = model.timer;
    }

    public int getCost()
    {
        return cost;
    }

    public int getNumCoins()
    {
        return num_coins;
    }

    public int getNumGems()
    {
        return num_gems;
    }

    public float getTimer()
    {
        return timer;
    }

    internal void onClickSlot()
    {
        createNewChest();
        Debug.Log(model.name + " created");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryService : MonoBehaviour
{
    private int cost_value = 0;
    public int num_gems_value = 40;
    public int num_coins_value = 100;

    private ChestService chestService;

    public TextMeshProUGUI num_coins;
    public TextMeshProUGUI num_gems;
    public TextMeshProUGUI cost;

    private void Awake()
    {
        chestService = this.GetComponent<ChestService>();

        num_coins.text = num_coins_value.ToString();
        num_gems.text = num_gems_value.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        ButtonManager.clickedChest += updateCost;
        ButtonManager.clickedUseGems += updateNumGems;
        ButtonManager.clickedUseGems += updateNumCoins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateCost()
    {
        cost_value = chestService.getCost();
        cost.text = cost_value.ToString();
    }

    private void updateNumCoins()
    {
        num_coins_value += chestService.getNumCoins();
        num_coins.text = num_coins_value.ToString();
    }

    private void updateNumGems()
    {
        num_gems_value = (num_gems_value - cost_value) + chestService.getNumGems();
        num_gems.text = num_gems_value.ToString();
    }
}

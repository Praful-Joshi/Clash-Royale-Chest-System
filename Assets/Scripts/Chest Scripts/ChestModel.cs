using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestModel
{
    internal string name;
    internal int id, min_coins, max_coins, min_gems, max_gems, cost;
    internal double unlockTime;
    internal GameObject prefab;

    internal ChestModel(ChestSO chestSO)
    {
        name = chestSO.Name;
        id = chestSO.id;
        min_coins = chestSO.min_coins;
        max_coins = chestSO.max_coins;
        min_gems = chestSO.min_gems;
        max_gems = chestSO.max_gems;
        unlockTime = chestSO.unlockTime;
        cost = chestSO.cost;
        prefab = chestSO.prefab;
    }
}

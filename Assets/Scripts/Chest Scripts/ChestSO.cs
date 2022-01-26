using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Chest Scriptable Object", menuName = "Scriptable Object/New Chest")]
public class ChestSO : ScriptableObject
{
    public string Name;
    public int id, min_coins, max_coins, min_gems, max_gems, cost;
    public double unlockTime;
    public GameObject prefab;
}

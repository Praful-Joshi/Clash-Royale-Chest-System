using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Chest Scriptable Object", menuName = "Scriptable Object/New Chest")]
public class ChestSO : ScriptableObject
{
    public string Name;
    public int id;
    public int min_coins;
    public int max_coins;
    public int min_gems;
    public int max_gems;
    public double unlockTime;
    public int cost;
    public GameObject prefab;
}

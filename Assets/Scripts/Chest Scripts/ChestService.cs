using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : MonoBehaviour
{
    private ChestModel model;
    public ChestSO[] chestSOList;
    private ChestSO chestSO;

    // Start is called before the first frame update
    void Start()
    {
        createNewChest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createNewChest()
    {
        chestSO = chestSOList[Random.Range(0, 4)];
        model = new ChestModel(chestSO);
        Debug.Log(model.name + " created");
    }

    public void onClickChest()
    {
        Debug.Log("You unlocked " + model.name);
    }
}

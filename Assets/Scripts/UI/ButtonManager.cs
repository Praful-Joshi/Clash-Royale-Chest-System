using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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



    private void Awake()
    {
        chestService = this.GetComponent<ChestService>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickChest()
    {
        chestService.onClickChest();
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
    }

    public void onClickStartTimer()
    {
        disableAll();
        //start timer logic
    }

    public void onClickUseGems()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static event Action clickedOnGenerateChests;

    public Button generateChestButton;

    public void onClickGenerateChests()
    {
        clickedOnGenerateChests?.Invoke();
        generateChestButton.enabled = false;
    }
}

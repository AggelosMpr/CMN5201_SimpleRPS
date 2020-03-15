using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMenu : MonoBehaviour
{
    public GameObject InfoPanel;

    bool isActive;

    public void onInfoButtonClicked()
    {
        if (isActive)
        {
            InfoPanel.SetActive(true);
            isActive = false;
        }
        else
        {
            InfoPanel.SetActive(false);
            isActive = true;
        }


    }
}
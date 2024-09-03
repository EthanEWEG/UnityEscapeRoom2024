using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBigCodeLock : MonoBehaviour
{
    public GameObject CodelockBIG;
    public GameObject OverlayPanel;
    public GameObject noteBIG;


    public void ShowButton(string buttonType)
    {
        if (buttonType == "note")
        {
            noteBIG.SetActive(true);
        }
        else
        {
            CodelockBIG.SetActive(true);
        }
        OverlayPanel.SetActive(true);
    }

    public void HideButton()
    {
        noteBIG.SetActive(false);
        CodelockBIG.SetActive(false);
        OverlayPanel.SetActive(false);
    }
}

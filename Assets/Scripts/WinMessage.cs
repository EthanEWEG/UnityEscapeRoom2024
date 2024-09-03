using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WinMessage : MonoBehaviour
{
    //text GameObject
    public TMP_Text escapeMSG;
    //current dateTime
    DateTime time = DateTime.Now;

    // Start is called before the first frame update
    void Start()
    {
        //current time
        //converts the string back to DateTime object
        DateTime dateTime1 = DateTime.ParseExact(StaticData.dateTime, "yyyy-MM-dd HH:mm:ss", null);

        //calculates the difference
        TimeSpan difference = time - dateTime1;
        //turns difference into minutes
        double minutesDifference = difference.TotalMinutes;

        escapeMSG.text = "You escaped the submarine in "
            + minutesDifference.ToString("F2") + " minutes. " +
            "Thanks for playing!\nGame by Ethan EG";
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintText : MonoBehaviour
{
    //hint text
    public TMP_Text hintText;

    //decides which hint text to display 
    public void HintTextDecider()
    {
        if (StaticData.leverCover == false)
        {
            hintText.text = "The code is based on the time (past noon) and the levers are based on the status screen.";
        }
        else if (StaticData.lockedRight == false)
        {
            hintText.text = "Every letter in the alphabet has a numerical value.";
        }
        else if (StaticData.lockedLeft == false)
        {
            hintText.text = "There is a pattern to the sparking sounds.";
        }
        else if (StaticData.doorCode == false)
        {
            hintText.text = "There seems to be missing letters on the rules board.";
        }
        else if (StaticData.fishCode == false)
        {
            hintText.text = "Each light is flickering a specific amount of times...";
        }
        else if (StaticData.crackCode == false)
        {
            hintText.text = "The code starts with 7. The rest has something to do with the fish.";
        }
        else
        {
            hintText.text = "There are some distinct cracks above the 'windows'.";
        }
    }
}

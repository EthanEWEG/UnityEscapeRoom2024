using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    //codelocks
    public static bool doorCode = true;
    public static bool crackCode = true;
    public static bool exitCode = true;
    public static bool fishCode = true;

    //covers (need to be initialized to true)
    public static bool doorCover = true;
    public static bool fishCover = true;
    public static bool leverCover = false;

    //exit
    public static bool exitLadder = false;

    //door wheel
    public static bool doorWheel = false;

    //stopLightFlickering
    public static bool stopLightFlicker = false;

    //levers
    public static bool[] leverUPs = new bool[8];
    public static bool[] leverDOWNs = new bool[8];

    //screens for control room
    public static bool securityCode = true;
    public static bool securityCodeInteractable = true;
    public static bool status = false;
    public static bool powerCode = false;
    public static bool leverAccessCode = false;
    public static bool lockedLeft = true;
    public static bool lockedRight = true;
    public static bool powerON = false;
    public static bool leversUnlocked = false;

    // Method to initialize the lever values
    public static void InitializeLeverStates()
    {
        for (int i = 0; i < leverUPs.Length; i++)
        {
            leverUPs[i] = true;
        }

        for (int i = 0; i < leverDOWNs.Length; i++)
        {
            leverDOWNs[i] = false;
        }
    }

    //tracks game time 
    public static string dateTime;

    //to track whether or not a different menu is up that should be closed instead of opening pause menu
    public static bool dontPause;

    //required because dont want the Ladder sfx to contiuously play since its in the update method
    public static bool updateFlag = true;
}

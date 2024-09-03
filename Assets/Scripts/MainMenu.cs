using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    public GameObject IntroLetter;
    public GameObject ContinueButton;

    public void PlayGame()
    {
        StaticData.doorCode = true;
        StaticData.crackCode = true;
        StaticData.exitCode = true;
        StaticData.fishCode = true;

        //covers (need to be initialized to true)
        StaticData.doorCover = true;
        StaticData.fishCover = true;
        StaticData.leverCover = true;

        //exit
        StaticData.exitLadder = false;

        //door wheel
        StaticData.doorWheel = false;

        //stopLightFlickering
        StaticData.stopLightFlicker = false;

        //screens for control room
        StaticData.securityCode = true;
        StaticData.securityCodeInteractable = true;
        StaticData.status = false;
        StaticData.powerCode = false;
        StaticData.leverAccessCode = false;
        StaticData.lockedLeft = true;
        StaticData.lockedRight = true;
        StaticData.powerON = false;
        StaticData.leversUnlocked = false;

        //reinitialize the lever arrays
        for (int i = 0; i < StaticData.leverUPs.Length; i++)
        {
            StaticData.leverUPs[i] = true;  // or true, depending on your requirement
            StaticData.leverDOWNs[i] = false;  // or true, depending on your requirement
        }

        //restarts time
        //gets the current dateTime
        DateTime time = DateTime.Now;
        StaticData.dateTime = time.ToString("yyyy-MM-dd HH:mm:ss");

        //loads the next scene in the build which the mainArea
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("EXITING GAME");
        Application.Quit();
    }
}

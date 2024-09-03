using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    //coderbehaviour object
    public CodeBehaviour codeBehaviour;

    //Codelocks
    public Button doorCode;
    public Button crackCode;
    public Button fishCode;
    public Button exitCode;
    //Covers
    public GameObject doorCover;
    public GameObject fishCover;
    public GameObject leverCover;
    //exit
    public GameObject exitLadder;
    //door wheel
    public Button doorWheel;
    //levers
    public GameObject[] LeverUPs;
    public GameObject[] LeverDOWNs;

    public void Start()
    {
        //ALL buttons except levers
        doorCode.interactable = StaticData.doorCode;
        crackCode.interactable = StaticData.crackCode;
        fishCode.interactable = StaticData.fishCode;
        exitCode.interactable = StaticData.exitCode;
        doorWheel.interactable = StaticData.doorWheel;

        //images
        doorCover.SetActive(StaticData.doorCover);
        fishCover.SetActive(StaticData.fishCover);
        leverCover.SetActive(StaticData.leverCover);
        exitLadder.SetActive(StaticData.exitLadder);

        //levers
        // Initialize the lever states if needed
        if (StaticData.leverUPs[0] == false && StaticData.leverDOWNs[0] == false)
        {
            StaticData.InitializeLeverStates();
        }
        for (int i = 0; i < LeverUPs.Length; i++)
        {
            LeverUPs[i].SetActive(StaticData.leverUPs[i]);
        }
        for (int i = 0; i < LeverDOWNs.Length; i++)
        {
            LeverDOWNs[i].SetActive(StaticData.leverDOWNs[i]);
        }

        //lights
        if (!StaticData.stopLightFlicker && StaticData.doorCover == true)
        {
            return;
        }
        else if (StaticData.stopLightFlicker)
        {
            codeBehaviour.StopLightFlashing();
        }
        else
        {
            codeBehaviour.StartLightFlashing();
        }
    }

    //Swap scenes
    public void SwitchToControl()
    {
        //ALL buttons except levers
        StaticData.doorCode = doorCode.interactable;
        StaticData.crackCode = crackCode.interactable;
        StaticData.fishCode = fishCode.interactable;
        StaticData.exitCode = exitCode.interactable;
        StaticData.doorWheel = doorWheel.interactable;

        //images
        StaticData.doorCover = doorCover.activeSelf;
        StaticData.fishCover = fishCover.activeSelf;
        StaticData.leverCover = leverCover.activeSelf;
        StaticData.exitLadder = exitLadder.activeSelf;

        //levers
        for (int i = 0; i < LeverUPs.Length; i++)
        {
            StaticData.leverUPs[i] = LeverUPs[i].activeSelf;
        }
        for (int i = 0; i < LeverDOWNs.Length; i++)
        {
            StaticData.leverDOWNs[i] = LeverDOWNs[i].activeSelf;
        }

        //Debug.Log(StaticData.doorCode);
        SceneManager.LoadScene("ControlRoom");
    }

    public void SwitchToWin()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void SwitchToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

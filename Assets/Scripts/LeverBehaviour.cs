using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverBehaviour : MonoBehaviour
{
    //Lever objects
    public GameObject[] LeverUPs;
    public GameObject[] LeverDOWNs;
    public Button CodelockEXIT;
    public GameObject ExitLadder;

    //for the sfx
    public AudioSource exitLadderSFX;

    void Update()
    {
        //opens exit when all conditions met
        if (CodelockEXIT.interactable == false && LeverOrder() && StaticData.updateFlag)
        {
            exitLadderSFX.Play();
            ExitLadder.SetActive(true);
            StaticData.updateFlag = false;
        }
    }
    
    //Swaps levers from up to down when clicked based on array index
    public void LeverSwap(int leverNumber)
    {
        if (leverNumber >= 8)
        {
            LeverDOWNs[leverNumber - 8].SetActive(false);
            LeverUPs[leverNumber - 8].SetActive(true);
        }
        else
        { 
            LeverDOWNs[leverNumber].SetActive(true);
            LeverUPs[leverNumber].SetActive(false);
        }
    }

    //The direction which the levers need to be flicked
    public bool LeverOrder()
    {
        return (LeverUPs[0].activeSelf == false && 
            LeverUPs[1].activeSelf == true && 
            LeverUPs[2].activeSelf == false &&
            LeverUPs[3].activeSelf == false &&
            LeverUPs[4].activeSelf == true &&
            LeverUPs[5].activeSelf == false &&
            LeverUPs[6].activeSelf == false &&
            LeverUPs[7].activeSelf == true);
    }

}

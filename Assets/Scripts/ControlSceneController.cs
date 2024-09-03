using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlSceneController : MonoBehaviour
{
    //Store screen statuses for when you leave and return to the scene
    public GameObject securityCode;
    public Button securityCodeInteractable;
    public GameObject status;
    public Button powerCode;
    public Button leverAccessCode;
    public GameObject lockedLeft;
    public GameObject lockedRight;
    public GameObject powerON;
    public GameObject leversUnlocked;

    //Start is called before the first frame update
    void Start()
    {
        //set screen states to their stored value
        securityCode.SetActive(StaticData.securityCode);
        securityCodeInteractable.interactable = StaticData.securityCodeInteractable;
        status.SetActive(StaticData.status);
        powerCode.interactable = StaticData.powerCode;
        leverAccessCode.interactable = StaticData.leverAccessCode;
        lockedLeft.SetActive(StaticData.lockedLeft);
        lockedRight.SetActive(StaticData.lockedRight);
        powerON.SetActive(StaticData.powerON);
        leversUnlocked.SetActive(StaticData.leversUnlocked);

    }

    public void SwitchToMain()
    {
        //save screen states
        StaticData.securityCode = securityCode.activeSelf;
        StaticData.securityCodeInteractable = securityCodeInteractable.interactable;
        StaticData.status = status.activeSelf;
        StaticData.powerCode = powerCode.interactable;
        StaticData.leverAccessCode = leverAccessCode.interactable;
        StaticData.lockedLeft = lockedLeft.activeSelf;
        StaticData.lockedRight = lockedRight.activeSelf;
        StaticData.powerON = powerON.activeSelf;
        StaticData.leversUnlocked = leversUnlocked.activeSelf;

        //load main scene
        SceneManager.LoadScene("MainArea");
    }

    //to go back to menu
    public void SwitchToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

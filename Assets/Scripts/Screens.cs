using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Screens : MonoBehaviour
{

    [SerializeField]
    //references which screen is up
    int screenFlag;
    //input references
    public TMP_InputField securityCodeInput;
    public TMP_InputField powerCodeInput;
    public TMP_InputField leverCodeInput;

    //small screen references
    public GameObject lockedLeft;
    public GameObject lockedRight;
    public GameObject powerON;
    public GameObject leversUnlocked;
    public GameObject status;

    //buttons
    public Button powerButton;
    public Button leverAccessButton;
    public Button securityCode;

    //big screen references
    public GameObject bigScreenStatus;
    public GameObject bigScreenPower;
    public GameObject bigScreenLever;
    public GameObject overlayPanel;

    //flash duration
    public float flashDuration = 0.25f;

    void Update()
    {
        //checks if the esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!StaticData.dontPause)
            {
                return;
            }
            else if (StaticData.dontPause)
            {
                bigScreenLever.SetActive(false);
                bigScreenPower.SetActive(false);
                bigScreenStatus.SetActive(false);
                overlayPanel.SetActive(false);
                //starts a coroutine to delay setting dontPause to false
                StartCoroutine(ResetDontPause());
            }
        }
    }

    //sets flag to decide which behaviour is chosen when the right code is entered
    public void SetScreenFlag(int screenFlag)
    {
        this.screenFlag = screenFlag;
    }
    public void SecurityCode()
    {

        if(screenFlag == 1 && securityCodeInput.text == "lerislmprmyc")
        {
            StartCoroutine(Flash(true, securityCodeInput, bigScreenStatus));
            lockedLeft.SetActive(false);
            powerButton.interactable = true;
            status.SetActive(true);
            securityCode.interactable = false;
            StaticData.lockedLeft = false;
            StartCoroutine(ResetDontPause());
        }

        if (screenFlag == 2 && powerCodeInput.text == "2152")
        {
            StartCoroutine(Flash(true, powerCodeInput, bigScreenPower));
            powerButton.interactable = false;
            powerON.SetActive(true);
            lockedRight.SetActive(false);
            leverAccessButton.interactable = true;
            //stops the lights from flickering 
            StaticData.stopLightFlicker = true;
            StaticData.lockedRight = false;
            StartCoroutine(ResetDontPause());
        }
        if (screenFlag == 3 && leverCodeInput.text == "9174")
        {
            StartCoroutine(Flash(true, leverCodeInput, bigScreenLever));
            leverAccessButton.interactable = false;
            leversUnlocked.SetActive(true);
            //Removes the lever cover
            StaticData.leverCover = false;
            StaticData.leverCover = false;
            StartCoroutine(ResetDontPause());
        }
    }

    //ensures max 4 digits for the power and lever codes 
    public void DigitsOnly(TMP_InputField input)
    {
        
        //Puts the input text into a str var
        string inputText = input.text;

        //max length of 4 digits
        if (inputText.Length > 4)
        {
            //truncates text to the first 4 characters
            inputText = inputText.Substring(0, 4);
            //updates the input field with truncated text
            input.text = inputText;
        }

        
        for (int i = 0; i < inputText.Length; i++)
        {
            if (!char.IsDigit(inputText[i]))
            {
                //only allow digits
                inputText = inputText.Remove(i, 1);
                i--;
            }
        }


        //Updates the input text field with the new text (ensuring only 4 digits)
        input.text = inputText;
        
    }

    //Animation for succesful input
    private IEnumerator Flash(bool flag, TMP_InputField inputField, GameObject screen)
    {
        //Store original color
        Color originalColor = inputField.textComponent.color;
        //decides whether or not to hide big codelock
        bool hideScreen = false;
        //Sets text to green animation and then closes the big screen. Red animation is never used for these screens.
        if (!flag)
        {
            inputField.textComponent.color = Color.red;
        }
        else
        {
            inputField.textComponent.color = Color.green;
            hideScreen = true;
        }
        
        //time delay
        yield return new WaitForSeconds(flashDuration);

        //clear the text
        inputField.textComponent.text = "";

        //restore original color
        inputField.textComponent.color = originalColor;

        //hide big screen + overlay(disables background buttons)
        if (hideScreen)
        {
            screen.SetActive(false);
            overlayPanel.SetActive(false);
        }

    }

    //checks to see if screen is open. This way esc closes the screen instead of opening pause menu
    public void ScreenUp()
    {
        StaticData.dontPause = true;
    }
    public void ScreenDown()
    {
        StaticData.dontPause = false;
    }

    //waits for the end of the current frame. Otherwise the other update method in PauseMenu opens the pause menu instantaneously
    private IEnumerator ResetDontPause()
    {
        yield return new WaitForEndOfFrame();
        StaticData.dontPause = false;
    }
}

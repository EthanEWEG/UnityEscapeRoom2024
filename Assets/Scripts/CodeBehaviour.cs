using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeBehaviour : MonoBehaviour {

    [SerializeField]
    int codeFlag;
    [SerializeField]
    TextMeshProUGUI codeText; 
    string codeValue = "";
    public GameObject CodelockBIG;
    public GameObject FishCover;
    public GameObject DoorCover;
    public GameObject LeverCover;
    public ShowBigCodeLock showBIG;
    //flash duration
    public float flashDuration = 0.25f;
    //lights
    public GameObject LightON1;
    public GameObject LightON2;
    public GameObject LightON3;
    public GameObject LightON4;
    public GameObject CodeLightOff;
    //small codelocks (so they can be disabled)
    public Button CodelockDOOR;
    public Button CodelockCRACK;
    public Button CodelockFISH;
    public Button CodelockEXIT;
    //to activate the door wheel
    public Button DoorWheel;
    //note 
    public GameObject bigNote;
    //overlay panel
    public GameObject overlayPanel;


    // Update is called once per frame
    void Update()
    {
        //resets codelock text when its closed
        codeText.text = codeValue;
        if (CodelockBIG.activeSelf == false)
        {
            codeValue = "";
        }

        //checks if the esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!StaticData.dontPause)
            {
                return;
            }
            else if (StaticData.dontPause)
            {
                CodelockBIG.SetActive(false);
                bigNote.SetActive(false);
                overlayPanel.SetActive(false);
                //starts a coroutine to delay setting dontPause to false
                StartCoroutine(ResetDontPause());
            }
        }
    }

    public void StartLightFlashing()
    {
        StartCoroutine(LightFlash1());
        StartCoroutine(LightFlash2());
        StartCoroutine(LightFlash3());
        StartCoroutine(LightFlash4());
    }

    public void StopLightFlashing()
    {
        StopCoroutine(LightFlash1());
        StopCoroutine(LightFlash2());
        StopCoroutine(LightFlash3());
        StopCoroutine(LightFlash4());
        //keeps the lights on
        LightON1.SetActive(true);
        LightON2.SetActive(true);
        LightON3.SetActive(true);
        LightON4.SetActive(true);
        //backwards name
        CodeLightOff.SetActive(true);

    }

    // CODELOCK Button FUNCTIONS
    //gets value from each codelock Button
    public void AddDigit(string digit)
    {
        if (codeText.text.Length < 4)
        {
            codeValue += digit;
        }
    }
    //Clear Codelock text
    public void Clear()
    {
        codeValue = "";
    }

    //sets flag to decide which behaviour is chosen when the right code is entered
    public void SetCodeFlag(int codeFlag)
    {
        this.codeFlag = codeFlag;
    }

    //Decides behaviour of codelock when code is entered
    public void Enter()
    {
        //Crack codelock 
        if (codeFlag == 1 && codeValue == "5714")
        {
            StartCoroutine(Flash(true));
            FishCover.SetActive(false);
            CodelockCRACK.interactable = false;
            StaticData.crackCode = false;
            StartCoroutine(ResetDontPause());
            return;
        }

        //Fish codelock
        if (codeFlag == 2 && codeValue == "7164")
        {
            StartCoroutine(Flash(true));
            DoorCover.SetActive(false);
            CodeLightOff.SetActive(true);
            StartLightFlashing();
            CodelockFISH.interactable = false;
            StaticData.fishCode = false;
            StartCoroutine(ResetDontPause());
            return;
        }

        //Door codelock
        if (codeFlag == 3 && codeValue == "5213")
        {
            StartCoroutine(Flash(true));
            CodelockDOOR.interactable = false;
            DoorWheel.interactable = true;
            StaticData.doorCode = false;
            StartCoroutine(ResetDontPause());
            return;
        }

        //Exit codelock
        if (codeFlag == 4 && codeValue == "1941")
        {
            StartCoroutine(Flash(true));
            CodelockEXIT.interactable = false;
            StartCoroutine(ResetDontPause());
            return;
        }

        //Effect to demonstrate wrong code was entered
        StartCoroutine(Flash(false));
    }

    private IEnumerator Flash(bool flag)
    {
        //Store original color
        Color originalColor = codeText.color;
        //decides whether or not to hide big codelock
        bool hideCodelock = false;
        //Set text color to red or green
        if (!flag)
        {
            codeText.color = Color.red;
        }
        else
        {
            codeText.color = Color.green;
            hideCodelock = true;
        }

        //time delay
        yield return new WaitForSeconds(flashDuration);

        //Clear the text
        codeValue = "";

        //Restore original color
        codeText.color = originalColor;

        //hide big codelock
        if (hideCodelock)
        {
            showBIG.HideButton();
        }

    }
    //Light 1
    private IEnumerator LightFlash1()
    {
        int i;
        while (true)
        {
            LightON1.SetActive(true);
            i = 0;
            //time delay
            yield return new WaitForSeconds(2f);
            while (i <= 4)
            {
                LightON1.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                LightON1.SetActive(true);
                yield return new WaitForSeconds(0.26f);
                i++;
            }
        }
    }
    //Light 2
    private IEnumerator LightFlash2()
    {
        int i; 
        while (true)
        {
            LightON2.SetActive(true);
            i = 0;
            //time delay
            yield return new WaitForSeconds(9f);
            while (i <= 1)
            {
                LightON2.SetActive(false);
                yield return new WaitForSeconds(0.13f);
                LightON2.SetActive(true);
                yield return new WaitForSeconds(0.06f);
                i++;
            }
        }
    }
    //Light 3
    private IEnumerator LightFlash3()
    {
        while (true)
        {
            Debug.Log("Light 3 Flashing");
            LightON3.SetActive(true);
            //time delay
            yield return new WaitForSeconds(3f);
            LightON3.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
    }
    //Light 4
    private IEnumerator LightFlash4()
    {
        int i;
        while (true)
        {
            LightON4.SetActive(true);
            i = 0;
            //time delay
            yield return new WaitForSeconds(6f);
            while (i <= 2)
            {
                LightON4.SetActive(false);
                yield return new WaitForSeconds(0.12f);
                LightON4.SetActive(true);
                yield return new WaitForSeconds(0.23f);
                i++;
            }
        }
    }

    //checks to see if a note or codelock is open. This way esc closes that instead of opening pause menu
    public void CodeOrNoteUp()
    {
        StaticData.dontPause = true;
    }
    public void CodeOrNoteDown()
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

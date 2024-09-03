using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GeneralSceneController : MonoBehaviour
{

    public void SwitchToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SwitchToWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }
}

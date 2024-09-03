using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    //background panel to disable being able to click stuff in background
    public GameObject overlayPanel;

    private bool isPaused = false;
    void Update()
    {
        //checks if the esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape) && !StaticData.dontPause)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        //Resumes game time
        Time.timeScale = 1f;
        overlayPanel.SetActive(false);
        isPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        //Freezes game time
        Time.timeScale = 0f;
        overlayPanel.SetActive(true);
        isPaused = true;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

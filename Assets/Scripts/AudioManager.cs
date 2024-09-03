using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;

    //Keeps music from reseting every time you switch scenes
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //subscribes to the sceneLoaded event
            SceneManager.sceneLoaded += OnSceneLoaded;
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Starts audio
        audioSource.Play();
    }

    //prevents memory leaks
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //checks if the loaded scene is the Menu
        if (scene.name == "Menu" || scene.name == "WinScene")
        {
            //stops the audio
            audioSource.Stop();
        }
        else
        {
            //Only plays the audio if it wasnt already playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

}

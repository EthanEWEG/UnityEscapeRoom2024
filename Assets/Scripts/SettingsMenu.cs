using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    //references UI slider
    public Slider volumeSlider;

    //reference to audio mixer
    public AudioMixer audioMixer;

    //current volume
    float currentVolume;

    public void Start()
    {
        if (audioMixer.GetFloat("MasterVolume", out currentVolume))
        {
            //sets the sliders value to match the AudioMixers volume
            volumeSlider.value = currentVolume;
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
}

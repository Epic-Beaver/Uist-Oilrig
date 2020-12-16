using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeBar : MonoBehaviour
{
    float volume = 1f;
    private void Start()
    {
            volume = PlayerPrefs.GetFloat("volume", 1f);
        AudioListener.volume = volume;
        Slider slide = GetComponent("Slider") as Slider;
        slide.value = volume;
    }
    public void changeVolume(float sliderValue)
    {
        AudioListener.volume = sliderValue;
        volume = sliderValue;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("volume", volume);
        Debug.Log("volume: " + volume);
    }

}
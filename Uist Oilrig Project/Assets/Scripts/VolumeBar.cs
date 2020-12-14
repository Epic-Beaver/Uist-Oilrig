using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeBar : MonoBehaviour
{
    public int volumeMod = 20;
    private void Start()
    {
        print("STARTING VOLUME " + AudioListener.volume + "\n");
    }
    public void changeVolume(float sliderValue)
    {
        print("VOLUME " + sliderValue + "\n");
        AudioListener.volume = sliderValue;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip buttonHoverAudio,buttonClickAudio,backButtonClickAudio;

    private void Awake()
    {
        instance = this;
    }
    public void ButtonHoverAudio()
    {
        audioSource.clip = buttonHoverAudio;
        audioSource.Play();
    }
    public void ButtonClickAudio()
    {
        audioSource.clip = buttonClickAudio;
        audioSource.Play();
    }
    public void BackButtonClickAudio()
    {
        audioSource.clip = backButtonClickAudio;
        audioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider slider;
    public AudioSource audioSource;


    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        
    }

    public void ChangeBGM()
    {
    //    AudioSource.
    }
    public void SetLevel(float sliderValue)
    {
        AudioListener.volume = Mathf.Log10(sliderValue) * 20f;
 //       mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
 //       PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        
    }

    public void OnBGMPlay(bool isPlay)
    {
        if(isPlay == false)
        { AudioListener.volume = 0; }

        else { AudioListener.volume = 1; }

    }

}

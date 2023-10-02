using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume2 : MonoBehaviour
{

    GameObject BackgroundMusic;
    AudioSource backmusic;
    

    [SerializeField] Slider _playtime;
    [SerializeField] Slider _volume;
    [SerializeField] AudioClip[] audioclip;



    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); //πË∞Ê¿Ωæ« ¿˙¿Â«ÿµ“
        _volume.value = 0.75f;
    }

    void Update()
    {

        _playtime.SetValueWithoutNotify((backmusic.time / backmusic.clip.length));

    }
    public void SetLevel(float sliderValue)
    {
        backmusic.volume = sliderValue * 1.5f;
       // AudioListener.volume = Mathf.Log10(sliderValue) * 20;

    }

    public void OnBGMPlay(bool isPlay)
    {
        if (isPlay == false)
        { backmusic.volume = 0; }

        else { backmusic.volume = 1; }

    }

    public void OnPlayTimeChang(float value)
    {
        backmusic.time = backmusic.clip.length * value;
    }

    public void MusicSelect1()
    {
        MusicChange(0);
    }

    public void MusicSelect2()
    {
        MusicChange(1);
    }
    public void MusicSelect3()
    {
        MusicChange(2);
    }
    public void MusicSelect4()
    {
        MusicChange(3);
    }
    public void MusicSelect5()
    {
        MusicChange(4);
    }
 

    public void MusicChange(int i)
    {
        backmusic.clip = audioclip[i];
        backmusic.Play();
    }

}

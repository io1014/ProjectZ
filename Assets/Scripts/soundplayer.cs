using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class soundplayer : MonoBehaviour
{

    [SerializeField] AudioSource _bgm;
    [SerializeField] AudioSource _fx;
 // [SerializeField] AudioClip[] _clips;
    [SerializeField] Slider _playtime;
    [SerializeField] Slider _volume;
    void Start()
    {
        _bgm.Play();
        AudioListener.volume = 0.5f;
        
    }

  
    public void OnPlayTimeChang(float value)
    {
        _bgm.time = _bgm.clip.length * value;
    }

    public void OnPlayVolumeChang(float value)
    {
        AudioListener.volume = value * 1.5f;
    }

    public void OnPlayFXChang(float value)
    {
        AudioListener.volume = value * 1.5f;
    }
    void Update()
    {
    /*    if(Input.GetMouseButtonDown(0))
        {
            _bgm.Play();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _bgm.Stop();
        } */

    /*    if(Input.GetKeyDown(KeyCode.A))
        {
            _fx.clip = _clips[Random.Range(0, _clips.Length)];
            _fx.Play();
        } */
        _playtime.SetValueWithoutNotify((_bgm.time / _bgm.clip.length));

    }

    public void OnFxPlay(bool isPlay)
    {
        _fx.mute = !isPlay;
    }



}

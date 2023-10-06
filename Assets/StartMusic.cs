using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
     // ����
     //   GameObject BackgroundMusic; 
     //   AudioSource backmusic;


    // ���� ����
     [SerializeField] AudioSource _bgm;
     [SerializeField] AudioSource _fx;
     [SerializeField] AudioClip[] _clips;
     GameObject BackgroundMusic;


    void Awake()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");

     // ����    backmusic = BackgroundMusic.GetComponent<AudioSource>(); //������� �����ص�


        var soundManagers = FindObjectsOfType<StartMusic>();
        if (soundManagers.Length >= 2)
        {
            Destroy(this.gameObject);
            
        }

        DontDestroyOnLoad(BackgroundMusic);
        //backmusic.clip = auioclip[0];

    }
        void start()
        {
            _fx.clip = _clips[0];
            _bgm.Play();
        // ����      backmusic.Play();
        }

    
    }





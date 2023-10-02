using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{

    GameObject BackgroundMusic;
    AudioSource backmusic;

 //   [SerializeField] AudioClip[] auioclip;


    void Awake()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); //πË∞Ê¿Ωæ« ¿˙¿Â«ÿµ“


        var soundManagers = FindObjectsOfType<StartMusic>();
        if (soundManagers.Length >= 2)
        {
            Destroy(this.gameObject);
            
        }

        DontDestroyOnLoad(BackgroundMusic);
  //      backmusic.clip = auioclip[0];

    }
        void start()
        {

            backmusic.Play();
        }

    
    }





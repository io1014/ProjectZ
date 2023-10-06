using UnityEngine;

public class StartMusic : MonoBehaviour
{
     // 기존
     //   GameObject BackgroundMusic; 
     //   AudioSource backmusic;


    // 새로 변경
     [SerializeField] AudioSource _bgm;
     [SerializeField] AudioSource _fx;
     [SerializeField] AudioClip[] _clips;
     GameObject BackgroundMusic;
    public static StartMusic instance;

    void Awake()
    {
        instance = this;
        BackgroundMusic = GameObject.Find("BackgroundMusic");

     // 기존    backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠


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
       // _fx.clip = _clips[0];
        _bgm.Play();
        // 기존      backmusic.Play();
    }

    public void DoorOpen()
    {
        int randomCount = UnityEngine.Random.Range(0, _clips.Length);
        _fx.clip = _clips[randomCount]; 
        _fx.Play();
    }

    
    }





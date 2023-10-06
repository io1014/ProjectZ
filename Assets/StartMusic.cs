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
    public static StartMusic instance;

    void Awake()
    {
        instance = this;
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

    public void DoorOpen()
    {
        int randomCount = UnityEngine.Random.Range(0, _clips.Length);
        _fx.clip = _clips[randomCount]; 
        _fx.Play();
    }

    
    }





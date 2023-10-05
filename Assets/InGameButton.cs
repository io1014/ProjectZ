using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameButton : MonoBehaviour
{
    [SerializeField] GameObject _exitPanel;
    [SerializeField] GameObject _soundPanel;
    [SerializeField] GameObject _gamePanel;
    [SerializeField] GameObject _inGameOption;

    GameObject BackgroundMusic;
    AudioSource backmusic;

    [SerializeField] Slider _volume;

    bool onOff = false;

    void Start()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        backmusic = BackgroundMusic.GetComponent<AudioSource>();
        _inGameOption.SetActive(onOff);
        AllOffPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(onOff)
            {
                Time.timeScale = 0;
                _inGameOption.SetActive(true);
                onOff = false;
            }

            else
            {
                Time.timeScale = 1;
                _inGameOption.SetActive(false);
                onOff=true;
            }
            
        }
    }

    public void GameOptionOn()
    {
        if (onOff)
        {
            Time.timeScale = 0;
            _inGameOption.SetActive(true);
            onOff = false;
        }

        else
        {
            Time.timeScale = 1;
            _inGameOption.SetActive(false);
            onOff = true;
        }

    }
    public void AllOffPanel()
    {
        _exitPanel.SetActive(false);
        _soundPanel.SetActive(false);
        _gamePanel.SetActive(false);
    }

    public void exitButton()
    {
        AllOffPanel();
        _exitPanel.SetActive(true);
    }

    public void soundButton()
    {
        AllOffPanel();
        _soundPanel.SetActive(true);
    }

    public void gameButton()
    {
        AllOffPanel();
        _gamePanel.SetActive(true);
    }

    public void exitYesButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("IntroGameScene");
    }

    public void exitNoButton()
    {
        AllOffPanel();
    }

    public void gameYesButton()
    {
        Time.timeScale = 1;
        _inGameOption.SetActive(false);

    }

    public void SetLevel(float sliderValue)
    {
        //backmusic.volume = sliderValue * 1.5f;
        AudioListener.volume = sliderValue * 1.5f;

    }

    public void OnBGMPlay(bool isPlay)
    {
        if (isPlay == false)
        { AudioListener.volume = 0; }

        else { AudioListener.volume = 1; }

    }

}

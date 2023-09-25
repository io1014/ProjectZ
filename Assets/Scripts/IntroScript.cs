using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{

    public void IntroToGame()
    {
        SceneManager.LoadScene("Project Z map");
    }

    public void GotoOption()

    {
        SceneManager.LoadScene("Option");
    }

    public void GotoHowToGame()

    {
        SceneManager.LoadScene("HowToGame");
    }

    public void GotoHowExit()

    {
        Application.Quit();
    }

    public void GotoHome()

    {
        SceneManager.LoadScene("IntroGameScene");
    }

}
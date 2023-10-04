using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class IntroScript : MonoBehaviour
{
    [SerializeField] GameObject massage;
    public void IntroToGame()
    {
        massage.SetActive(true);
  //    SceneManager.LoadScene("Project Z map");
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


    public void StarttoGame()

    {
        SceneManager.LoadScene("Project Z map");
    }
}

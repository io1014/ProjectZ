using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MixButtonController : MonoBehaviour
{
    [SerializeField] GameObject _myInven;
    [SerializeField] GameObject _listInven;
    [SerializeField] GameObject _mixInven;
    [SerializeField] GameObject _mixButton;
    [SerializeField] GameObject _CarryInven;
    [SerializeField] GameObject _endButton;
    [SerializeField] GameObject _houseInven;
    [SerializeField] GameObject _text;
    [SerializeField] GameObject _textTrash;


    public void Mixbutton() //mix button를 누를 시
    {
        CleanDisplay();
        showMixIven();

    }

    public void EndMixbutton() //End mix button를 누를 시
    {
        CleanDisplay();
    }
    public void CleanDisplay() // mix button를 누를 시 
    {
        // 모든 창의 SetActive를 false로
        _myInven.SetActive(false);
        _listInven.SetActive(false);
        _mixInven.SetActive(false);
        _mixButton.SetActive(false);
        _CarryInven.SetActive(false);
        _endButton.SetActive(false);
        _houseInven.SetActive(false);   
        _text.SetActive(false);

    }

    public void showMixIven()   // mix button 을 클릭 시 띄울 화면
    {
        _myInven.SetActive(true);
        _listInven.SetActive(true);
        _mixInven.SetActive(true);
        _mixButton.SetActive(true);
        _endButton.SetActive(true);
        _text.SetActive(true);

    }





  
}

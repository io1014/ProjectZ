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


    public void Mixbutton() //mix button�� ���� ��
    {
        CleanDisplay();
        showMixIven();

    }

    public void EndMixbutton() //End mix button�� ���� ��
    {
        CleanDisplay();
    }
    public void CleanDisplay() // mix button�� ���� �� 
    {
        // ��� â�� SetActive�� false��
        _myInven.SetActive(false);
        _listInven.SetActive(false);
        _mixInven.SetActive(false);
        _mixButton.SetActive(false);
        _CarryInven.SetActive(false);
        _endButton.SetActive(false);
        _houseInven.SetActive(false);   
        _text.SetActive(false);

    }

    public void showMixIven()   // mix button �� Ŭ�� �� ��� ȭ��
    {
        _myInven.SetActive(true);
        _listInven.SetActive(true);
        _mixInven.SetActive(true);
        _mixButton.SetActive(true);
        _endButton.SetActive(true);
        _text.SetActive(true);

    }





  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBag : MonoBehaviour

{
    [SerializeField] GameObject _myInven;
    [SerializeField] GameObject _houseInven;
    [SerializeField] GameObject _text;
    public void showInventoey()
    {
        _text.SetActive(false);
        _myInven.SetActive(!_myInven.activeSelf);
        _houseInven.SetActive(!_houseInven.activeSelf);
    }

}

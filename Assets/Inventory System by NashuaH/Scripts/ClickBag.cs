using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBag : MonoBehaviour
{
    [SerializeField] GameObject _myInven;
    [SerializeField] GameObject _houseInven;
    public void showInventoey()
    {
        _myInven.SetActive(!_myInven.activeSelf);
        _houseInven.SetActive(!_houseInven.activeSelf);
    }

}

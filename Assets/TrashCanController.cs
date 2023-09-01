using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanController : MonoBehaviour
{
    [SerializeField] GameObject _myInven;
    [SerializeField] GameObject _houseInven;
    [SerializeField] GameObject _text;
    bool _isText = false;
    public void showInventory()
    {
        _myInven.SetActive(!_myInven.activeSelf);
        _houseInven.SetActive(false);

        if(_myInven.activeSelf == true)
        {
            _text.SetActive(true);
            _isText = true;
        }

        else
        {
            _text.SetActive(false);
            _isText = false;
        }
    }
    private void Update()
    {
        GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().SetText(_isText);
    }
}

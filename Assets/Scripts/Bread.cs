using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bread : MonoBehaviour
{
    GameObject _bread;
    [SerializeField] Image _player;
    private void Start()
    {
        _bread = GetComponent<GameObject>();
    }
    void Update()
    {
        /*if(// 인벤토리에서 빵을 '먹기' 버튼을 누르면)
        {
            bread가 없어지고 player의 체력이 1만큼 채워진다.
        }*/
    }
}

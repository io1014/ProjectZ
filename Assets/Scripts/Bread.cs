using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{
    string _name = "Bread";         // 무기이름
    float _weight = 0.1f;           // 무게
    float _increaseHP = 1f;         // 체력 회복 지수
    float _increaseFull = 1f;       // 배부름 지수
    bool _isAte = false;            // 빵 먹었는지 여부
    ItemObj _itemInfo;              // 아이템 정보

    public void Eat()
    {
        if(!_isAte)
        {
            //Player.IncreaseHealth(1) // 플레이어의 정보가 있는 스크립트에 인자를 줘서 피를 채움
            _isAte = true;
            Invoke("DestroyBread", 2f);
        }
        _isAte = false;
    }
    void DestroyBread()
    {
        Destroy(gameObject);
    }
}

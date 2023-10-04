using System;
using UnityEngine;
[Serializable]
public enum MedicineType
{
    None,
    Bandage,
    FirstAidKit,
    Pills,
}

public class Medicine : ItemParent, IItem
{
    string _name = "";         // 의약품 이름
    float _weight;             // 무게
    float _increaseHP;           // 체력 회복 지수
    HeroStats _playerInfo;
    public MedicineType _mType;

    public override void Init(ItemObj data)
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroStats>();
        MedicineData md = (MedicineData)data;
        _itemObj = data;
        _name = data._name;
        _weight = data._weight;

        _increaseHP = md._increaseHP;
    }
    public void Use()
    {
        FirstAid();
        Debug.Log(_name);
    }
    public void FirstAid()
    {
        //Player.IncreaseHealth(1) // 플레이어의 정보가 있는 스크립트에 인자를 줘서 피를 채움
        _playerInfo.IncHp(_increaseHP);
        Invoke("DestroyBand", 0.01f);
    }
    void DestroyBand()
    {
        Destroy(gameObject);
    }
}

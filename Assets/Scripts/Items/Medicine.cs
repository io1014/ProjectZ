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
    string _name = "";         // �Ǿ�ǰ �̸�
    float _weight;             // ����
    float _increaseHP;           // ü�� ȸ�� ����
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
        //Player.IncreaseHealth(1) // �÷��̾��� ������ �ִ� ��ũ��Ʈ�� ���ڸ� �༭ �Ǹ� ä��
        _playerInfo.IncHp(_increaseHP);
        Invoke("DestroyBand", 0.01f);
    }
    void DestroyBand()
    {
        Destroy(gameObject);
    }
}

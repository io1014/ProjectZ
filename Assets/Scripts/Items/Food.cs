using UnityEngine;

public class Food : ItemParent, IItem
{
    string _name = "Bread";         // ���� �̸�
    float _weight = 0.1f;           // ����
    float _increaseHP = 10f;         // ü�� ȸ�� ����
    float _increaseFull = 1f;       // ��θ� ����
    HeroStats _playerInfo;    // �Ǹ� ä�� �÷��̾��� ����

    public override void Init()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroStats>();
        _itemObj = new ItemObj(_name, EItemType.Food, _weight, 1f, 1);

    }
    public void Use()
    {
        Eating();
        Debug.Log(_name);
    }
    public void Eating()
    {
        _playerInfo.IncHp(_increaseHP);
        Invoke("DestroyBread", 0.01f);
    }
    void DestroyBread()
    {
        Destroy(gameObject);
    }
}


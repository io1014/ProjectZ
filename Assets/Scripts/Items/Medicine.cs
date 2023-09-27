using UnityEngine;

public class Medicine : ItemParent, IItem
{
    string _name = "";         // �Ǿ�ǰ �̸�
    float _weight;             // ����
    float _increaseHP;           // ü�� ȸ�� ����
    HeroStats _playerInfo;

    public override void Init()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroStats>();
        _itemObj = new ItemObj(_name, EItemType.Medicine, _weight, 1f, 1);
    }
    public override void ItemInit(ItemObj data)
    {
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

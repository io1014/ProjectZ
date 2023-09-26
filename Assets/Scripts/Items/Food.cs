using UnityEngine;

public class Food : ItemParent, IItem
{
    string _name = "";             // ���� �̸�
    float _weight;            // ����
    float _increaseHP;        // ü�� ȸ�� ����
    float _increaseFull;      // ��θ� ����
    HeroStats _playerInfo;    // �Ǹ� ä�� �÷��̾��� ����

    private void Start()
    {
        Debug.Log(_name);
    }
    public override void Init()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroStats>();
        _itemObj = new ItemObj(_name, EItemType.Food, _weight, 1f, 1);
    }
    public override void ItemInit(ItemObj data)
    {
        FoodData fd = (FoodData)data;
        _itemObj = data;
        _name = data._name;
        _weight = data._weight;

        _increaseHP = fd._increaseHP;
        _increaseFull = fd._increaseFull;
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


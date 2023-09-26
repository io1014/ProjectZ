using UnityEngine;

public class Food : ItemParent, IItem
{
    string _name = "";             // 음식 이름
    float _weight;            // 무게
    float _increaseHP;        // 체력 회복 지수
    float _increaseFull;      // 배부름 지수
    HeroStats _playerInfo;    // 피를 채울 플레이어의 정보

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


using System;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public enum FoodType
{
    None,
    BellPeper,
    BellPeperSlice,
    Cake,
    CheeseCake,
    Candy,
    Coffee,
    Cookie,
    Curry,
    Doughnut,
    Frappe,
    Hotdog,
    IceCream,
    Ketchup,
    Lamb,
    Melon,
    MelonHalf,
    Peach,
    PeachHalf,
    Pizza,
    PizzaSlice,
    Pretzel,
    Salami,
    Salmon,
    Skewer,
    Soda,
    Susi,
    Tomato,
    Udon,
    CannedFood,
    Water,
}

public class Food : ItemParent, IItem
{
    string _name = "";             // 음식 이름
    float _weight;            // 무게
    float _increaseHP;        // 체력 회복 지수
    float _increaseFull;      // 배부름 지수
    TextMove _txtMove;
    HeroStats _playerInfo;    // 피를 채울 플레이어의 정보
    public FoodType _fType;

    private void Start()
    {
        
    }
    public override void Init(ItemObj data)
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroStats>();
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
        
        //StartCoroutine(GenericSingleton<TextMove>._instance.GetComponent<TextMove>().MoveTextUp());
        Debug.Log(_name);
    }
    public void Eating()
    {
        _playerInfo.IncHp(_increaseHP);
        _playerInfo.IncHungry(_increaseFull);
        Invoke("DestroyBread", 0.01f);
    }
    void DestroyBread()
    {
        Destroy(gameObject);
    }
}


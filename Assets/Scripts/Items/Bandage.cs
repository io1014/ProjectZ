using UnityEngine;

public class Bandage : ItemParent, IItem
{
    string _name = "Bandage";         // 의약품 이름
    float _weight = 0.1f;             // 무게
    float _increaseHP = 4f;           // 체력 회복 지수
    HeroStats _playerInfo;

    public override void Init()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroStats>();
        _itemObj = new ItemObj(_name, EItemType.Medicine, _weight, 1f, 1);
        
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
        Invoke("DestroyBand", 2f);
    }
    void DestroyBand()
    {
        Destroy(gameObject);
    }
}

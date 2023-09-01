using UnityEngine;

public class Bandage : ItemParent
{
    string _name = "Bandage";         // 의약품 이름
    float _weight = 0.1f;             // 무게
    float _increaseHP = 1f;           // 체력 회복 지수
    ExamPlayerInfo _playerInfo;
    bool _isTreat = false;
    private void Awake()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<ExamPlayerInfo>();
        _itemObj = new ItemObj("Bandage", EItemType.Medicine, 1f, 1);
    }
    public void FirstAid(bool isTreat)
    {
        //Player.IncreaseHealth(1) // 플레이어의 정보가 있는 스크립트에 인자를 줘서 피를 채움
        _playerInfo.IncHp(10);
        IsTreat(isTreat);
        Invoke("DestroyBand", 2f);
    }
    public void IsTreat(bool isTreat) => _isTreat = isTreat;
    void DestroyBand()
    {
        Destroy(gameObject);
    }
}

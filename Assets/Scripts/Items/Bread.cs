using UnityEngine;

public class Bread : ItemParent
{
    //[SerializeField] string name;
    string _name = "Bread";         // 음식 이름
    float _weight = 0.1f;           // 무게
    float _increaseHP = 1f;         // 체력 회복 지수
    float _increaseFull = 1f;       // 배부름 지수
    bool _isAte = false;            // 빵 먹었는지 여부
    ExamPlayerInfo _playerInfo;     // 피를 채울 플레이어의 정보

    private void Awake()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<ExamPlayerInfo>();
        _itemObj = new ItemObj("Bread", EItemType.Food, 1f, 1);
    }
    public void Eating(bool isAte)
    {
        //Player.IncreaseHealth(1) // 플레이어의 정보가 있는 스크립트에 인자를 줘서 피를 채움
        _playerInfo.IncHp(10);
        IsEating(isAte);
        Invoke("DestroyBread", 1f);
    }
    public void IsEating(bool isAte) => _isAte = isAte;
    void DestroyBread()
    {
        Destroy(gameObject);
    }
}


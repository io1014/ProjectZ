using UnityEngine;

public class Bandage : MonoBehaviour
{
    string _name = "Bandage";         // 의약품 이름
    float _weight = 0.1f;             // 무게
    float _increaseHP = 1f;           // 체력 회복 지수
    ItemObj _itemInfo;                // 아이템 정보
    ExamPlayerInfo _playerInfo;
    private void Awake()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<ExamPlayerInfo>();
    }
    public void Healing()
    {
        //Player.IncreaseHealth(1) // 플레이어의 정보가 있는 스크립트에 인자를 줘서 피를 채움
        _playerInfo.IncHp(10);
        Invoke("DestroyBand", 2f);
    }
    void DestroyBand()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Bandage : MonoBehaviour
{
    string _name = "Bandage";         // �Ǿ�ǰ �̸�
    float _weight = 0.1f;             // ����
    float _increaseHP = 1f;           // ü�� ȸ�� ����
    ItemObj _itemInfo;                // ������ ����
    ExamPlayerInfo _playerInfo;
    private void Awake()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<ExamPlayerInfo>();
    }
    public void Healing()
    {
        //Player.IncreaseHealth(1) // �÷��̾��� ������ �ִ� ��ũ��Ʈ�� ���ڸ� �༭ �Ǹ� ä��
        _playerInfo.IncHp(10);
        Invoke("DestroyBand", 2f);
    }
    void DestroyBand()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Bandage : ItemParent
{
    string _name = "Bandage";         // �Ǿ�ǰ �̸�
    float _weight = 0.1f;             // ����
    float _increaseHP = 1f;           // ü�� ȸ�� ����
    ExamPlayerInfo _playerInfo;
    bool _isTreat = false;
    private void Awake()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<ExamPlayerInfo>();
        _itemObj = new ItemObj("Bandage", EItemType.Medicine, 1f, 1);
    }
    public void FirstAid(bool isTreat)
    {
        //Player.IncreaseHealth(1) // �÷��̾��� ������ �ִ� ��ũ��Ʈ�� ���ڸ� �༭ �Ǹ� ä��
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

using UnityEngine;

public class Bandage : ItemParent, IItem
{
    string _name = "Bandage";         // �Ǿ�ǰ �̸�
    float _weight = 0.1f;             // ����
    float _increaseHP = 4f;           // ü�� ȸ�� ����
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
        //Player.IncreaseHealth(1) // �÷��̾��� ������ �ִ� ��ũ��Ʈ�� ���ڸ� �༭ �Ǹ� ä��
        _playerInfo.IncHp(_increaseHP);
        Invoke("DestroyBand", 2f);
    }
    void DestroyBand()
    {
        Destroy(gameObject);
    }
}

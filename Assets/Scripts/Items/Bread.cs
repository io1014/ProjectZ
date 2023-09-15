using UnityEngine;

public class Bread : ItemParent
{
    string _name = "Bread";         // ���� �̸�
    float _weight = 0.1f;           // ����
    float _increaseHP = 10f;         // ü�� ȸ�� ����
    float _increaseFull = 1f;       // ��θ� ����
    bool _isAte = false;            // �� �Ծ����� ����
    HeroStats _playerInfo;    // �Ǹ� ä�� �÷��̾��� ����

    private void Awake()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroStats>();
        _itemObj = new ItemObj(_name, EItemType.Food, _weight, 1f, 1);
    }
    public void Eating(bool isAte)
    {
        //Player.IncreaseHealth(1) // �÷��̾��� ������ �ִ� ��ũ��Ʈ�� ���ڸ� �༭ �Ǹ� ä��
        _playerInfo.IncHp(_increaseHP);
        IsEating(isAte);
        Invoke("DestroyBread", 1f);
    }
    public void IsEating(bool isAte) => _isAte = isAte;
    void DestroyBread()
    {
        Destroy(gameObject);
    }
}


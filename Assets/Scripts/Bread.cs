using UnityEngine;

public class Bread : ItemParent
{
    //[SerializeField] string name;
    string _name = "Bread";         // ���� �̸�
    float _weight = 0.1f;           // ����
    float _increaseHP = 1f;         // ü�� ȸ�� ����
    float _increaseFull = 1f;       // ��θ� ����
    bool _isAte = false;            // �� �Ծ����� ����
    ExamPlayerInfo _playerInfo;     // �Ǹ� ä�� �÷��̾��� ����

    private void Awake()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<ExamPlayerInfo>();
        _itemObj = new ItemObj("Bread", EItemType.Food, 1f, 1);
    }
    public void Eating(bool isAte)
    {
        //Player.IncreaseHealth(1) // �÷��̾��� ������ �ִ� ��ũ��Ʈ�� ���ڸ� �༭ �Ǹ� ä��
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


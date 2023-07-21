using UnityEngine;

public class Bread : ItemParent
{
    //[SerializeField] string name;
    string _name = "Bread";         // ���� �̸�
    float _weight = 0.1f;           // ����
    float _increaseHP = 1f;         // ü�� ȸ�� ����
    float _increaseFull = 1f;       // ��θ� ����
    bool _isAte = false;            // �� �Ծ����� ����
    //ItemObj _itemInfo;              // ������ ����
    ExamPlayerInfo _playerInfo;     // �Ǹ� ä�� �÷��̾��� ����

    private void Awake()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<ExamPlayerInfo>();
        _itemObj = new ItemObj("Bread", EItemType.Food);
        //_itemobj = GetComponent<ItemObj>();
    }
    public void Eating()
    {
        if(!_isAte)
        {
            //Player.IncreaseHealth(1) // �÷��̾��� ������ �ִ� ��ũ��Ʈ�� ���ڸ� �༭ �Ǹ� ä��
            _isAte = true;
            _playerInfo.IncHp(10);
            Invoke("DestroyBread", 1f);
        }
        _isAte = false;
    }
    void DestroyBread()
    {
        Destroy(gameObject);
    }
}


using UnityEngine;

public class Food : ItemParent, IItem
{
    [SerializeField] string _name;         // ���� �̸�
    [SerializeField] float _weight;           // ����
    [SerializeField] float _increaseHP;         // ü�� ȸ�� ����
    [SerializeField] float _increaseFull;       // ��θ� ����
    HeroStats _playerInfo;    // �Ǹ� ä�� �÷��̾��� ����

    private void Start()
    {
        Debug.Log(_name);
    }
    public override void Init()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroStats>();
        _itemObj = new ItemObj(_name, EItemType.Food, _weight, 1f, 1);
    }
    public void Use()
    {
        Eating();
        Debug.Log(_name);
    }
    public void Eating()
    {
        _playerInfo.IncHp(_increaseHP);
        Invoke("DestroyBread", 0.01f);
    }
    void DestroyBread()
    {
        Destroy(gameObject);
    }
}


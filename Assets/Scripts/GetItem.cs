using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;
    List<ItemObj> items = new List<ItemObj>();
    HeroStats _player;
    List<GameObject> _itemList = new List<GameObject>();
    float _itemRadius = 10;
    private void Start()
    {
        ItemObj itm1 = new ItemObj(sprites[0],"�ǽ���",EItemType.Pistol);
        items.Add(itm1);
        ItemObj itm2 = new ItemObj(sprites[0], "�ǽ���", EItemType.Pistol);
        ItemObj itm3 = new ItemObj(sprites[0], "�ǽ���", EItemType.Pistol);
    }
    void Update()
    {
        // Ư�� �Ÿ� �ȿ� �ִ� ��� ������ ����� ������ �� �ִ� �Լ�
    }
    public List<GameObject> FindItem()
    {
        // ��ó�� �ִ� ������ �� Ư���Ÿ� �ȿ� ���� �����۵��� ����Ʈ�� ������
        _itemList.Clear();
        GameObject[] _items = GameObject.FindGameObjectsWithTag("Item");
        _player = GetComponent<HeroStats>();
        foreach (var item in _items)
        {
            float distance = Vector3.Distance(_player.transform.position, item.transform.position);
            if(distance <= _itemRadius)
            {
                _itemList.Add(item);
            }
        }
        return _itemList;
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
    public void RemoveInventory()
    {

    }
}


public class ItemObj
{
    public Sprite _sprite;
    public string _name;
    public EItemType _eType;
    HeroStats _player;
    Pistol _pistol;
    public ItemObj(Sprite spr, string name, EItemType etype)
    {
        _sprite = spr;
        _name = name;
        _eType = etype;
    }
    public void Equip()
    {
        // �ڱ� ������ 
        // �ǽ��丵�� ĳ������ �տ� �ǽ����� ����� ���δ�.
        if(_eType == EItemType.Pistol)
        {
            //ĳ���� �տ� �ǽ����� ������� ���δ�.
            _pistol._equipped = true;
            GameObject HeroArm = _player.gameObject;
            HeroArm = GameObject.Find("Right");
        }
        else if(_eType == EItemType.Juice)
        {
            //�÷��̾� ������ ���ҽ�Ų��.
        }
    }
}

public enum EItemType
{
    // 0~ 10 ����
    Pistol,
    // 11 ~ 20 ����
    Juice,
}
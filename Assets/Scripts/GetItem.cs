using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetItem : MonoBehaviour
{

    [SerializeField] Sprite[] sprites;
    List<ItemObj> items = new List<ItemObj>();
    HeroStats _player;
    List<GameObject> _itemList = new List<GameObject>();
    float _itemRadius = 10;
    private void Start()
    {
        //ItemObj itm1 = new ItemObj(/*sprites[0],*/ "�ǽ���", EItemType.Pistol);
        //items.Add(itm1);
        //Debug.Log(itm1);
        //ItemObj itm2 = new ItemObj(sprites[0], "�ǽ���", EItemType.Pistol);
        //ItemObj itm3 = new ItemObj(sprites[0], "�ǽ���", EItemType.Pistol);
    }
    void Update()
    {
        // Ư�� �Ÿ� �ȿ� �ִ� ��� ������ ����� ������ �� �ִ� �Լ�
        if(Input.GetMouseButtonDown(0))
        {
            //ItemObj itm1 = new ItemObj(/*null,*/ "Pistol", EItemType.Pistol);
            //itm1.Equip();
        }
    }
    public List<GameObject> FindItem()
    {
        // ��ó�� �ִ� ������ �� Ư���Ÿ� �ȿ� ���� �����۵��� ����Ʈ�� ������
        _itemList.Clear();
        GameObject[] _items = GameObject.FindGameObjectsWithTag("Item");
        // Item �±׷� ã������, ���� �� ��� ����ó�� �ֺ��� Physics.OverlapSphere�� �̿��ؼ� �����
        _player = GetComponent<HeroStats>();
        foreach (var item in _items)
        {
            float distance = Vector3.Distance(_player.transform.position, item.transform.position);
            if(distance <= _itemRadius)
            {
                _itemList.Add(item);
                //GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().AddInventoryItem(item);
            }
        }
        return _itemList;
    }
}


public class ItemObj
{
    //public Sprite _sprite;
    public string _name;
    public EItemType _eType;
    public ItemObj(/*Sprite spr,*/ string name, EItemType etype)
    {
        //_sprite = spr;
        _name = name;
        _eType = etype;
    }
}

public enum EItemType
{
    // ����
    Pistol,
    Shotgun,
    Rifle,
    ShortSword,
    LongSword,
    BaseballBat,
    OneHandAxe,
    TwoHandAxe,

    // ����
    Bread,
    // ��ֹ�
    WireFence,
    // �Ǿ�ǰ
    Bandage,
}
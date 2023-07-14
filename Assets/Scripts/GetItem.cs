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
        //ItemObj itm1 = new ItemObj(/*sprites[0],*/ "피스톨", EItemType.Pistol);
        //items.Add(itm1);
        //Debug.Log(itm1);
        //ItemObj itm2 = new ItemObj(sprites[0], "피스톨", EItemType.Pistol);
        //ItemObj itm3 = new ItemObj(sprites[0], "피스톨", EItemType.Pistol);
    }
    void Update()
    {
        // 특정 거리 안에 있는 모든 아이템 목록을 리턴할 수 있는 함수
        if(Input.GetMouseButtonDown(0))
        {
            //ItemObj itm1 = new ItemObj(/*null,*/ "Pistol", EItemType.Pistol);
            //itm1.Equip();
        }
    }
    public List<GameObject> FindItem()
    {
        // 근처에 있는 아이템 중 특정거리 안에 들어온 아이템들의 리스트를 저장함
        _itemList.Clear();
        GameObject[] _items = GameObject.FindGameObjectsWithTag("Item");
        // Item 태그로 찾지말고, 수업 때 배운 좀비처럼 주변에 Physics.OverlapSphere를 이용해서 만들기
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
    // 무기
    Pistol,
    Shotgun,
    Rifle,
    ShortSword,
    LongSword,
    BaseballBat,
    OneHandAxe,
    TwoHandAxe,

    // 음식
    Bread,
    // 장애물
    WireFence,
    // 의약품
    Bandage,
}
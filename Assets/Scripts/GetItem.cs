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
        //ItemObj itm1 = new ItemObj(sprites[0],"피스톨",EItemType.Pistol);
        //items.Add(itm1);
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
    //public Sprite _sprite;
    public string _name;
    public EItemType _eType;
    public Pistol _pistol;
    public Bread _bread;
    public WireFence _wireFence;
    public ItemObj(/*Sprite spr,*/ string name, EItemType etype)
    {
        //_sprite = spr;
        _name = name;
        _eType = etype;
    }
    public void SetPistol(Pistol pistol)
    {
        _pistol = pistol;
    }
    public void SetBread(Bread bread)
    {
        _bread = bread;
    }
    public void SetWirfence(WireFence wireFence)
    {
        _wireFence = wireFence;
    }
    public void Equip()
    {
        // 자기 종류가 피스톨이면 캐릭터의 손에 피스톨을 만들어 붙인다.
            GameObject heroHand = GameObject.Find("Right");
            _pistol.transform.SetParent(heroHand.transform);
            _pistol.transform.localPosition = Vector3.zero;
            _pistol.equipped();
    }
    public void Eating()
    {
            GameObject heroHand = GameObject.Find("Right");
            _bread.transform.SetParent(heroHand.transform);
            _bread.transform.localPosition = Vector3.zero;
            _bread.Eat();
    }
}

public enum EItemType
{
    // 0 ~ 10 무기
    Pistol,
    // 11 ~ 20 음식
    Bread,
    // 21 ~ 30 장애물
    WireFence,
}